using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CheckSaver.Models.Repository
{
    public partial class CheckSaveDbRepository
    {
        public IEnumerable<Store> GetAllStores()
        {
            return _db.Store.ToList();
        }

        internal Store FindStoreById(int? id)
        {
            return _db.Store.Find(id);
        }


        public int AddNewStore(Store store)
        {
            _db.Store.Add(store);
            _db.SaveChanges();
            return store.Id;
        }


        public void EditStore(Store store)
        {
            _db.Entry(store).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void RemoveStore(int id)
        {
            Store store = FindStoreById(id);
            _db.Store.Remove(store);
            _db.SaveChanges();
        }
    }
}