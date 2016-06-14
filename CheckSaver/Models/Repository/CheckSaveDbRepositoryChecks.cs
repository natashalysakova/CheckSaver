using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CheckSaver.Models.InputModels;

namespace CheckSaver.Models.Repository
{
    //public partial class CheckSaveDbRepository
    //{
    //    public IEnumerable<Checks> GetChecks(int pageSize, int pageNumber)
    //    {
    //        return _db.Checks.OrderByDescending(x => x.Date).Skip(pageSize * pageNumber).Take(pageSize).Include(c => c.Neighbours).Include(c => c.Stores).ToList();
    //    }

    //    public IEnumerable<Checks> GetChecks()
    //    {
    //        return _db.Checks.ToList();
    //    }

    //    internal int GetChecksCount()
    //    {
    //        return _db.Checks.Count();
    //    }

    //    internal Checks FindCheckById(int? id)
    //    {
    //        return _db.Checks.Find(id);
    //    }


    //    public int AddNewCheck(CheckInputModel check)
    //    {
    //        Checks tmp = new Checks
    //        {
    //            Date = check.Date,
    //            NeighbourId = Convert.ToInt32(check.NeighborId),
    //            StoreId = Convert.ToInt32(check.StoreId),
    //            CreationDate = DateTime.Now
    //        };

    //        _db.Checks.Add(tmp);
    //        _db.SaveChanges();


    //        Dictionary<int, decimal> dictonary = new Dictionary<int, decimal>();
    //        List<int> neighboursFromCheck = new List<int>();


    //        foreach (PurchaseInputModel variableModel in check.Purchases)
    //        {
    //            if (variableModel.Count != null)
    //            {
    //                int purchaseId = CreatePurchases(tmp.Id, Convert.ToInt32(check.StoreId), variableModel);
    //                AddWhoWillUse(purchaseId, variableModel.WhoWillUse);

    //                Purchases purchase = _db.Purchases.Find(purchaseId);
    //                purchase.CostPerPerson = purchase.Summ / purchase.WhoWillUse.Count;

    //                foreach (WhoWillUse user in purchase.WhoWillUse)
    //                {
    //                    if (!neighboursFromCheck.Contains(user.NeighbourId))
    //                    {
    //                        neighboursFromCheck.Add(user.NeighbourId);
    //                    }

    //                    if (!dictonary.ContainsKey(user.NeighbourId))
    //                    {
    //                        dictonary.Add(user.NeighbourId, purchase.CostPerPerson);
    //                    }
    //                    else
    //                    {
    //                        dictonary[user.NeighbourId] += purchase.CostPerPerson;
    //                    }
    //                }

    //                _db.Entry(purchase).State = EntityState.Modified;
    //            }
    //        }

    //        _db.Entry(tmp).State = EntityState.Modified;


    //        AddTransactions(neighboursFromCheck, tmp, dictonary);


    //        _db.SaveChanges();

    //        return tmp.Id;
    //    }

    //    private decimal GetPurchasesSumm(ICollection<Purchases> collection)
    //    {
    //        return collection.Sum(variable => variable.Cost);
    //    }

    //    public void AddWhoWillUse(int purchaseId, List<object> model)
    //    {
    //        if (model != null)
    //        {
    //            foreach (object whoWillUseInputModel in model)
    //            {
    //                _db.WhoWillUse.Add(CreateWhoWillUse(whoWillUseInputModel, purchaseId));
    //            }
    //        }
    //        else
    //        {
    //            foreach (Neighbours neighbor in _db.Neighbours)
    //            {
    //                if(neighbor.IsDefault)
    //                    _db.WhoWillUse.Add(CreateWhoWillUse(neighbor.Id, purchaseId));
    //            }
    //        }
    //        _db.SaveChanges();
    //    }

    //    private WhoWillUse CreateWhoWillUse(object whoWillUseInputModel, int purchaseId)
    //    {
    //        return CreateWhoWillUse(Convert.ToInt32(whoWillUseInputModel), purchaseId);
    //    }


    //    private WhoWillUse CreateWhoWillUse(int neighborId, int purchaseId)
    //    {
    //        WhoWillUse tmp = new WhoWillUse { NeighbourId = neighborId, PurchaseId = purchaseId };
    //        return tmp;
    //    }

    //    public int CreatePurchases(int checkId, int storeId, PurchaseInputModel purchase)
    //    {
    //        Purchases tmp = new Purchases { CheckId = checkId };

    //        Products product = AddNewOrGetExistProduct(purchase.Product);
    //        Price price = AddNewOrGetExistPrice(product, storeId);
    //        tmp.Cost = Convert.ToDecimal(purchase.Product.Price.Replace(".", ","));



    //        if (price.Cost != 0)
    //        {
    //            product.Price.Add(new Price() { Cost = tmp.Cost, Date = DateTime.Now, ProductId = product.Id, StoreId = storeId });
    //            _db.Entry(price).State = EntityState.Modified;
    //        }
    //        else
    //        {
    //            price.Cost = tmp.Cost;
    //        }

    //        tmp.ProductId = product.Id;

