using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CheckSaverCore.DataModels;

namespace CheckSaverCore.CheckSaver
{
    public sealed class NeigbourRepository : Repository<Neighbour, checkSaverEntities>
    {
        public NeigbourRepository(checkSaverEntities context) : base(context)
        {
            DbSet = Context.Neighbours;
        }

        public override void Insert(Neighbour item)
        {
            Context.Neighbours.Add(item);
            Context.SaveChanges();
        }

        public override void Delete(int id)
        {
            Neighbour item = GetById(id);
            if (item != null)
            {
                Context.Neighbours.Remove(item);
                Context.SaveChanges();
            }

        }

        public override Neighbour GetById(int id)
        {
            return Context.Neighbours.Find(id);
        }

        public override IQueryable<Neighbour> GetAll()
        {
            return Context.Neighbours;
        }

        //public override DbSet<Neighbour> DbSet { get; set; }
    }
}