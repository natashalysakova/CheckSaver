using System;
using CheckSaverCore;

namespace CheckSaver.Areas.Invoices.Models
{
    //public partial class ElectricityTarif : ITarif
    //{
    //    //public decimal Calculate(double difference, int month = 0)
    //    //{
    //        //decimal dif = Convert.ToDecimal(difference);

    //        ////if just one price 
    //        //if (!HighLevelRange.HasValue || !MiddlePrice.HasValue || !HighPrice.HasValue)
    //        //    return dif * LowPrice;

    //        ////before low range
    //        //if (difference < LowLevelRange)
    //        //    return dif * LowPrice;

    //        ////between low and high range
    //        //if (difference < HighLevelRange.Value)
    //        //    return (LowLevelRange * LowPrice) + ((dif - LowLevelRange) * MiddlePrice.Value);

    //        ////above high range
    //        //return (dif - HighLevelRange.Value) * HighPrice.Value +
    //        //        (dif - (dif - HighLevelRange.Value) - LowLevelRange) * MiddlePrice.Value + LowLevelRange * LowPrice;

    //        ////(E15-Tariffs!C13)*Tariffs!E13+(E15-(E15-Tariffs!C13)-Tariffs!C11)*Tariffs!E12+Tariffs!C11*Tariffs!E11
    //    //}
    //}
}