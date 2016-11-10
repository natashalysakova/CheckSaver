using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CheckSaver.Models;
using System.Web.Http.Results;
using CheckSaverCore.DataModels;
using CheckSaverCore.CheckSaver;
using CheckSaverCore.DataModels.InputModels;

namespace CheckSaver.Controllers.API
{
    public class ChecksApiController : ApiController
    {
        CheckUnitOfWork unit = new CheckUnitOfWork(new checkSaverEntities());
        // GET: api/ChecksApi
        public object Get()
        {
            var c = unit.GetChecks();
            List<object> answer = new List<object>();
            foreach (Check item in c)
            {
                answer.Add(new
                {
                    id = item.Id,
                    date = item.Date,
                    neighbour = item.Neighbour.Name,
                    photo = item.Stores.Photo,
                    store = item.Stores.Title,

                });
            }

            return Json(answer);
        }

        // GET: api/ChecksApi/5
        public object Get(int id)
        {
            Check c = unit.Checks.GetById(id);
           List<PurchaseInputModel> purchases = new List<PurchaseInputModel>();

            foreach  ( var item in c.Purchases)
            {
                purchases.Add(
                    new PurchaseInputModel()
                    {
                        Id = item.Id,
                        Product = new ProductInputModel()
                        {
                            Name = item.Products.Title,
                            Price = item.Cost.ToString()
                        },
                        Count = item.Count.ToString(),
                        WhoWillUse = item.WhoWillUse.Select(x => x.Neighbours.Name).ToList<object>()
                    });
            }
            

            var res = new
            {
                id = c.Id,
                date = c.Date.ToShortDateString(),
                neighbour = c.Neighbour.Name,
                photo = c.Stores.Photo,
                store = c.Stores.Title,
                purchases = purchases
            };
            return Json(res);
        }

        // POST: api/ChecksApi
        public void Post([FromBody]object value)
        {
            CheckInputModel check = value as CheckInputModel;
            if (check != null)
                unit.Checks.Insert(check);
        }

        // PUT: api/ChecksApi/5
        public void Put([FromBody]Check value)
        {
            unit.Checks.Update(value);
        }

        // DELETE: api/ChecksApi/5
        public void Delete(int id)
        {
            unit.Checks.Delete(id);
        }
    }

    public class NeighbourApiController : ApiController
    {
        CheckUnitOfWork unit = new CheckUnitOfWork(new checkSaverEntities());
        // GET: api/ChecksApi
        public object Get()
        {
            var c = unit.GetNeighborsList();
            return Json(c);
        }

        // GET: api/ChecksApi/5
        public object Get(int id)
        {
            Neighbour c = unit.Neigbours.GetById(id);
            var res = new
            {
                id = c.Id,
                name = c.Name,
                isDefault = c.IsDefault,
                photo = c.Photo
            };
            return Json(res);
        }

        // POST: api/ChecksApi
        public void Post([FromBody]object value)
        {
            Neighbour check = value as Neighbour;
            if (check != null)
                unit.Neigbours.Insert(check);
        }

        // PUT: api/ChecksApi/5
        public void Put([FromBody]Neighbour value)
        {
            unit.Neigbours.Update(value);
        }

        // DELETE: api/ChecksApi/5
        public void Delete(int id)
        {
            unit.Neigbours.Delete(id);
        }
    }

    public class StoresApiController : ApiController
    {
        CheckUnitOfWork unit = new CheckUnitOfWork(new checkSaverEntities());
        // GET: api/ChecksApi
        public object Get()
        {
            var c = unit.GetStoresList();
            return Json(c);
        }

        // GET: api/ChecksApi/5
        public object Get(int id)
        {
            Store c = unit.Stores.GetById(id);
            var res = new
            {
                id = c.Id,
                title = c.Title,
                photo = c.Photo,
                address = c.Address
            };
            return Json(res);
        }

        // POST: api/ChecksApi
        public void Post([FromBody]object value)
        {
            Store check = value as Store;
            if (check != null)
                unit.Stores.Insert(check);
        }

        // PUT: api/ChecksApi/5
        public void Put([FromBody]Store value)
        {
            unit.Stores.Update(value);
        }

        // DELETE: api/ChecksApi/5
        public void Delete(int id)
        {
            unit.Stores.Delete(id);
        }
    }

}
