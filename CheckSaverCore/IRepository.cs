using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace CheckSaverCore
{
    interface IRepository<TEntity> : IQueryable, IDisposable where TEntity : class
    {
        void Insert(TEntity item);
        void Update(TEntity item);
        void Delete(int id);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Save();
        int Count { get; }
        //DbSet<TEntity> DbSet { get; set; }
    }
}
