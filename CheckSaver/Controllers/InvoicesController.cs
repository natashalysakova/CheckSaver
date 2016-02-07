using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CheckSaver.Models;
using CheckSaver.Models.InputModels;
using CheckSaver.Models.Repository;

namespace CheckSaver.Controllers
{
    public class InvoicesController : Controller
    {
        private InvoicesCS db = new InvoicesCS();
        InvoiceDbRepository _repository = new InvoiceDbRepository();

        // GET: Invoices
        public ActionResult Index()
        {
            var invoice = db.Invoice.Include(i => i.Electricity).Include(i => i.Gas).Include(i => i.Water).Include(i => i.Water1);
            return View(invoice.ToList());
        }

        // GET: Invoices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoice.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // GET: Invoices/Create
        public ActionResult Create()
        {
            ViewBag.Month = new SelectList(_repository.GetMonthes(),  "Id", "MonthName", DateTime.Now.Month);
            return View();
        }

        [HttpPost]
        public ActionResult Create(InvoiceInputModel model)
        {
            _repository.SetActualTarifs(model);
            return View("CreateInvoice", model);
        }


        [HttpPost]
        public ActionResult CreateInvoice(InvoiceInputModel model)
        {
            return RedirectToAction("Index");
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,ColdWaterPriceId,HotWaterPriceId,ElectricityPriceId,GasPriceId,Month,CreationDate,TotalSum")] Invoice invoice)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Invoice.Add(invoice);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.ElectricityPriceId = new SelectList(db.Electricity, "Id", "Id", invoice.ElectricityPriceId);
        //    ViewBag.GasPriceId = new SelectList(db.Gas, "Id", "Id", invoice.GasPriceId);
        //    ViewBag.HotWaterPriceId = new SelectList(db.Water, "Id", "Id", invoice.HotWaterPriceId);
        //    ViewBag.ColdWaterPriceId = new SelectList(db.Water, "Id", "Id", invoice.ColdWaterPriceId);
        //    return View(invoice);
        //}

        // GET: Invoices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoice.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.ElectricityPriceId = new SelectList(db.Electricity, "Id", "Id", invoice.ElectricityPriceId);
            ViewBag.GasPriceId = new SelectList(db.Gas, "Id", "Id", invoice.GasPriceId);
            ViewBag.HotWaterPriceId = new SelectList(db.Water, "Id", "Id", invoice.HotWaterPriceId);
            ViewBag.ColdWaterPriceId = new SelectList(db.Water, "Id", "Id", invoice.ColdWaterPriceId);
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ColdWaterPriceId,HotWaterPriceId,ElectricityPriceId,GasPriceId,Month,CreationDate,TotalSum")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ElectricityPriceId = new SelectList(db.Electricity, "Id", "Id", invoice.ElectricityPriceId);
            ViewBag.GasPriceId = new SelectList(db.Gas, "Id", "Id", invoice.GasPriceId);
            ViewBag.HotWaterPriceId = new SelectList(db.Water, "Id", "Id", invoice.HotWaterPriceId);
            ViewBag.ColdWaterPriceId = new SelectList(db.Water, "Id", "Id", invoice.ColdWaterPriceId);
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoice.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invoice invoice = db.Invoice.Find(id);
            db.Invoice.Remove(invoice);
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