    //        string forDecimal = purchase.Count.Replace(".", ",");
    //        tmp.Count = Convert.ToDecimal(forDecimal);
    //        tmp.Summ = tmp.Count * tmp.Cost;

    //        _db.Purchases.Add(tmp);
    //        _db.SaveChanges();
    //        return tmp.Id;

    //    }

    //    public void EditCheck(CheckInputModel model)
    //    {

    //        Checks c = FindCheckById(model.Id);
    //        if (c == null)
    //            return;

    //        List<int> neighboursFromCheck = new List<int>();
    //        Dictionary<int, decimal> dictonary = new Dictionary<int, decimal>();


    //        c.Date = model.Date;
    //        c.NeighbourId = int.Parse(model.NeighborId);
    //        c.StoreId = int.Parse(model.StoreId);

    //        foreach (PurchaseInputModel purchaseInput in model.Purchases)
    //        {
    //            if(purchaseInput.Product.Name == null)
    //                continue;

    //            Purchases purchases = _db.Purchases.Find(purchaseInput.Id);
    //            if (purchases == null)
    //            {
    //                purchases = new Purchases();
    //                UpdatePurchase(purchases, c, purchaseInput);
    //                c.Purchases.Add(purchases);
    //            }
    //            else
    //            {
    //                while (purchases.WhoWillUse.Any())
    //                {
    //                    _db.WhoWillUse.Remove(purchases.WhoWillUse.Last());
    //                }

    //                UpdatePurchase(purchases, c, purchaseInput);
    //                _db.Entry(purchases).State = EntityState.Modified;
    //            }



    //            foreach (WhoWillUse user in purchases.WhoWillUse)
    //            {
    //                if (!neighboursFromCheck.Contains(user.NeighbourId))
    //                {
    //                    neighboursFromCheck.Add(user.NeighbourId);
    //                }

    //                if (!dictonary.ContainsKey(user.NeighbourId))
    //                {
    //                    dictonary.Add(user.NeighbourId, purchases.CostPerPerson);
    //                }
    //                else
    //                {
    //                    dictonary[user.NeighbourId] += purchases.CostPerPerson;
    //                }
    //            }

    //        }

    //        while (c.Transactions.Any())
    //        {
    //            _db.Transactions.Remove(c.Transactions.Last());
    //        }

    //        AddTransactions(neighboursFromCheck, c, dictonary);


    //        _db.SaveChanges();
    //    }

    //    private void AddTransactions(List<int> neighboursFromCheck, Checks c, Dictionary<int, decimal> dictonary)
    //    {
    //        foreach (int neighbour in neighboursFromCheck)
    //        {
    //            if (neighbour != c.NeighbourId)
    //            {
    //                Transactions t = new Transactions { Caption = string.Format("За чек  #{0}", c.Id), Date = c.Date, WhoPay = c.NeighbourId, IsDebitOff = false, ForWhom = neighbour, Summa = dictonary[neighbour], CheckId = c.Id };


    //                _db.Transactions.Add(t);
    //            }
    //        }
    //    }

    //    private void UpdatePurchase(Purchases purchases, Checks c, PurchaseInputModel purchaseInput)
    //    {
    //        purchases.CheckId = c.Id;
    //        purchases.Cost = Convert.ToDecimal(purchaseInput.Product.Price.Replace('.', ','));
    //        purchases.Count = Convert.ToDecimal(purchaseInput.Count.Replace('.', ','));
    //        purchases.Summ = purchases.Cost*purchases.Count;

    //        if (purchaseInput.WhoWillUse == null)
    //        {
    //            foreach (Neighbours neighbour in _db.Neighbours)
    //            {
    //                if(neighbour.IsDefault)
    //                    purchases.WhoWillUse.Add(new WhoWillUse() {NeighbourId = neighbour.Id, Purchases = purchases});
    //            }
    //        }
    //        else
    //        {
    //            foreach (object whoWillUseInputModel in purchaseInput.WhoWillUse)
    //            {
    //                purchases.WhoWillUse.Add(new WhoWillUse()
    //                {
    //                    NeighbourId = Convert.ToInt32(whoWillUseInputModel),
    //                    Purchases = purchases
    //                });
    //            }
    //        }


    //        purchases.CostPerPerson = purchases.Summ/purchases.WhoWillUse.Count;
    //        purchases.Products = AddNewOrGetExistProduct(purchaseInput.Product);
    //    }

    //    public void RemoveCheck(int id)
    //    {
    //        Checks check = FindCheckById(id);

    //        while (check.Purchases.Any())
    //        {
    //            while (check.Purchases.Last().WhoWillUse.Any())
    //            {
    //                _db.WhoWillUse.Remove(check.Purchases.Last().WhoWillUse.Last());
    //            }
    //            _db.Purchases.Remove(check.Purchases.Last());
    //        }

    //        while (check.Transactions.Any())
    //        {
    //            _db.Transactions.Remove(check.Transactions.Last());
    //        }

    //        _db.Checks.Remove(check);
    //        _db.SaveChanges();
    //    }

    //}
}