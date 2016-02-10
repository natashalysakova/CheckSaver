using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CheckSaver.Models.ExtentionsModels;

namespace CheckSaver.Models
{
    public partial class WaterTarif : ITarif
    {
        public decimal Calculate(double difference)
        {
            return Convert.ToDecimal(difference) * Price;
        }
    }


    public partial class ElectricityTarif : ITarif
    {
        public decimal Calculate(double difference)
        {
            return 0;
        }
    }


    public partial class GasTarif : ITarif
    {
        public decimal Calculate(double difference)
        {
            return 0;
        }
    }
}