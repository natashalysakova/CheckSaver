using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CheckSaver.Models.Repository
{
    public partial class CheckSaveDbRepository
    {
        internal IEnumerable<Neighbor> GetAllNeighbours()
        {
            return _db.Neighbor.ToList();
        }


        internal Neighbor FindNeighbourById(int? id)
        {
            return _db.Neighbor.Find(id);
        }


        public int AddNewNeighbour(Neighbor neighbor)
        {
            _db.Neighbor.Add(neighbor);
            _db.SaveChanges();
            return neighbor.Id;
        }

        public void EditNeighbour(Neighbor check)
        {
            _db.Entry(check).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void RemoveNeighbour(int id)
        {
            Neighbor neighbor = _db.Neighbor.Find(id);
            _db.Neighbor.Remove(neighbor);
            _db.SaveChanges();

        }
    }
}