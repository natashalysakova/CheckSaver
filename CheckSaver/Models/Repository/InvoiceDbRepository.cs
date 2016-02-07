using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using CheckSaver.Models.InputModels;

namespace CheckSaver.Models.Repository
{
    public partial class InvoiceDbRepository
    {
        private InvoicesCS db = new InvoicesCS();
        const string COLD = "0";
        const string HOT = "1";

        public IEnumerable<Month> GetMonthes()
        {
            List<Month> monthes = new List<Month>();
            for (int i = 0; i < 12; i++)
            {
                    monthes.Add(new Month() { MonthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(i+1), Id = i+1});
            }

            return monthes;
        }

        public WaterTarif GetActualColdWaterTarif(int month, int year)
        {
            return GetActualWaterTarif(month, year, COLD);
        }

        public WaterTarif GetActualHotWaterTarif(int month, int year)
        {
            return GetActualWaterTarif(month, year, HOT);
        }


        WaterTarif GetActualWaterTarif(int month, int year, string TYPE)
        {
            DateTime dt = new DateTime(year, month, 1);
            var tarifs = (from tarif in db.WaterTarif
                          where tarif.WaterType == TYPE && (tarif.StartDate <= dt && (tarif.FinishDate == null || tarif.FinishDate.Value > dt))
                          select tarif);

            if (!tarifs.Any())
            {
                throw new TarifNotFoundException();
            }

            return tarifs.First();

        }




        public ElectricityTarif GetActualElectricityTarif(int month, int year)
        {
            DateTime dt = new DateTime(year, month, 1);

            var tarifs = (from tarif in db.ElectricityTarif
                          where tarif.StartDate <= dt && (tarif.FinishDate == null || tarif.FinishDate.Value > dt)
                          select tarif);

            if (!tarifs.Any())
            {
                throw new TarifNotFoundException();
            }

            return tarifs.First();
        }

        public GasTarif GetActualGasTarif(int month, int year)
        {
            DateTime dt = new DateTime(year, month, 1);

            var tarifs = (from tarif in db.GasTarif
                          where tarif.StartDate <= dt && (tarif.FinishDate == null || tarif.FinishDate.Value > dt)
                          select tarif);

            return !tarifs.Any() ? null : tarifs.First();
        }





        [Serializable]
        public class TarifNotFoundException : Exception
        {
        }

        public struct Month
        {
            public int Id { get; set; }
            public string MonthName { get; set; }
        }

        public void SetActualTarifs(InvoiceInputModel model)
        {
            model.ColdWaterInput.Tarif = GetActualColdWaterTarif(model);
            model.HotWaterInput.Tarif = GetActualHotWaterTarif(model);
            model.ElectricityInput.Tarif = GetActualElectricityTarif(model);
            model.GasInput.Tarif = GetActualGasTarif(model);
            
        }

        private GasTarif GetActualGasTarif(InvoiceInputModel model)
        {
            return GetActualGasTarif(model.Month, model.Year);
        }

        private ElectricityTarif GetActualElectricityTarif(InvoiceInputModel model)
        {
            return GetActualElectricityTarif(model.Month, model.Year);
        }

        private WaterTarif GetActualHotWaterTarif(InvoiceInputModel model)
        {
            return GetActualHotWaterTarif(model.Month, model.Year);
        }

        private WaterTarif GetActualColdWaterTarif(InvoiceInputModel model)
        {
            return GetActualColdWaterTarif(model.Month, model.Year);
        }
    }
}