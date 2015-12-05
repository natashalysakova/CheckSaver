using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Globalization;

namespace CheckSaver.Models.Repository
{
    public partial class CheckSaveDbRepository
    {
        internal IEnumerable<Neighbours> GetAllNeighbours()
        {
            return _db.Neighbours.ToList();
        }


        internal Neighbours FindNeighbourById(int? id)
        {
            return _db.Neighbours.Find(id);
        }


        public int AddNewNeighbour(Neighbours Neighbours)
        {
            _db.Neighbours.Add(Neighbours);
            _db.SaveChanges();
            return Neighbours.Id;
        }

        public void EditNeighbour(Neighbours check)
        {
            _db.Entry(check).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void RemoveNeighbour(int id)
        {
            Neighbours Neighbours = _db.Neighbours.Find(id);
            _db.Neighbours.Remove(Neighbours);
            _db.SaveChanges();

        }

        internal List<string> GetMonthPays(int? id)
        {
            Neighbours n = FindNeighbourById(id);

            Dictionary<DateTime, decimal> myPurchase = new Dictionary<DateTime, decimal>();

            foreach (var check in _db.Checks)
            {
                foreach (var purchase in check.Purchases)
                {
                    foreach (var wwuse in purchase.WhoWillUse)
                    {
                        if(wwuse.Neighbours == n)
                        {
                            if (!myPurchase.ContainsKey(check.Date))
                            {
                                myPurchase.Add(check.Date, purchase.CostPerPerson);
                            }
                            else
                            {
                                myPurchase[check.Date] += purchase.CostPerPerson;
                            }
                        }
                    }
                }
            }

            var grouped = (from d in myPurchase orderby d.Key group d by d.Key.Month into t select  CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(t.Key) + ": " + t.Sum(x => x.Value).ToString("C")).ToList();

            return grouped;
        }
    }
}