using System.ComponentModel.DataAnnotations;

namespace CheckSaverCore.tmp.InputModels
{
    public class FixedPaysInputModel
    {
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}