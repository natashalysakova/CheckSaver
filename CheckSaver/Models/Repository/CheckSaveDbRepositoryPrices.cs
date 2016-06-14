using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckSaver.Models.Repository
{
    public partial class CheckSaveDbRepository
    {
        //private Price AddNewOrGetExistPrice(Products product, int storeId)
        //{
        //    Price exist = (from price in _db.Price where price.ProductId == product.Id && price.StoreId == storeId orderby price.Date select price).FirstOrDefault();

        //    if(exist == null)
        //    {
        //        exist = new Price { ProductId = product.Id, StoreId = storeId, Date = DateTime.Now, Cost = 0 };
        //        _db.Price.Add(exist);
        //        _db.SaveChanges();
        //    }

        //    return exist;
        //}
    }
}