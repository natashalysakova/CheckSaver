using System;
using System.Collections.Generic;
using CheckSaver.Models;

namespace CheckSaverCore
{
    class StoreRepository : Repository<Stores, CheckSaverContext>
    {
        public StoreRepository(CheckSaverContext context) : base(context)
        {
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public override void Insert(Stores item)
        {
            throw new NotImplementedException();
        }

        public override void Update(Stores item)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Stores GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Stores> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}