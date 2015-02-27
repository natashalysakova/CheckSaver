using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CheckSaver.Models.InputModels;

namespace CheckSaver.Models.Repository
{
    public partial class CheckSaveDbRepository 
    {
        public IEnumerable<Product> GetAllProducts()
        {
            return _db.Product.Include(p => p.Store).ToList();
        }

        internal Product FindProductById(int? id)
        {
            return _db.Product.Find(id);
        }


        public int AddNewProduct(Product product)
        {
            _db.Product.Add(product);
            _db.SaveChanges();
            return product.Id;
        }

        public Product AddNewOrGetExistProduct(ProductInputModel product, int storeId)
        {
            decimal price = Convert.ToDecimal(product.Price.Replace(".", ","));


            Product exist = (from p in _db.Product where p.Name == product.Name select p).FirstOrDefault();

            if (exist == null)
            {
                exist = new Product { Name = product.Name, Price = price, StoreId = storeId };
                _db.Product.Add(exist);
                _db.SaveChanges();
            }
            else
            {
                if (exist.Price != price)
                {
                    exist.Price = price;
                    _db.Entry(exist).State = EntityState.Modified;
                    _db.SaveChanges();
                }
            }

            return exist;
        }

        public void EditProduct(Product product)
        {
            _db.Entry(product).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void RemoveProduct(int id)
        {
            Product product = FindProductById(id);
            while (product.Purchase.Any())
            {
                while (product.Purchase.Last().Currency.Any())
                    {
                        _db.Currency.Remove(product.Purchase.Last().Currency.Last());
                    }

                while (product.Purchase.Last().WhoWillUse.Any())
                    {
                        _db.WhoWillUse.Remove(product.Purchase.Last().WhoWillUse.Last());
                    }

                _db.Purchase.Remove(product.Purchase.Last());
            }
            _db.Product.Remove(product);
            _db.SaveChanges();
        }
    }
}