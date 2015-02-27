using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CheckSaver.Models.InputModels
{
    public class CheckInputModel
    {
        [DisplayName("Дата покупки")]
        public DateTime DateTime { get; set; }

        [DisplayName("Магазин")]
        public string StoreId { get; set; }

        [DisplayName("Кто платил?")]
        public string NeighborId { get; set; }

        [DisplayName("Покупки")]
        public List<PurchaseInputModel> Purchases { set; get; }
    }
}