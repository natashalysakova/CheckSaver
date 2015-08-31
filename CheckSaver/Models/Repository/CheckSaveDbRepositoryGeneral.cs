﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CheckSaver.Models.Repository
{
    public partial class CheckSaveDbRepository :IDisposable
    {
        private uh357966_db2Entities1 _db = new uh357966_db2Entities1();


        internal IEnumerable GetStoresList()
        {
            return (from store in _db.Stores select new {Id = store.Id, Title = store.Title});
        }

        internal IEnumerable GetNeighborsList()
        {
            return (from neighbor in _db.Neighbours select new { Id = neighbor.Id, Name = neighbor.Name });
        }


        public Dictionary<int, string> GetNeighboursNames()
        {
            return _db.Neighbours.OrderBy(x => x.Name).Select(t => new { t.Id, t.Name })
                   .ToDictionary(t => t.Id, t => t.Name);
        }

        public List<Products> FindProductsinDb(string term)
        {
            List<Products> products = (from product in _db.Products
                where product.Title.ToLower().Contains(term.ToLower())
                select product).ToList();
            return products;
        }

        public List<Price> FindProductPrice(List<Products> product, int storeId)
        {
            List<Price> prices = new List<Price>();

            foreach (var prd in product)
            {
Price price = (from p in _db.Price
                           where p.ProductId == prd.Id && p.StoreId == storeId
                           select p).FirstOrDefault();
                prices.Add(price);
            }

            
            return prices;
        }

        public void Dispose()
        {
            _db.Dispose();
        }


    }
}