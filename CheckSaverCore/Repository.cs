using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CheckSaverCore
{
    public abstract class Repository<T,C> where T: class where C : DbContext
    {
        protected readonly C Context;

        protected Repository(C context)
        {
            Context = context;
        }
        public void Dispose()
        {
            Context.Dispose();
        }

        public abstract void Insert(T item);
        public void Update(T item)
        {
            Context.Entry(item).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public abstract void Delete(int id);
        public abstract  T GetById(int id);
        public abstract IQueryable<T> GetAll();

        public void Save()
        {
            Context.SaveChanges();
        }

        public int Count
        {
            get { return DbSet.Count(); }
        }

        protected DbSet<T> DbSet { get; set; }

    }
}