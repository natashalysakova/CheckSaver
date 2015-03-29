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

        public List<Product> FindProductsinDb(string term, string storeId)
        {
            return _db.Product.Where(variableProduct => variableProduct.Name.ToLower().StartsWith(term.ToLower())).Where(variableProduct => variableProduct.StoreId == Convert.ToInt32(storeId)).ToList();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}