using System.ComponentModel;

namespace CheckSaverCore.tmp.InputModels
{
    public class ProductInputModel
    {

        [DisplayName("Название")]
        public string Name { get; set; }

        [DisplayName("Цена")]
        public string Price { get; set; }

    }
}