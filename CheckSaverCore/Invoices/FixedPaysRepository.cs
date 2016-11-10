using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CheckSaverCore.Invoices
{
    public class FixedPaysRepository : Repository<FixedPays, InvoicesCS>
    {
        public FixedPaysRepository(InvoicesCS context) : base(context)
        {
            DbSet = context.FixedPays;
        }

        public override void Insert(FixedPays item)
        {
            Context.FixedPays.Add(item);
            Context.SaveChanges();
        }

        public override void Delete(int id)
        {
            FixedPays item = GetById(id);
            if (item != null)
            {
                Context.FixedPays.Remove(item);
                Context.SaveChanges();
            }
        }

        public override FixedPays GetById(int id)
        {
            return Context.FixedPays.Find(id);
        }

        public override IQueryable<FixedPays> GetAll()
        {
            return
                Context.FixedPays;
        }
    }
}