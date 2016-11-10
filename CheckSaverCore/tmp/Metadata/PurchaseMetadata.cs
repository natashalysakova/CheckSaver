using System.ComponentModel.DataAnnotations;

namespace CheckSaverCore.tmp.Metadata
{
    public class PurchaseMetadata
    {
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Cost { get; set; }
    }
}