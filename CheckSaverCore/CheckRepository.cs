using System;
using System.Collections.Generic;
using CheckSaver.Models;

namespace CheckSaverCore
{
    class CheckRepository : Repository<Checks, CheckSaverContext>
    {
        public CheckRepository(CheckSaverContext context) : base(context)
        {
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public override void Insert(Checks item)
        {
            throw new NotImplementedException();
        }

        public override void Update(Checks item)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Checks GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Checks> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}