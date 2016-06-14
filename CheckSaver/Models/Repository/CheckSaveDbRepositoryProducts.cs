using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CheckSaver.Models.InputModels;

namespace CheckSaver.Models.Repository
{
    public partial class CheckSaveDbRepository 
    {
        //public IEnumerable<Products> GetAllProducts()
        //{
        //    return _db.Products.ToList();
        //}

        //internal Products FindProductById(int? id)
        //{
        //    return _db.Products.Find(id);
        //}


        //public int AddNewProduct(Products product)
        //{
        //    _db.Products.Add(product);
        //    _db.SaveChanges();
        //    return product.Id;
        //}

        //public Products AddNewOrGetExistProduct(ProductInputModel product)
        //{
        //    Products exist = (from p in _db.Products where p.Title == product.Name select p).FirstOrDefault();

        //    if (exist == null)
        //    {
        //        exist = new Products { Title = product.Name};
        //        _db.Products.Add(exist);
        //        _db.SaveChanges();
        //    }

        //    return exist;
        //}

        //public void EditProduct(Products product)
        //{
        //    _db.Entry(product).State = EntityState.Modified;
        //    _db.SaveChanges();
        //}

        //public void RemoveProduct(int id)
        //{
        //    Products product = FindProductById(id);
        //    while (product.Purchases.Any())
        //    {

        //        while (product.Purchases.Last().WhoWillUse.Any())
        //            {
        //                _db.WhoWillUse.Remove(product.Purchases.Last().WhoWillUse.Last());
        //            }

        //        _db.Purchases.Remove(product.Purchases.Last());
        //    }

        //    while (product.Price.Any())
        //    {
        //        product.Price.Remove(product.Price.Last());
        //    }


        //    _db.Products.Remove(product);
        //    _db.SaveChanges();
        //}
    }
}