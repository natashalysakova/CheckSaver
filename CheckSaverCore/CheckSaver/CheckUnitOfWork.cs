using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using CheckSaverCore.DataModels;

namespace CheckSaverCore.CheckSaver
{
    public class CheckUnitOfWork
    {
        public CheckUnitOfWork(checkSaverEntities context)
        {
            Checks = new CheckRepository(context);
            Stores = new StoreRepository(context);
            Neigbours = new NeigbourRepository(context);
            WhoWillUse = new WhoWillUseRepository(context);
        }

        public IQueryable GetChecks()
        {
            return Checks.GetAll().OrderByDescending(x => x.Date).
                Include(c => c.Neighbour).
                Include(c => c.Stores);
        }

        public CheckRepository Checks { get; set; }
        public StoreRepository Stores { get; set; }
        public NeigbourRepository Neigbours { get; set; }
        public WhoWillUseRepository WhoWillUse { get; set; }


        public IEnumerable<Check> GetChecks(int pageSize, int pageNum)
        {
            return Checks.GetAll().OrderByDescending(x => x.Date).
                Skip(pageSize * pageNum).
                Take(pageSize).
                Include(c => c.Neighbour).
                Include(c => c.Stores).ToList();
        }

        public int GetChecksCount()
        {
            return Checks.Count;
        }

        public IEnumerable GetNeighborsList()
        {
            return (from neighbor in Neigbours.GetAll() orderby neighbor.Name select new { Id = neighbor.Id, Name = neighbor.Name });
        }

        public IEnumerable GetStoresList()
        {
            return (from store in Stores.GetAll() orderby store.Title select new { Id = store.Id, Title = store.Title + " (" + store.Address + ")" });
        }

        public IEnumerable GetNeighboursNames()
        {
            return (
                from neighbour in Neigbours.GetAll()
                orderby neighbour.IsDefault descending, neighbour.Name
                select neighbour).ToList();
        }
    }
}
