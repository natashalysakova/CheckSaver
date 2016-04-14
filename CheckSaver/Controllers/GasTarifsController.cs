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
    public class GasTarifsController : Controller
    {
        private InvoicesCS db = new InvoicesCS();

        // GET: GasTarifs
        public ActionResult Index()
        {
            return View(db.GasTarif.ToList());
        }

        // GET: GasTarifs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GasTarif gasTarif = db.GasTarif.Find(id);
            if (gasTarif == null)
            {
                return HttpNotFound();
            }
            return View(gasTarif);
        }

        // GET: GasTarifs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GasTarifs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartDate,FinishDate,LevelRange,LowPrice,HighPrice,StartMonth,EndMonth")] GasTarif gasTarif)
        {
            if (ModelState.IsValid)
            {
                db.GasTarif.Add(gasTarif);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gasTarif);
        }

        // GET: GasTarifs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GasTarif gasTarif = db.GasTarif.Find(id);
            if (gasTarif == null)
            {
                return HttpNotFound();
            }
            return View(gasTarif);
        }

        // POST: GasTarifs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartDate,FinishDate,LevelRange,LowPrice,HighPrice,StartMonth,EndMonth")] GasTarif gasTarif)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gasTarif).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gasTarif);
        }

        // GET: GasTarifs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GasTarif gasTarif = db.GasTarif.Find(id);
            if (gasTarif == null)
            {
                return HttpNotFound();
            }
            return View(gasTarif);
        }

        // POST: GasTarifs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GasTarif gasTarif = db.GasTarif.Find(id);
            db.GasTarif.Remove(gasTarif);
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
