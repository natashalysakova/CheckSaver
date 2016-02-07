using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using CheckSaver.Models.ExtentionsModels;
using CheckSaver.Models.Repository;

namespace CheckSaver.Models.InputModels
{
    public class InvoiceInputModel
    {
        public Utilities<WaterTarif> ColdWaterInput { get; set; }
        public Utilities<WaterTarif> HotWaterInput { get; set; }
        public Utilities<ElectricityTarif> ElectricityInput { get; set; }
        public Utilities<GasTarif> GasInput { get; set; }

        List<FixedPays> FixedPaysInput { get; set; }

        public int Month { get; set; }
        public int Year { get; set; }
        public DateTime CreationDate { get; set; }

        public Decimal TotalSum { get; set; }
        public string Address { get; set; }


        public InvoiceInputModel()
        {
            ColdWaterInput = new Utilities<WaterTarif>();
            HotWaterInput = new Utilities<WaterTarif>();
            ElectricityInput = new Utilities<ElectricityTarif>();
            GasInput = new Utilities<GasTarif>();
        }


        public class Utilities<T> where T : ITarif
        {
            public double StartValue { get; set; }
            public double FinishValue { get; set; }
            public double Difference { get; set; }
            public double Cost { get; set; }

            public T Tarif { get; set; }
        }
    }
}