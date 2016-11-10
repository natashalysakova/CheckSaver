using System.ComponentModel.DataAnnotations;

namespace CheckSaverCore.tmp.Metadata
{
    public class StoresMetadata
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Photo { get; set; }

        [Required]
        public string Address { get; set; }

    }
}