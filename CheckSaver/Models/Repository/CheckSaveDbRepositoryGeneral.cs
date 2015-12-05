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
            return (from store in _db.Stores orderby store.Title select new { Id = store.Id, Title = store.Title + " (" + store.Address + ")" });
        }

        internal IEnumerable GetNeighborsList()
        {
            return (from neighbor in _db.Neighbours orderby neighbor.Name select new { Id = neighbor.Id, Name = neighbor.Name });
        }


        public List<NeighbourNames> GetNeighboursNames()
        {

            return (
                from neighbour in _db.Neighbours
                orderby  neighbour.IsDefault descending, neighbour.Name
                select new NeighbourNames { id = neighbour.Id, name = neighbour.Name, isDefault = neighbour.IsDefault }).ToList();
        }

        public class NeighbourNames
        {
            public int id;
            public string name;
            public bool isDefault;
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