using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CheckSaver.Models;

namespace CheckSaver.Areas.Invoices.Controllers
{
    public class WaterTarifsController : Controller
    {
        private InvoicesCS db = new InvoicesCS();

        // GET: WaterTarifs
        public ActionResult Index()
        {
            return View(db.WaterTarif.ToList());
        }

        // GET: WaterTarifs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WaterTarif waterTarif = db.WaterTarif.Find(id);
            if (waterTarif == null)
            {
                return HttpNotFound();
            }
            return View(waterTarif);
        }

        // GET: WaterTarifs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WaterTarifs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartDate,FinishDate,Price,WaterType")] WaterTarif waterTarif)
        {
            if (ModelState.IsValid)
            {
                db.WaterTarif.Add(waterTarif);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(waterTarif);
        }

        // GET: WaterTarifs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WaterTarif waterTarif = db.WaterTarif.Find(id);
            if (waterTarif == null)
            {
                return HttpNotFound();
            }
            return View(waterTarif);
        }

        // POST: WaterTarifs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartDate,FinishDate,Price,WaterType")] WaterTarif waterTarif)
        {
            if (ModelState.IsValid)
            {
                db.Entry(waterTarif).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(waterTarif);
        }

        // GET: WaterTarifs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WaterTarif waterTarif = db.WaterTarif.Find(id);
            if (waterTarif == null)
            {
                return HttpNotFound();
            }
            return View(waterTarif);
        }

        // POST: WaterTarifs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WaterTarif waterTarif = db.WaterTarif.Find(id);
            db.WaterTarif.Remove(waterTarif);
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
