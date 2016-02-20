using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CheckSaver.Models.InputModels
{
    public class FixedPaysInputModel
    {
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}