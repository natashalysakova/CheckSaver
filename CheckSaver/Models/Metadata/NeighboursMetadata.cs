using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CheckSaver.Models.Metadata
{
    public class NeighboursMetadata
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Photo { get; set; }

    }
}