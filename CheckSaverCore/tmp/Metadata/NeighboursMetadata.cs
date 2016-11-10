using System.ComponentModel.DataAnnotations;

namespace CheckSaverCore.tmp.Metadata
{
    public class NeighboursMetadata
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Photo { get; set; }

    }
}