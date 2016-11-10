using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CheckSaverCore.DataModels;

namespace CheckSaverCore.CheckSaver
{
    public sealed class StoreRepository : Repository<Store, checkSaverEntities>
    {
        public StoreRepository(checkSaverEntities context) : base(context)
        {
            DbSet = Context.Stores;
        }

        public override void Insert(Store item)
        {
            Context.Stores.Add(item);
            Context.SaveChanges();
        }

        public override void Delete(int id)
        {
            Store item = GetById(id);
            if (item != null)
            {
                Context.Stores.Remove(item);
                Context.SaveChanges();
            }

        }

        public override Store GetById(int id)
        {
            return Context.Stores.Find(id);
        }

        public override IQueryable<Store> GetAll()
        {
            return Context.Stores;
        }

        //public override DbSet<Store> DbSet { get; set; }
    }
}