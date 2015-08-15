using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CheckSaver.Models.Metadata
{
    public class StoresMetadata
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Photo { get; set; }

        [Required]
        public string Address { get; set; }

    }
}