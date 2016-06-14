using System.Collections.Generic;
using System.Data.Entity;

namespace CheckSaverCore
{
    public abstract class Repository<T,C> where T: class where C : DbContext
    {
        protected readonly C Context;

        protected Repository(C context)
        {
            this.Context = context;
        }
        public abstract void Dispose();

        public abstract void Insert(T item);
        public abstract void Update(T item);
        public abstract void Delete(int id);
        public abstract  T GetById(int id);
        public abstract IEnumerable<T> GetAll();

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}