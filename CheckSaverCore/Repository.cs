using System.Collections.Generic;
using System.Data.Entity;

namespace CheckSaverCore
{
    abstract class Repository<T,C> where T: class where C : DbContext
    {
        private readonly C _context;

        public Repository(C context)
        {
            this._context = context;
        }
        public abstract void Dispose();

        public abstract void Insert(T item);
        public abstract void Update(T item);
        public abstract void Delete(int id);
        public abstract  T GetById(int id);
        public abstract IEnumerable<T> GetAll();

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}