using System.Collections.Generic;
using System.ComponentModel;

namespace CheckSaver.Models.InputModels
{
    public class PurchaseInputModel
    {
        [DisplayName("Продукт")]
        public ProductInputModel Product { get; set; }

        [DisplayName("Количество")]
        public string Count { get; set; }

        [DisplayName("Кто будет использовать")]
        public List<object> WhoWillUse { set; get; }
    }
}