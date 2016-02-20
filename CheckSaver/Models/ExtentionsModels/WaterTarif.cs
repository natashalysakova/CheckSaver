using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CheckSaver.Models.ExtentionsModels;

namespace CheckSaver.Models
{
    public partial class WaterTarif : ITarif
    {
        public decimal Calculate(double difference, int month = 0)
        {
            return Convert.ToDecimal(difference) * Price;
        }
    }
}