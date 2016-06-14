using CheckSaver.Models.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CheckSaver.Models
{
    [MetadataType(typeof(ProductsMetadata))]
    public partial class Products
    {
        //internal decimal GetPrice(int storeId)
        //{
        //    return this.Price.Where(x => x.StoreId == storeId).FirstOrDefault().Cost;
        //}
    }
}