using System.ComponentModel;

namespace CheckSaver.Models.InputModels
{
    public class ProductInputModel
    {
        [DisplayName("�������")]
        public string Name { get; set; }

        [DisplayName("����")]
        public string Price { get; set; }
    }
}