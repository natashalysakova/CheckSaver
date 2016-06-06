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
    public class FPNamesController : Controller
    {
        private InvoicesCS db = new InvoicesCS();

        // GET: FPNames
        public ActionResult Index()
        {
            return View(db.FPName.ToList());
        }

        // GET: FPNames/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FPName fPName = db.FPName.Find(id);
            if (fPName == null)
            {
                return HttpNotFound();
            }
            return View(fPName);
        }

        // GET: FPNames/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FPNames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Id")] FPName fPName)
        {
            if (ModelState.IsValid)
            {
                db.FPName.Add(fPName);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fPName);
        }

        // GET: FPNames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FPName fPName = db.FPName.Find(id);
            if (fPName == null)
            {
                return HttpNotFound();
            }
            return View(fPName);
        }

        // POST: FPNames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,Id")] FPName fPName)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fPName).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fPName);
        }

        // GET: FPNames/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FPName fPName = db.FPName.Find(id);
            if (fPName == null)
            {
                return HttpNotFound();
            }
            return View(fPName);
        }

        // POST: FPNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FPName fPName = db.FPName.Find(id);
            db.FPName.Remove(fPName);
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
