using System.ComponentModel;

namespace CheckSaverCore.DataModels.InputModels
{
    public class ProductInputModel
    {

        [DisplayName("Название")]
        public string Name { get; set; }

        [DisplayName("Цена")]
        public string Price { get; set; }

    }
}