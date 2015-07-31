using System;
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
            return (from store in _db.n_Stores select new {Id = store.Id, Title = store.Title});
        }

        internal IEnumerable GetNeighborsList()
        {
            return (from neighbor in _db.n_Neighbours select new { Id = neighbor.Id, Name = neighbor.Name });
        }


        public Dictionary<int, string> GetNeighboursNames()
        {
            return _db.n_Neighbours.Select(t => new { t.Id, t.Name })
                   .ToDictionary(t => t.Id, t => t.Name);
        }

        public List<n_Products> FindProductsinDb(string term, int storeId)
        {
            List<n_Products> products = (from product in _db.n_Products
                where product.Title.ToLower().StartsWith(term.ToLower())
                select product).ToList();
            return products;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}