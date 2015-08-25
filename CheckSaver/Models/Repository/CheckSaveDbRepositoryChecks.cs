using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CheckSaver.Models.InputModels;

namespace CheckSaver.Models.Repository
{
    public partial class CheckSaveDbRepository
    {
        public IEnumerable<Checks> GetAllChecks()
        {
            return _db.Checks.Include(c => c.Neighbours).Include(c => c.Stores).ToList();
        }

        internal Checks FindCheckById(int? id)
        {
            return _db.Checks.Find(id);
        }


        public int AddNewCheck(CheckInputModel check)
        {
            Checks tmp = new Checks
            {
                Date = check.DateTime,
                NeighbourId = Convert.ToInt32(check.NeighborId),
                StoreId = Convert.ToInt32(check.StoreId)
            };

            _db.Checks.Add(tmp);
            _db.SaveChanges();


            Dictionary<int, decimal> dictonary = new Dictionary<int, decimal>();
            List<int> neighboursFromCheck= new List<int>();


            foreach (PurchaseInputModel variableModel in check.Purchases)
            {
                if (variableModel.Count != null)
                {
                    int purchaseId = CreatePurchases(tmp.Id, Convert.ToInt32(check.StoreId), variableModel);
                    AddWhoWillUse(purchaseId, variableModel.WhoWillUse);

                    Purchases purchase = _db.Purchases.Find(purchaseId);
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

                    _db.Entry(purchase).State = EntityState.Modified;
                }
            }

            _db.Entry(tmp).State = EntityState.Modified;


            foreach (int neighbour in neighboursFromCheck)
            {
                if(neighbour!= tmp.NeighbourId)
                {
                    Transactions t = new Transactions { Caption = string.Format("From Check {0} - {1}", tmp.Id, tmp.Date.ToShortDateString()), Date = tmp.Date, WhoPay = tmp.NeighbourId, IsDebitOff = false, ForWhom = neighbour, Summa = dictonary[neighbour], CheckId = tmp.Id};

                    _db.Transactions.Add(t);
                }
            }
            

            _db.SaveChanges();

            return tmp.Id;
        }

        private decimal GetPurchasesSumm(ICollection<Purchases> collection)
        {
            return collection.Sum(variable => variable.Cost);
        }

        public void AddWhoWillUse(int purchaseId, List<object> model)
        {
            if (model != null)
            {
                foreach (object whoWillUseInputModel in model)
                {
                    _db.WhoWillUse.Add(CreateWhoWillUse(whoWillUseInputModel, purchaseId));
                }
            }
            else
            {
                foreach (Neighbours neighbor in _db.Neighbours)
                {
                    _db.WhoWillUse.Add(CreateWhoWillUse(neighbor.Id, purchaseId));
                }
            }
            _db.SaveChanges();
        }

        private WhoWillUse CreateWhoWillUse(object whoWillUseInputModel, int purchaseId)
        {
            return CreateWhoWillUse(Convert.ToInt32(whoWillUseInputModel), purchaseId);
        }


        private WhoWillUse CreateWhoWillUse(int neighborId, int purchaseId)
        {
            WhoWillUse tmp = new WhoWillUse {NeighbourId = neighborId, PurchaseId = purchaseId};
            return tmp;
        }

        public int CreatePurchases(int checkId, int storeId, PurchaseInputModel purchase)
        {
            Purchases tmp = new Purchases {CheckId = checkId};

            Products product = AddNewOrGetExistProduct(purchase.Product);
            Price price = AddNewOrGetExistPrice(product, storeId);
            tmp.Cost = Convert.ToDecimal(purchase.Product.Price.Replace(".", ","));



            if (price.Cost != 0)
            {
                product.Price.Add(new Price() { Cost = tmp.Cost, Date = DateTime.Now, ProductId = product.Id, StoreId = storeId });
                _db.Entry(price).State = EntityState.Modified;
            }
            else
            {
                price.Cost = tmp.Cost;
            }

            tmp.ProductId = product.Id;

            string forDecimal = purchase.Count.Replace(".", ",");
            tmp.Count = Convert.ToDecimal(forDecimal);
            tmp.Summ = tmp.Count * tmp.Cost;

            _db.Purchases.Add(tmp);
            _db.SaveChanges();
            return tmp.Id;

        }

