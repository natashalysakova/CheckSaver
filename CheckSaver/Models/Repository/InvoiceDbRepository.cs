using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using CheckSaver.Models.ExtentionsModels;
using CheckSaver.Models.InputModels;

namespace CheckSaver.Models.Repository
{
    public partial class InvoiceDbRepository
    {
        private InvoicesCS db = new InvoicesCS();
        const string COLD = "0";
        const string HOT = "1";
        const string ELECTR = "2";
        const string GAS = "3";

        public IEnumerable<Month> GetMonthes()
        {
            List<Month> monthes = new List<Month>();
            for (int i = 0; i < 12; i++)
            {
                monthes.Add(new Month() {MonthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(i + 1), Id = i + 1});
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
                where
                    tarif.WaterType == TYPE &&
                    (tarif.StartDate <= dt && (tarif.FinishDate == null || tarif.FinishDate.Value > dt))
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
            model.FixedPaysInput = GetFixedPays();

            model.ColdWaterInput.StartValue = GetLastValue(COLD).ToString();
            model.HotWaterInput.StartValue = GetLastValue(HOT).ToString();
            model.ElectricityInput.StartValue = GetLastValue(ELECTR).ToString();
            model.GasInput.StartValue = GetLastValue(GAS).ToString();


        }


        private decimal GetLastValue(string utilityType)
        {
            var invoices = from invoice in db.Invoice
                orderby invoice.Year
                orderby invoice.Month
                select invoice;

            if (invoices.Any())
            {
                switch (utilityType)
                {
                    case COLD:
                        return invoices.Last().ColdWater.FinishValue;
                    case HOT:
                        return invoices.Last().HotWater.FinishValue;
                    case ELECTR:
                        return invoices.Last().Electricity.FinishValue;
                    case GAS:
                        return invoices.Last().Gas.FinishValue;
                }
            }

            return 0;
        }


        private List<FixedPaysInputModel> GetFixedPays()
        {
            List<string> paysName = (from name in db.FPName select name.Name).ToList();


            List<FixedPaysInputModel> model = new List<FixedPaysInputModel>();
            foreach (string names in paysName)
            {
                model.Add(new FixedPaysInputModel() {Name = names, Price = GetLastPriceForPay(names)});
            }

            return model;
        }

        private decimal GetLastPriceForPay(string names)
        {
            var pays = from pay in db.FixedPays
                where pay.FPName.Name == names
                orderby pay.Invoice.Year
                orderby pay.Invoice.Month
                select pay;

            if (pays.Any())
                return pays.Last().Price;

            return 0;
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

        public ITarif GetTarif(string type, int tarifId)
        {
            IEnumerable<ITarif> tarifs = new List<ITarif>();

            if (type == COLD || type == HOT)
            {
                tarifs = (from tarif in db.WaterTarif where tarif.Id == tarifId select tarif);
            }
            else if (type == ELECTR)
            {
                tarifs = (from tarif in db.ElectricityTarif where tarif.Id == tarifId select tarif);
            }
            else if (type == GAS)
            {
                tarifs = (from tarif in db.GasTarif where tarif.Id == tarifId select tarif);

            }



            if (tarifs.Any())
                return tarifs.First();

            return null;
        }
    }
}