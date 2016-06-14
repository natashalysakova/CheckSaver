using CheckSaver.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CheckSaver.Areas.Checks.Controllers
{
    //public class ProductsController : Controller
    //{
    //    private CheckSaverContext db = new CheckSaverContext();

    //    // GET: Products
    //    public ActionResult Index()
    //    {
    //        return View(db.Products.ToList());
    //    }

    //    // GET: Products/Details/5
    //    public ActionResult Details(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        Models.Products products = db.Products.Find(id);
    //        if (products == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(products);
    //    }

    //    // GET: Products/Create
    //    public ActionResult Create()
    //    {
    //        return View();
    //    }

    //    // POST: Products/Create
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Create([Bind(Include = "Id,Title")] Models.Products products)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            db.Products.Add(products);
    //            db.SaveChanges();
    //            return RedirectToAction("Index");
    //        }

    //        return View(products);
    //    }

        

    //    // GET: Products/Edit/5
    //    public ActionResult Edit(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        Models.Products products = db.Products.Find(id);
    //        if (products == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(products);
    //    }

    //    // POST: Products/Edit/5
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Edit([Bind(Include = "Id,Title")] Models.Products products)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            db.Entry(products).State = EntityState.Modified;
    //            db.SaveChanges();
    //            return RedirectToAction("Index");
    //        }
    //        return View(products);
    //    }

    //    // GET: Products/Delete/5
    //    public ActionResult Delete(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        Models.Products products = db.Products.Find(id);
    //        if (products == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(products);
    //    }

    //    // POST: Products/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult DeleteConfirmed(int id)
    //    {
    //        Models.Products products = db.Products.Find(id);
    //        db.Products.Remove(products);
    //        db.SaveChanges();
    //        return RedirectToAction("Index");
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing)
    //        {
    //            db.Dispose();
    //        }
    //        base.Dispose(disposing);
    //    }
    //}
}
