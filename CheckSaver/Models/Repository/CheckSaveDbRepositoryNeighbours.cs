using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
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

        internal Dictionary<string, decimal> GetMonthPays(int? id)
        {
            Neighbours n = FindNeighbourById(id);

            Dictionary<string, decimal> myPurchase = new Dictionary<string, decimal>();

            foreach (var check in _db.Checks)
            {
                foreach (var purchase in check.Purchases)
                {
                    foreach (var wwuse in purchase.WhoWillUse)
                    {
                        if (wwuse.Neighbours == n)
                        {
                            string key = check.Date.ToString("yyyy") + check.Date.ToString("MM");
                            key =
                                $"{key.Substring(2, 2)}   {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(key.Substring(4)))}";
                            if (!myPurchase.ContainsKey(key))
                            {
                                myPurchase.Add(key, purchase.CostPerPerson);
                            }
                            else
                            {
                                myPurchase[key] += purchase.CostPerPerson;
                            }
                        }
                    }
                }
            }

            //var grouped = (
            //    from d in myPurchase
            //    orderby d.Key
            //    select $"'{d.Key.Substring(2, 2)} " +
            //           $"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(d.Key.Substring(4)))} : " +
            //           $"{d.Value.ToString("C")}").ToList();

            return myPurchase;
        }

        public Dictionary<string, decimal> Get12MonthPays(int? id)
        {
            Neighbours n = FindNeighbourById(id);

            Dictionary<string, decimal> dictionary = new Dictionary<string, decimal>();

            int year = DateTime.Now.AddMonths(-11).Year;
            int month = DateTime.Now.AddMonths(-11).Month;

            for (int i = 0; i < 12; i++)
            {
                dictionary.Add($"{month.ToString("D2")}/{year}", 0);
                month++;
                if (month > 12)
                {
                    month = 1;
                    year++;
                }
            }

            foreach (var check in _db.Checks)
            {
                foreach (var purchase in check.Purchases)
                {
                    foreach (var wwuse in purchase.WhoWillUse)
                    {
                        if (wwuse.Neighbours == n)
                        {
                            string key = check.Date.ToString("yyyy") + check.Date.ToString("MM");
                            key =
                                $"{key.Substring(4,2)}/{key.Substring(0, 4)}";
                            if (dictionary.ContainsKey(key))
                            {
                                dictionary[key] += purchase.CostPerPerson;
                            }
                        }
                    }
                }
            }

            string[] keys = new string[dictionary.Keys.Count];
            dictionary.Keys.CopyTo(keys, 0);
            decimal[] values = new decimal[dictionary.Values.Count];
            dictionary.Values.CopyTo(values, 0);


            var lastMonth = new Dictionary<string, Decimal>();          
            int start = dictionary.Keys.Count - 12;
            if (start < 0)
                start = 0;

            for (int i = start; i < keys.Length; i++)
            {
                lastMonth.Add(keys[i], Math.Round(values[i], 2));
            }
            return lastMonth;
        }
    }
}