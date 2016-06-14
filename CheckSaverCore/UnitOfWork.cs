using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using CheckSaver.Models;

namespace CheckSaverCore
{
    public class InvoicesWU
    {
        public InvoicesWU(InvoicesCS context)
        {
            Water = new WaterRepository(context);
            Invoices = new InvoicesRepository(context);
        }

        public WaterRepository Water { get; }
        public InvoicesRepository Invoices { get; }

    }

    public class WaterRepository : Repository<Water, InvoicesCS>
    {
        public WaterRepository(InvoicesCS context) : base(context)
        {
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public override void Insert(Water item)
        {
            throw new NotImplementedException();
        }

        public override void Update(Water item)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Water GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Water> GetAll()
        {
            throw new NotImplementedException();
        }
    }

    public class InvoicesRepository : Repository<Invoice, InvoicesCS>
    {
        public InvoicesRepository(InvoicesCS context) : base(context)
        {
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public override void Insert(Invoice item)
        {
            throw new NotImplementedException();
        }

        public override void Update(Invoice item)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Invoice GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Invoice> GetAll()
        {
            return
                Context.Invoice.Include(i => i.Electricity)
                    .Include(i => i.Gas)
                    .Include(i => i.HotWater)
                    .Include(i => i.ColdWater);
        }
    }
}
