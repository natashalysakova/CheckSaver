using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CheckSaverCore.Invoices
{
    public sealed class GasRepository : Repository<Gas, InvoicesCS>
    {
        public GasRepository(InvoicesCS context) : base(context)
        {
            DbSet = Context.Gas;
        }

        public override void Insert(Gas item)
        {
            Context.Gas.Add(item);
            Context.SaveChanges();
        }

        public override void Delete(int id)
        {
            Gas item = GetById(id);
            if (item != null)
            {
                Context.Gas.Remove(item);
                Context.SaveChanges();
            }
        }

        public override Gas GetById(int id)
        {
            return Context.Gas.Find(id);
        }

        public override IQueryable<Gas> GetAll()
        {
            return
                Context.Gas;
        }

        //public override DbSet<Gas> DbSet { get; set; }
    }
}