using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.UI.WebControls;
using CheckSaverCore.DataModels;

namespace CheckSaverCore.CheckSaver
{
    public class WhoWillUseRepository : Repository<WhoWillUse, checkSaverEntities>
    {
        public WhoWillUseRepository(checkSaverEntities context) : base(context)
        {
        }

        public override void Insert(WhoWillUse item)
        {
            throw new System.NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public override WhoWillUse GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public override IQueryable<WhoWillUse> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}