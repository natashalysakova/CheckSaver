using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CheckSaverCore.DataModels.InputModels
{
    public class CheckInputModel
    {
        [DisplayName("Дата покупки")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [DisplayName("Магазин")]
        public string StoreId { get; set; }

        [DisplayName("Кто платил?")]
        public string NeighborId { get; set; }

        [DisplayName("Покупки")]
        public List<PurchaseInputModel> Purchases { set; get; }

        public int Id { get; set; }
    }
}