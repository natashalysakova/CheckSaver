using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using CheckSaver.Models.Metadata;

namespace CheckSaver.Models
{
    [MetadataType(typeof(TransactionsMetadata))]
    public partial class Transactions
    {
    }
}