using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CheckSaver.Models.Repository
{
    public partial class CheckSaveDbRepository :IDisposable
    {
        private CheckSaveCS _db = new CheckSaveCS();


        internal IEnumerable GetStoresList()
        {
            return (from store in _db.Store select new {Id = store.Id, Title = store.Title});
        }

        internal IEnumerable GetNeighborsList()
        {
            return (from neighbor in _db.Neighbor select new { Id = neighbor.Id, Name = neighbor.Name });
        }


        public Dictionary<int, string> GetNeighboursNames()
        {
            return _db.Neighbor.Select(t => new { t.Id, t.Name })
                   .ToDictionary(t => t.Id, t => t.Name);
        }

        public List<Product> FindProductsinDb(string term, int storeId)
        {
            List<Product> products = (from product in _db.Product
                where product.Name.ToLower().StartsWith(term.ToLower()) && product.StoreId == storeId
                select product).ToList();
            return products;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}