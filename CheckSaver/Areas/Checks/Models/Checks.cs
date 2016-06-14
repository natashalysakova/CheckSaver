using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CheckSaver.Models.Metadata;

namespace CheckSaver.Models
{

    [MetadataType(typeof(ChecksMetadata))]
    public partial class Checks
    {

    }
}