using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CheckSaver.Models.ExtentionsModels;

namespace CheckSaver.Models
{
    public partial class WaterTarif : ITarif
    {
        public decimal Calculate()
        {
            throw new NotImplementedException();
        }
    }


    public partial class ElectricityTarif : ITarif
    {
        public decimal Calculate()
        {
            throw new NotImplementedException();
        }
    }


    public partial class GasTarif : ITarif
    {
        public decimal Calculate()
        {
            throw new NotImplementedException();
        }
    }
}