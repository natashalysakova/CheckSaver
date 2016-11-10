using System.ComponentModel.DataAnnotations;
using CheckSaverCore.tmp.Metadata;

namespace CheckSaverCore.tmp.ExtentionsModels
{
    [MetadataType(typeof(ProductsMetadata))]
    partial class Products
    {
        //internal decimal GetPrice(int storeId)
        //{
        //    return this.Price.Where(x => x.StoreId == storeId).FirstOrDefault().Cost;
        //}
    }
}