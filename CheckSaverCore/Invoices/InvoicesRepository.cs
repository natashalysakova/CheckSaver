using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CheckSaverCore.Invoices
{
    public sealed class InvoicesRepository : Repository<Invoice, InvoicesCS>
    {
        public InvoicesRepository(InvoicesCS context) : base(context)
        {
            DbSet = context.Invoice;
        }

        public override void Insert(Invoice item)
        {
            Context.Invoice.Add(item);
            Context.SaveChanges();
        }

        public override void Delete(int id)
        {
            Invoice item = GetById(id);
            if (item != null)
            {
                Context.Invoice.Remove(item);
                Context.SaveChanges();
            }
        }

        public override Invoice GetById(int id)
        {
            return Context.Invoice.Find(id);
        }

        public override IQueryable<Invoice> GetAll()
        {
            return
                Context.Invoice.Include(i => i.Electricity)
                    .Include(i => i.Gas)
                    .Include(i => i.HotWater)
                    .Include(i => i.ColdWater);
        }
    }
}