using System;
using System.ComponentModel.DataAnnotations;

namespace CheckSaver.Models.Metadata
{
    public class PurchaseMetadata
    {
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Cost { get; set; }
    }
}