        public void UpdateCheck(Checks check)
        {
            Dictionary<int, decimal> dictonary = new Dictionary<int, decimal>();
            List<int> neighboursFromCheck = new List<int>();

            foreach (var item in check.Purchases)
            {

                Price price = AddNewOrGetExistPrice(item.Products, check.StoreId);

                item.Cost = price.Cost;
                item.Summ = item.Cost * item.Count;
                item.CostPerPerson = item.Summ / item.WhoWillUse.Count();


                foreach (WhoWillUse user in item.WhoWillUse)
                {
                    if (!neighboursFromCheck.Contains(user.NeighbourId))
                    {
                        neighboursFromCheck.Add(user.NeighbourId);
                    }

                    if (!dictonary.ContainsKey(user.NeighbourId))
                    {
                        dictonary.Add(user.NeighbourId, item.CostPerPerson);
                    }
                    else
                    {
                        dictonary[user.NeighbourId] += item.CostPerPerson;
                    }
                }
            }

            while (check.Transactions.Any())
            {
                _db.Transactions.Remove(check.Transactions.Last());
            }

            foreach (int neighbour in neighboursFromCheck)
            {
                if (neighbour != check.NeighbourId)
                {
                    Transactions t = new Transactions { Caption = string.Format("From Check {0} - {1}", check.Id, check.Date.ToShortDateString()), Date = check.Date, WhoPay = check.NeighbourId, IsDebitOff = false, ForWhom = neighbour, Summa = dictonary[neighbour] };

                    _db.Transactions.Add(t);
                }
            }


            _db.Entry(check).State = EntityState.Modified;
            _db.SaveChanges();
        }





        public void EditCheck(CheckInputModel model)
        {
            //Checks check = FindCheckById(model.Id);
            //if (check == null)
            //    return;

            //check.Date = check.Date;
            //check.NeighbourId = Convert.ToInt32(check.NeighbourId);
            //check.StoreId = Convert.ToInt32(check.StoreId);

            //_db.Entry(check).State = EntityState.Modified;
            //_db.SaveChanges();


            //Dictionary<int, decimal> dictonary = new Dictionary<int, decimal>();
            //List<int> neighboursFromCheck = new List<int>();


            //foreach (PurchaseInputModel variableModel in model.Purchases)
            //{
            //    if (variableModel.Count != null)
            //    {
            //        int purchaseId = CreatePurchases(tmp.Id, Convert.ToInt32(check.StoreId), variableModel);
            //        AddWhoWillUse(purchaseId, variableModel.WhoWillUse);

            //        Purchases purchase = _db.Purchases.Find(purchaseId);
            //        purchase.CostPerPerson = purchase.Summ / purchase.WhoWillUse.Count;

            //        foreach (WhoWillUse user in purchase.WhoWillUse)
            //        {
            //            if (!neighboursFromCheck.Contains(user.NeighbourId))
            //            {
            //                neighboursFromCheck.Add(user.NeighbourId);
            //            }

            //            if (!dictonary.ContainsKey(user.NeighbourId))
            //            {
            //                dictonary.Add(user.NeighbourId, purchase.CostPerPerson);
            //            }
            //            else
            //            {
            //                dictonary[user.NeighbourId] += purchase.CostPerPerson;
            //            }
            //        }

            //        _db.Entry(purchase).State = EntityState.Modified;
            //    }
            //}

            //_db.Entry(tmp).State = EntityState.Modified;


            //foreach (int neighbour in neighboursFromCheck)
            //{
            //    if (neighbour != tmp.NeighbourId)
            //    {
            //        Transactions t = new Transactions { Caption = string.Format("From Check {0} - {1}", tmp.Id, tmp.Date.ToShortDateString()), Date = tmp.Date, FromNeighbourId = tmp.NeighbourId, IsDebitOff = false, ToNeighbourId = neighbour, Summa = dictonary[neighbour] };

            //        _db.Transactions.Add(t);
            //    }
            //}


            //_db.SaveChanges();

            //_db.Entry(check).State = EntityState.Modified;
            //_db.SaveChanges();
        }

        public void RemoveCheck(int id)
        {
            Checks check = FindCheckById(id);

            while (check.Purchases.Any())
            {
                //while (check.Purchases.Last().Currency.Any())
                //{
                //    _db.Currency.Remove(check.Purchases.Last().Currency.Last());
                //}

                while (check.Purchases.Last().WhoWillUse.Any())
                {
                    _db.WhoWillUse.Remove(check.Purchases.Last().WhoWillUse.Last());
                }
                _db.Purchases.Remove(check.Purchases.Last());
            }

            while(check.Transactions.Any())
            {
                _db.Transactions.Remove(check.Transactions.Last());
            }

            _db.Checks.Remove(check);
            _db.SaveChanges();
        }

        //internal void RecalculateSummas()
        //{
        //    foreach (Checks check in _db.Checks)
        //    {
        //        check.Summ = GetPurchasesSumm(check.Purchase);
        //    }

        //    _db.SaveChanges();
        //}
    }
}