using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CheckSaver.Models;

namespace CheckSaver.Controllers
{
    public class PricesController : Controller
    {
        private uh357966_db2Entities1 db = new uh357966_db2Entities1();

        // GET: Prices
        public ActionResult Index()
        {
            var price = db.Price.Include(p => p.Products).Include(p => p.Stores);
            return View(price.ToList());
        }

        // GET: Prices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Price price = db.Price.Find(id);
            if (price == null)
            {
                return HttpNotFound();
            }
            return View(price);
        }

        // GET: Prices/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Title");
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Title");
            return View();
        }

        // POST: Prices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductId,StoreId,Cost,Date")] Price price)
        {
            if (ModelState.IsValid)
            {
                db.Price.Add(price);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "Title", price.ProductId);
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Title", price.StoreId);
            return View(price);
        }

        // GET: Prices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Price price = db.Price.Find(id);
            if (price == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Title", price.ProductId);
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Title", price.StoreId);
            return View(price);
        }

        // POST: Prices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductId,StoreId,Cost,Date")] Price price)
        {
            if (ModelState.IsValid)
            {
                db.Entry(price).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Title", price.ProductId);
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Title", price.StoreId);
            return View(price);
        }

        // GET: Prices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Price price = db.Price.Find(id);
            if (price == null)
            {
                return HttpNotFound();
            }
            return View(price);
        }

        // POST: Prices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Price price = db.Price.Find(id);
            db.Price.Remove(price);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
