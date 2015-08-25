using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using CheckSaver.Models.InputModels;

namespace CheckSaver.Models.Repository
{
    public partial class CheckSaveDbRepository
    {
        //public IQueryable<Transactions> GetTransactions()
        //{
        //    return _db.Transactions;
        //}

        internal IEnumerable<Transactions> GetTransactions()
        {
            return _db.Transactions.Include(x => x.WhoPayNP).Include(x => x.ForWhomNP);
        }

        internal Transactions FindTransactionById(int? id)
        {
            return _db.Transactions.Find(id);
        }

        internal void AddNewTransaction(TransactionsInputModel transactionsInput)
        {
            try
            {
                Transactions t = new Transactions();
                t.Caption = transactionsInput.Caption;
                t.CheckId = transactionsInput.CheckId;
                t.Date = transactionsInput.Date;
                t.ForWhom = transactionsInput.ForWhom;
                t.IsDebitOff = t.IsDebitOff;
                t.Summa = Convert.ToDecimal(transactionsInput.Summa.Replace(".", ","));
                t.WhoPay = transactionsInput.WhoPay;

                _db.Transactions.Add(t);
                _db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                }
            }


        }

        internal void EditTransaction(Transactions transactions)
        {
            _db.Entry(transactions).State = EntityState.Modified;
            _db.SaveChanges();
        }

        internal void RemoveTransaction(int? id)
        {
            Transactions transactions = _db.Transactions.Find(id);
            _db.Transactions.Remove(transactions);
            _db.SaveChanges();
        }

        internal List<string> GetCreditsHistory()
        {
            var neighbours = GetAllNeighbours();
            List<Credit> credits = new List<Credit>();

            foreach (Transactions item in _db.Transactions)
            {
                if (!item.IsDebitOff)
                {
                    var creditCount = (from c in credits where c.From == item.WhoPayNP && c.To == item.ForWhomNP select 1).Count();
                    if(creditCount == 0)
                    {
                        credits.Add(new Credit() { From = item.WhoPayNP, To = item.ForWhomNP });
                    }

                        var credit = (from c in credits where c.From == item.WhoPayNP && c.To == item.ForWhomNP select c).First();
                        credit.Summ.Add(item.Summa);
                }
            }


            List<string> result = new List<string>();
            for (int i = 0; i < credits.Count; i++)
            {
                Credit c = credits[i];
                Credit other = GetAnotherCredit(credits, c);

                if (other != null)
                {
                    if (c.GetSumm() > other.GetSumm())
                        result.Add(string.Format("{0} -> {1} = {2}", other.From.Name, c.From.Name, (c.GetSumm() - other.GetSumm()).ToString("C")));
                    else
                        result.Add(string.Format("{0} -> {1} = {2}", other.To.Name, c.To.Name, (other.GetSumm() - c.GetSumm()).ToString("C")));

                    credits.Remove(other);
                }
                else
                {
                    result.Add(string.Format("{0} -> {1} = {2}", c.To.Name, c.From.Name, c.GetSumm().ToString("C")));
                }
                credits.Remove(c);
                i--;

            }

            return result;
        }

        private Credit GetAnotherCredit(List<Credit> credits, Credit c)
        {
            foreach (var item in credits)
            {
                if (item.From.Name == c.To.Name && item.To.Name == c.From.Name)
                    return item;
            }

            return null;
        }

        private sealed class Credit
        {
            public Neighbours From { get; set; }
            public Neighbours To { get; set; }
            public List<decimal> Summ { get; set; }

            public Credit()
            {
                Summ = new List<decimal>();
            }

            internal decimal GetSumm()
            {
                return Summ.Sum();
            }

            public override bool Equals(object obj)
            {
                Credit c = obj as Credit;

                if (c == null)
                    return false;
                else
                    return From.Name.Equals(c.From.Name) && To.Name.Equals(c.To.Name);

            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }
    }
}