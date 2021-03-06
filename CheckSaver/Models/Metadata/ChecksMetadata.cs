﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CheckSaver.Models.Metadata
{
    public class ChecksMetadata
    {
        [DisplayName("Дата покупки")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

    }
}