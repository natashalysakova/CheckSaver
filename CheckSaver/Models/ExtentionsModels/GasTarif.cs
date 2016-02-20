using System;
using CheckSaver.Models.ExtentionsModels;

namespace CheckSaver.Models
{
    public partial class GasTarif : ITarif
    {
        public decimal Calculate(double difference, int month)
        {
            //еякх(х(C4 >= Tariffs!B17; C4 <= Tariffs!C17); E19* Tariffs!E17; еякх(E19 > Tariffs!D20; (E19 - Tariffs!D20)*Tariffs!E20 + (E19 - (E19 - Tariffs!D20))*Tariffs!E19; E19* Tariffs!E19))
            decimal dif = Convert.ToDecimal(difference);

            if (month >= StartMonth && month <= EndMonth)
                return dif*HighPrice.Value;

            if (difference < LevelRange)
                return dif*LowPrice;

            return (dif - (dif - LevelRange))*HighPrice.Value + (LevelRange*LowPrice);

        }
    }
}