using System;
using System.Collections.Generic;
using CheckSaver.Models;

namespace CheckSaverCore
{
    class NeigbourRepository : Repository<Neighbours, CheckSaverContext>
    {
        public NeigbourRepository(CheckSaverContext context) : base(context)
        {
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public override void Insert(Neighbours item)
        {
            throw new NotImplementedException();
        }

        public override void Update(Neighbours item)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Neighbours GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Neighbours> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}