using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CheckSaver.Models.InputModels;

namespace CheckSaver.Models.Repository
{
    public partial class CheckSaveDbRepository
    {
        public IEnumerable<Check> GetAllChecks()
        {
            return _db.Check.Include(c => c.Neighbor).Include(c => c.Store).ToList();
        }

        internal Check FindCheckById(int? id)
        {
            return _db.Check.Find(id);
        }


        public int AddNewCheck(CheckInputModel check)
        {
            Check tmp = new Check
            {
                DateTime = check.DateTime,
                NeighborId = Convert.ToInt32(check.NeighborId),
                StoreId = Convert.ToInt32(check.StoreId)
            };

            _db.Check.Add(tmp);
            _db.SaveChanges();


            foreach (PurchaseInputModel variableModel in check.Purchases)
            {
                if (variableModel.Count != null)
                {
                    int purchase = CreatePurchases(tmp.Id, Convert.ToInt32(check.StoreId), variableModel);
                    AddWhoWillUse(purchase, variableModel.WhoWillUse);
                }
            }

            tmp.Summ = GetPurchasesSumm(tmp.Purchase);
            _db.Entry(tmp).State = EntityState.Modified;
            _db.SaveChanges();

            return tmp.Id;
        }

        private decimal GetPurchasesSumm(ICollection<Purchase> collection)
        {
            return collection.Sum(variable => variable.Summa);
        }

        public void AddWhoWillUse(int purchaseId, List<object> model)
        {
            if (model != null)
            {
                foreach (object whoWillUseInputModel in model)
                {
                    _db.WhoWillUse.Add(CreateWhoWillUse(whoWillUseInputModel, purchaseId));
                    _db.Currency.Add(CreateCurrency(purchaseId, whoWillUseInputModel, model.Count));
                }
            }
            else
            {
                foreach (Neighbor neighbor in _db.Neighbor)
                {
                    _db.WhoWillUse.Add(CreateWhoWillUse(neighbor.Id, purchaseId));
                    _db.Currency.Add(CreateCurrency(purchaseId, neighbor.Id, _db.Neighbor.Count()));
                }
            }
            _db.SaveChanges();
        }

        private Currency CreateCurrency(int purchaseId, object whoWillUseInputModel, int countInPurchase)
        {
            return CreateCurrency(purchaseId, Convert.ToInt32(whoWillUseInputModel), countInPurchase);
        }

        private Currency CreateCurrency(int purchaseId, int neighborId, int countInPurchase)
        {
            Purchase purchase = _db.Purchase.Find(purchaseId);

            Currency tmp = new Currency()
            {
                NeighborId = neighborId,
                PurchaseId = purchaseId,
                CurrencyPrice = purchase.Summa/countInPurchase
            };

            return tmp;
        }


        private WhoWillUse CreateWhoWillUse(object whoWillUseInputModel, int purchaseId)
        {
            return CreateWhoWillUse(Convert.ToInt32(whoWillUseInputModel), purchaseId);
        }


        private WhoWillUse CreateWhoWillUse(int neighborId, int purchaseId)
        {
            WhoWillUse tmp = new WhoWillUse {NeighborId = neighborId, PurchaseId = purchaseId};
            return tmp;
        }

        public int CreatePurchases(int checkId, int storeId, PurchaseInputModel purchase)
        {
            Purchase tmp = new Purchase {CheckId = checkId};

            Product product = AddNewOrGetExistProduct(purchase.Product, storeId);

            tmp.ProductId = product.Id;

            string forDecimal = purchase.Count.Replace(".", ",");
            tmp.Count = Decimal.Parse(forDecimal);
            tmp.Summa = tmp.Count * product.Price;

            _db.Purchase.Add(tmp);
            _db.SaveChanges();
            return tmp.Id;

        }

        public void EditCheck(Check check)
        {
            _db.Entry(check).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void RemoveCheck(int id)
        {
            Check check = FindCheckById(id);

            while (check.Purchase.Any())
            {
                while (check.Purchase.Last().Currency.Any())
                {
                    _db.Currency.Remove(check.Purchase.Last().Currency.Last());
                }

                while (check.Purchase.Last().WhoWillUse.Any())
                {
                    _db.WhoWillUse.Remove(check.Purchase.Last().WhoWillUse.Last());
                }

                _db.Purchase.Remove(check.Purchase.Last());
            }

            _db.Check.Remove(check);
            _db.SaveChanges();
        }

        internal void RecalculateSummas()
        {
            foreach (Check check in _db.Check)
            {
                check.Summ = GetPurchasesSumm(check.Purchase);
            }

            _db.SaveChanges();
        }
    }
}