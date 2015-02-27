using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CheckSaver.Models.Repository
{
    public partial class CheckSaveDbRepository :IDisposable
    {
        private CheckSaveEntities _db = new CheckSaveEntities();


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
            List<Product> list = new List<Product>();
            foreach (Product variableProduct in _db.Product)
            {
                if (variableProduct.Name.ToLower().StartsWith(term.ToLower()))
                    //if (storeTitle == "all")
                    //{
                    //    list.Add(variableProduct);
                    //}
                    //else 
                    if (variableProduct.StoreId == Convert.ToInt32(storeId))
                        list.Add(variableProduct);
            }

            return list;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}