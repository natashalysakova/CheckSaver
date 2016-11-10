using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using CheckSaverCore.DataModels;
using CheckSaverCore.DataModels.InputModels;

namespace CheckSaverCore.CheckSaver
{
    public sealed class CheckRepository : Repository<Check, checkSaverEntities>
    {
        public CheckRepository(checkSaverEntities context) : base(context)
        {
            DbSet = context.Checks;
        }

        
        public override void Insert(Check item)
        {
            Context.Checks.Add(item);
            Context.SaveChanges();
        }

        public int Insert(CheckInputModel check)
        {
            Check tmp = new Check
            {
                Date = check.Date,
                NeighbourId = Convert.ToInt32(check.NeighborId),
                StoreId = Convert.ToInt32(check.StoreId),
                CreationDate = DateTime.Now
            };

            Context.Checks.Add(tmp);
            Context.SaveChanges();


            Dictionary<int, decimal> dictonary = new Dictionary<int, decimal>();
            List<int> neighboursFromCheck = new List<int>();


            foreach (PurchaseInputModel variableModel in check.Purchases)
            {
                if (variableModel.Count != null)
                {
                    int purchaseId = CreatePurchases(tmp.Id, Convert.ToInt32(check.StoreId), variableModel);
                    AddWhoWillUse(purchaseId, variableModel.WhoWillUse);

                    Purchase purchase = Context.Purchases.Find(purchaseId);
                    purchase.CostPerPerson = purchase.Summ / purchase.WhoWillUse.Count;

                    foreach (WhoWillUse user in purchase.WhoWillUse)
                    {
                        if (!neighboursFromCheck.Contains(user.NeighbourId))
                        {
                            neighboursFromCheck.Add(user.NeighbourId);
                        }

                        if (!dictonary.ContainsKey(user.NeighbourId))
                        {
                            dictonary.Add(user.NeighbourId, purchase.CostPerPerson);
                        }
                        else
                        {
                            dictonary[user.NeighbourId] += purchase.CostPerPerson;
                        }
                    }

                    Context.Entry(purchase).State = EntityState.Modified;
                }
            }

            Context.Entry(tmp).State = EntityState.Modified;


            AddTransactions(neighboursFromCheck, tmp, dictonary);


            Context.SaveChanges();

            return tmp.Id;
    }
        private void AddTransactions(List<int> neighboursFromCheck, Check c, Dictionary<int, decimal> dictonary)
        {
            foreach (int neighbour in neighboursFromCheck)
            {
                if (neighbour != c.NeighbourId)
                {
                    Transaction t = new Transaction { Caption = string.Format("За чек  #{0}", c.Id), Date = c.Date, WhoPay = c.NeighbourId, IsDebitOff = false, ForWhom = neighbour, Summa = dictonary[neighbour], CheckId = c.Id };


                    Context.Transactions.Add(t);
                }
            }
        }
        private int CreatePurchases(int checkId, int storeId, PurchaseInputModel purchase)
        {
            Purchase tmp = new Purchase { CheckId = checkId };

            Product product = AddNewOrGetExistProduct(purchase.Product);
            Price price = AddNewOrGetExistPrice(product, storeId);
            tmp.Cost = Convert.ToDecimal(purchase.Product.Price.Replace(".", ","));



            if (price.Cost != 0)
            {
                product.Price.Add(new Price() { Cost = tmp.Cost, Date = DateTime.Now, ProductId = product.Id, StoreId = storeId });
                Context.Entry(price).State = EntityState.Modified;
            }
            else
            {
                price.Cost = tmp.Cost;
            }

            tmp.ProductId = product.Id;

            string forDecimal = purchase.Count.Replace(".", ",");
            tmp.Count = Convert.ToDecimal(forDecimal);
            tmp.Summ = tmp.Count * tmp.Cost;

            Context.Purchases.Add(tmp);
            Context.SaveChanges();
            return tmp.Id;

        }

        private Price AddNewOrGetExistPrice(Product product, int storeId)
        {
            Price exist = (from price in Context.Prices where price.ProductId == product.Id && price.StoreId == storeId orderby price.Date select price).FirstOrDefault();

            if (exist == null)
            {
                exist = new Price { ProductId = product.Id, StoreId = storeId, Date = DateTime.Now, Cost = 0 };
                Context.Prices.Add(exist);
                Context.SaveChanges();
            }

            return exist;
        }

        public Product AddNewOrGetExistProduct(ProductInputModel product)
        {
            Product exist = (from p in Context.Products where p.Title == product.Name select p).FirstOrDefault();

            if (exist == null)
            {
                exist = new Product { Title = product.Name };
                Context.Products.Add(exist);
                Context.SaveChanges();
            }

            return exist;
        }

        public void AddWhoWillUse(int purchaseId, List<object> model)
        {
            if (model != null)
            {
                foreach (object whoWillUseInputModel in model)
                {
                    Context.WhoWillUses.Add(CreateWhoWillUse(whoWillUseInputModel, purchaseId));
                }
            }
            else
            {
                foreach (Neighbour neighbor in Context.Neighbours)
                {
                    if(neighbor.IsDefault)
                        Context.WhoWillUses.Add(CreateWhoWillUse(neighbor.Id, purchaseId));
                }
            }
            Context.SaveChanges();
        }

        private WhoWillUse CreateWhoWillUse(object whoWillUseInputModel, int purchaseId)
        {
            return CreateWhoWillUse(Convert.ToInt32(whoWillUseInputModel), purchaseId);
        }


        private WhoWillUse CreateWhoWillUse(int neighborId, int purchaseId)
        {
            WhoWillUse tmp = new WhoWillUse { NeighbourId = neighborId, PurchaseId = purchaseId };
            return tmp;
        }

        public override void Delete(int id)
        {
            Check item = GetById(id);
            if (item != null)
            {
                Context.Checks.Remove(item);
                Context.SaveChanges();
            }

        }

        public override Check GetById(int id)
        {
            return Context.Checks.Find(id);
        }

        public override IQueryable<Check> GetAll()
        {
            return Context.Checks.Include(x => x.Purchases).Include(x => x.Stores);
        }

        //public override DbSet<Check> DbSet { get; set; }
    }
}