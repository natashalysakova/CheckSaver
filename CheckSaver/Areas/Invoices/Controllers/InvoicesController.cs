using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CheckSaver.Models;
using CheckSaver.Models.ExtentionsModels;
using CheckSaver.Models.InputModels;
using CheckSaver.Models.Repository;

namespace CheckSaver.Areas.Invoices.Controllers
{
    public class InvoicesController : Controller
    {
        private InvoicesCS db = new InvoicesCS();
        InvoiceDbRepository _repository = new InvoiceDbRepository();

        // GET: Invoices
        public ActionResult Index()
        {
            var invoice = db.Invoice.Include(i => i.Electricity).Include(i => i.Gas).Include(i => i.HotWater).Include(i => i.ColdWater);
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
            ViewBag.Address = _repository.GetLastUsedAddress();
            return View();
        }

        [HttpPost]
        public ActionResult Create(InvoiceInputModel model)
        {
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            _repository.SetActualTarifs(model);
            TempData["invoice"] = model;

            return RedirectToAction("CreateInvoice");
        }

        public ActionResult CreateInvoice()
        {
            if (TempData["invoice"] != null)
            {
                InvoiceInputModel model = (InvoiceInputModel) TempData["invoice"];
                return View(model);
            }

            return RedirectToAction("Create");

        }

        [HttpPost]
        [ActionName("CreateInvoice")]
        public ActionResult CreateNewInvoice(InvoiceInputModel model)
        {
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int newInvoiceId = _repository.AddInvoice(model);

            return RedirectToAction("Details", new { id = newInvoiceId });
        }

        public ActionResult Calculate(int tarifId, string type, string difference, string month)
        {
            ITarif tarif = _repository.GetTarif(type, tarifId);
            difference = difference.Replace(".", ",");
            int monthNumber = 0;
            if (month != null)
            {
                monthNumber = DateTime.ParseExact(month, "MMMM", CultureInfo.CurrentCulture).Month;
            }

            return Json(tarif.Calculate(Convert.ToDouble(difference), monthNumber), JsonRequestBehavior.AllowGet);
        }

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
