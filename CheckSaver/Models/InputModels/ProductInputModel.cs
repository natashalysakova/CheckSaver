using System.ComponentModel;

namespace CheckSaver.Models.InputModels
{
    public class ProductInputModel
    {
        [DisplayName("Продукт")]
        public string Name { get; set; }

        [DisplayName("Цена")]
        public string Price { get; set; }
    }
}