namespace CheckSaverCore.tmp.Repository
{
    public partial class CheckSaveDbRepository
    {
        //internal IEnumerable<Neighbours> GetAllNeighbours()
        //{
        //    return _db.Neighbours.ToList();
        //}


        //internal Neighbours FindNeighbourById(int? id)
        //{
        //    return _db.Neighbours.Find(id);
        //}


        //public int AddNewNeighbour(Neighbours Neighbours)
        //{
        //    _db.Neighbours.Add(Neighbours);
        //    _db.SaveChanges();
        //    return Neighbours.Id;
        //}

        //public void EditNeighbour(Neighbours check)
        //{
        //    _db.Entry(check).State = EntityState.Modified;
        //    _db.SaveChanges();
        //}

        //public void RemoveNeighbour(int id)
        //{
        //    Neighbours Neighbours = _db.Neighbours.Find(id);
        //    _db.Neighbours.Remove(Neighbours);
        //    _db.SaveChanges();

        //}

        //internal List<string> GetMonthPays(int? id)
        //{
        //    Neighbours n = FindNeighbourById(id);

        //    Dictionary<string, decimal> myPurchase = new Dictionary<string, decimal>();

        //    foreach (var check in _db.Checks)
        //    {
        //        foreach (var purchase in check.Purchases)
        //        {
        //            foreach (var wwuse in purchase.WhoWillUse)
        //            {
        //                if (wwuse.Neighbours == n)
        //                {
        //                    string key = check.Date.ToString("yyyy") + check.Date.ToString("MM");
        //                    if (!myPurchase.ContainsKey(key))
        //                    {
        //                        myPurchase.Add(key, purchase.CostPerPerson);
        //                    }
        //                    else
        //                    {
        //                        myPurchase[key] += purchase.CostPerPerson;
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    var grouped = (from d in myPurchase orderby d.Key select $"'{d.Key.Substring(2, 2)} {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(d.Key.Substring(4)))} : {d.Value.ToString("C")}").ToList();

        //    return grouped;
        //}
    }
}