using System;

namespace CheckSaverCore.Invoices
{
    public class InvoiceUnitOfWork 
    {
        public InvoiceUnitOfWork(InvoicesCS context)
        {
            Water = new WaterRepository(context);
            Invoices = new InvoicesRepository(context);
            Electricity = new ElectricityRepository(context);
            FixedPays = new FixedPaysRepository(context);
            Gas = new GasRepository(context);
        }

        public WaterRepository Water { get; }
        public InvoicesRepository Invoices { get; }
        public ElectricityRepository Electricity { get; set; }
        public FixedPaysRepository FixedPays { get; set; }
        public GasRepository Gas { get; set; }

    }
}
