using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CheckSaverCore.Invoices
{
    public class WaterRepository : Repository<Water, InvoicesCS>
    {
        public WaterRepository(InvoicesCS context) : base(context)
        {
            DbSet = context.Water;
        }

        public override void Insert(Water item)
        {
            Context.Water.Add(item);
            Context.SaveChanges();
        }

        public override void Delete(int id)
        {
            Water item = GetById(id);
            if (item != null)
            {
                Context.Water.Remove(item);
                Context.SaveChanges();
            }
        }

        public override Water GetById(int id)
        {
            return Context.Water.Find(id);
        }

        public override IQueryable<Water> GetAll()
        {
            return Context.Water;
        }
    }
}