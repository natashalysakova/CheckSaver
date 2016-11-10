using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CheckSaverCore.CheckSaver;
using CheckSaverCore.DataModels;
using CheckSaverCore.DataModels.InputModels;

namespace CheckSaver.Controllers
{
    public class ChecksController : Controller
    {
        CheckUnitOfWork unit = new CheckUnitOfWork(new checkSaverEntities());
        private int pageSize = 12;

        // GET: Checks
        public ActionResult Index(int pageNum = 0)
        {
            var check = unit.GetChecks(pageSize, pageNum);
            ViewData["PageNum"] = pageNum;
            ViewData["PageCount"] = unit.GetChecksCount() / pageSize;


            if (Request.IsAjaxRequest())
            {
                return PartialView("_checks", check);
            }
            else
            {
                return View(check);
            }
        }

        //public ActionResult Update(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CheckSaver.Checks check = _repository.FindCheckById(id);
        //    //CheckDetailsModel model = new CheckDetailsModel(check);
        //    if (check == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    ///_repository.UpdateCheck(check);

        //    return RedirectToAction("Details", new { id = check.Id });
        //}


        // GET: Checks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Check check = unit.Checks.GetById(id.Value);

            if (check == null)
            {
                return HttpNotFound();
            }

            Dictionary<Neighbour, decimal> dictonary = new Dictionary<Neighbour, decimal>();

            foreach (Purchase purchase in check.Purchases)
            {
                string summary = string.Empty;
                foreach (WhoWillUse VARIABLE in purchase.WhoWillUse)
                {
                    summary += VARIABLE.Neighbours.Name + ",";
                    if (!dictonary.ContainsKey(VARIABLE.Neighbours))
                    {
                        dictonary.Add(VARIABLE.Neighbours, purchase.CostPerPerson);
                    }
                    else
                    {
                        dictonary[VARIABLE.Neighbours] += purchase.CostPerPerson;
                    }
                }

            }

            List<KeyValuePair<Neighbour, decimal>> TotalList = dictonary.ToList();

            ViewBag.Summary = TotalList;
            return View(check);
        }

        // GET: Checks/Create
        public ActionResult Create()
        {
            ViewBag.NeighborId = new SelectList(unit.GetNeighborsList(), "Id", "Name");
            ViewBag.StoreId = new SelectList(unit.GetStoresList(), "Id", "Title");
            ViewBag.Names = unit.GetNeighboursNames();
            ViewBag.Index = 0;

            return View();
        }

        // POST: Checks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CheckInputModel check)
        {
            if (ModelState.IsValid)
            {
                int newCheckId = unit.Checks.Insert(check);
                return RedirectToAction("Details", new { id = newCheckId });
            }

            ViewBag.NeighborId = new SelectList(unit.GetNeighborsList(), "Id", "Name", check.NeighborId);
            ViewBag.StoreId = new SelectList(unit.GetStoresList(), "Id", "Title", check.StoreId);
            ViewBag.Names = unit.GetNeighboursNames();
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
            Check check = unit.Checks.GetById(id.Value);
            if (check == null)
            {
                return HttpNotFound();
            }
            ViewBag.NeighborId = new SelectList(unit.GetNeighborsList(), "Id", "Name", check.NeighbourId);
            ViewBag.StoreId = new SelectList(unit.GetStoresList(), "Id", "Title", check.StoreId);
            ViewBag.Names = unit.GetNeighboursNames();
            ViewBag.Index = 0;

            return View(check);
        }

        //// POST: Checks/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(CheckInputModel check)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _repository.EditCheck(check);
        //        return RedirectToAction("Details", new { id = check.Id });
        //    }

        //    ViewBag.NeighborId = new SelectList(_repository.GetNeighborsList(), "Id", "Name", check.NeighborId);
        //    ViewBag.StoreId = new SelectList(_repository.GetStoresList(), "Id", "Title", check.StoreId);
        //    ViewBag.Names = _repository.GetNeighboursNames();
        //    ViewBag.Index = 0;
        //    Models.Checks c = _repository.FindCheckById(check.Id);
        //    return View(c);
        //}

        // GET: Checks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Check check = unit.Checks.GetById(id.Value);
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
            unit.Checks.Delete(id);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _repository.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //public ActionResult FindProducts(string term, int storeId, string fieldId)
        //{
        //    var products = _repository.FindProductsinDb(term);

        //    var responce = new List<Responce>();
        //    foreach (var product in products)
        //    {
        //        int pricesCount = 0;
        //        foreach (var price in product.Price.OrderByDescending(x => x.Date))
        //        {
        //            if (price.StoreId == storeId)
        //            {
        //                responce.Add(new Responce() { fieldId = fieldId, id = price.Id, price = price.Cost, value = product.Title });
        //                pricesCount++;
        //                break;
        //            }
        //        }
        //        if (pricesCount == 0)
        //        {
        //            responce.Add(new Responce() { fieldId = fieldId, value = product.Title });
        //        }
        //    }

        //    return Json(responce, JsonRequestBehavior.AllowGet);
        //}

        //private class Responce
        //{
        //    public int id { get; set; }
        //    public string value { get; set; }
        //    public decimal price { get; set; }
        //    public string fieldId { get; set; }
        //}

        //public ActionResult ProductBox(string index)
        //{
        //    ViewBag.Names = _repository.GetNeighboursNames();
        //    ViewBag.Index = Convert.ToInt32(index);
        //    return PartialView("ProductBox");
        //}

        //public ActionResult EditProductBox(string index)
        //{
        //    ViewBag.Names = _repository.GetNeighboursNames();
        //    ViewBag.Index = Convert.ToInt32(index);
        //    ViewData["number"] = index;
        //    Purchases p = new Purchases()
        //    {
        //        Id = 0,
        //        Products = new Products() { Title = "" },
        //        Count = 0,
        //        Cost = 0
        //    };
        //    return PartialView("EditProductBox", p);
        //}

        //public ActionResult Recalc()
        //{
        //    //_repository.RecalculateSummas();
        //    return RedirectToAction("Index");
        //}
    }
}
