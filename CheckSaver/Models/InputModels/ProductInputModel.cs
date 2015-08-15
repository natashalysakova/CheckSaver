using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CheckSaver.Models.InputModels
{
    public class ProductInputModel
    {

        [DisplayName("Название")]
        public string Name { get; set; }

        [DisplayName("Цена")]
        public string Price { get; set; }

    }
}