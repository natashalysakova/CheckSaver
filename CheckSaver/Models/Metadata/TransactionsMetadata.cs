using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CheckSaver.Models.Metadata
{
    public class TransactionsMetadata
    {
        [Required]
        public string Caption { get; set; }

    }
}