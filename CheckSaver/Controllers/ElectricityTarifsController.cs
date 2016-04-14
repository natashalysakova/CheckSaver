using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CheckSaver.Models;

namespace CheckSaver.Controllers
{
    public class ElectricityTarifsController : Controller
    {
        private InvoicesCS db = new InvoicesCS();

        // GET: ElectricityTarifs
        public async Task<ActionResult> Index()
        {
            return View(await db.ElectricityTarif.ToListAsync());
        }

        // GET: ElectricityTarifs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ElectricityTarif electricityTarif = await db.ElectricityTarif.FindAsync(id);
            if (electricityTarif == null)
            {
                return HttpNotFound();
            }
            return View(electricityTarif);
        }

        // GET: ElectricityTarifs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ElectricityTarifs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,StartDate,FinishDate,LowLevelRange,HighLevelRange,LowPrice,MiddlePrice,HighPrice")] ElectricityTarif electricityTarif)
        {
            if (ModelState.IsValid)
            {
                db.ElectricityTarif.Add(electricityTarif);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(electricityTarif);
        }

        // GET: ElectricityTarifs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ElectricityTarif electricityTarif = await db.ElectricityTarif.FindAsync(id);
            if (electricityTarif == null)
            {
                return HttpNotFound();
            }
            return View(electricityTarif);
        }

        // POST: ElectricityTarifs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,StartDate,FinishDate,LowLevelRange,HighLevelRange,LowPrice,MiddlePrice,HighPrice")] ElectricityTarif electricityTarif)
        {
            if (ModelState.IsValid)
            {
                db.Entry(electricityTarif).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(electricityTarif);
        }

        // GET: ElectricityTarifs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ElectricityTarif electricityTarif = await db.ElectricityTarif.FindAsync(id);
            if (electricityTarif == null)
            {
                return HttpNotFound();
            }
            return View(electricityTarif);
        }

        // POST: ElectricityTarifs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ElectricityTarif electricityTarif = await db.ElectricityTarif.FindAsync(id);
            db.ElectricityTarif.Remove(electricityTarif);
            await db.SaveChangesAsync();
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
