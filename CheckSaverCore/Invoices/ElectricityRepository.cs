using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CheckSaverCore.Invoices
{
    public sealed class ElectricityRepository : Repository<Electricity, InvoicesCS>
    {
        public ElectricityRepository(InvoicesCS context) : base(context)
        {
            DbSet = context.Electricity;
        }

        public override void Insert(Electricity item)
        {
            Context.Electricity.Add(item);
            Context.SaveChanges();
        }

        public override void Delete(int id)
        {
            Electricity item = GetById(id);
            if (item != null)
            {
                Context.Electricity.Remove(item);
                Context.SaveChanges();
            }
        }

        public override Electricity GetById(int id)
        {
            return Context.Electricity.Find(id);
        }

        public override IQueryable<Electricity> GetAll()
        {
            return
                Context.Electricity;
        }

        //public override DbSet<Electricity> DbSet { get; set; }
    }
}