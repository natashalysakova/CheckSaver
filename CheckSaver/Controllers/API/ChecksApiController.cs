using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CheckSaver.Models;
using CheckSaver.Models.Repository;
using System.Web.Http.Results;

namespace CheckSaver.Controllers.API
{
    public class ChecksApiController : ApiController
    {
        CheckSaveDbRepository _repository = new CheckSaveDbRepository();
        
        // GET: api/ChecksApi
        public object Get()
        {
            var c =  _repository.GetChecks();
            List<object> answer = new List<object>();
            foreach (Checks item in c)
            {
                answer.Add(new
                {
                    id = item.Id,
                    date = item.Date,
                    neighbour = item.Neighbours.Name,
                    photo = item.Stores.Photo,
                    store = item.Stores.Title,

                });
            }

            return Json(answer);
        }

        // GET: api/ChecksApi/5
        public object Get(int id)
        {
            Checks c = _repository.FindCheckById(id);

            var res = new
            {
                id = c.Id,
                date = c.Date.ToShortDateString(),
                neighbour = c.Neighbours.Name,
                photo = c.Stores.Photo,
                store = c.Stores.Title,

            };
            return Json(res);
        }

        // POST: api/ChecksApi
        public void Post([FromBody]object value)
        {
        }

        // PUT: api/ChecksApi/5
        public void Put(int id, [FromBody]Checks value)
        {

        }

        // DELETE: api/ChecksApi/5
        public void Delete(int id)
        {
            _repository.RemoveCheck(id);
        }
    }
}
