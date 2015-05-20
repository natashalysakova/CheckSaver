using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CheckSaver.Models;
using CheckSaver.Models.DetailsModels;
using CheckSaver.Models.InputModels;
using CheckSaver.Models.Repository;

namespace CheckSaver.Controllers
{
    public class ChecksController : Controller
    {
        private readonly CheckSaveDbRepository _repository = new CheckSaveDbRepository();

        // GET: Checks
        public ActionResult Index()
        {
            var check = _repository.GetAllChecks();
            return View(check);
        }

        // GET: Checks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Check check = _repository.FindCheckById(id);
            CheckDetailsModel model = new CheckDetailsModel(check);
            if (check == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: Checks/Create
        public ActionResult Create()
        {
            ViewBag.NeighborId = new SelectList(_repository.GetNeighborsList(), "Id", "Name");
            ViewBag.StoreId = new SelectList(_repository.GetStoresList(), "Id", "Title");
            ViewBag.Names = _repository.GetNeighboursNames();
            ViewBag.Index = 0;

            return View();
        }

        // POST: Checks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateTime,StoreId,NeighborId,Purchases")] CheckInputModel check)
        {
            if (ModelState.IsValid)
            {
                int newCheckId = _repository.AddNewCheck(check);
                return RedirectToAction("Details", new { id = newCheckId });
            }

            ViewBag.NeighborId = new SelectList(_repository.GetNeighborsList(), "Id", "Name", check.NeighborId);
            ViewBag.StoreId = new SelectList(_repository.GetStoresList(), "Id", "Title", check.StoreId);
            ViewBag.Names = _repository.GetNeighboursNames();
            ViewBag.Index = 0;

            return View(check);
        }





        // GET: Checks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Check check = _repository.FindCheckById(id);
            if (check == null)
            {
                return HttpNotFound();
            }
            ViewBag.NeighborId = new SelectList(_repository.GetNeighborsList(), "Id", "Name", check.NeighborId);
            ViewBag.StoreId = new SelectList(_repository.GetStoresList(), "Id", "Title", check.StoreId);
            ViewBag.Names = _repository.GetNeighboursNames();
            ViewBag.Index = 0;

            return View(check);
        }

        // POST: Checks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateTime,Summ,StoreId,NeighborId")] Check check)
        {
            if (ModelState.IsValid)
            {
                _repository.EditCheck(check);
                return RedirectToAction("Index");
            }
            ViewBag.NeighborId = new SelectList(_repository.GetNeighborsList(), "Id", "Name", check.NeighborId);
            ViewBag.StoreId = new SelectList(_repository.GetStoresList(), "Id", "Title", check.StoreId);
            ViewBag.Names = _repository.GetNeighboursNames();
            ViewBag.Index = 0;

            return View(check);
        }

        // GET: Checks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Check check = _repository.FindCheckById(id);
            if (check == null)
            {
                return HttpNotFound();
            }
            return View(check);
        }

        // POST: Checks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.RemoveCheck(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult FindProducts(string term, int storeId, string fieldId)
        {
            var products = _repository.FindProductsinDb(term, storeId);

            //if (storeId != "all")
            //{
                var projection = from product in products
                                 select new
                                 {
                                     id = product.Id,
                                     value = product.Name,
                                     price = product.Price,
                                     field = fieldId
                                 };
                return Json(projection.ToList(),
              JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    var projection = from product in products
            //                     select new
            //                     {
            //                         id = product.Id,
            //                         value = string.Format("{0} ({1})", product.Name, product.Store.Title),
            //                         price = product.Price,
            //                         field = fieldId
            //                     };
            //    return Json(projection.ToList(),
            //  JsonRequestBehavior.AllowGet);
            //}


        }

        public ActionResult ProductBox(string index)
        {
            ViewBag.Names = _repository.GetNeighboursNames();
            ViewBag.Index = Convert.ToInt32(index);
            return PartialView("ProductBox");
        }

        public ActionResult Recalc()
        {
            _repository.RecalculateSummas();
            return RedirectToAction("Index");
        }
    }
}
