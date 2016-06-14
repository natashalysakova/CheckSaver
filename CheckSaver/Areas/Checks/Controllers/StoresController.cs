using System.Net;
using System.Web.Mvc;
using CheckSaver.Models;
using CheckSaver.Models.Repository;

namespace CheckSaver.Areas.Checks.Controllers
{ 
    //public class StoresController : Controller
    //{
    //    readonly CheckSaveDbRepository _repository = new CheckSaveDbRepository();
    //    // GET: Stores
    //    public ActionResult Index()
    //    {
    //        return View(_repository.GetAllStores());
    //    }

    //    // GET: Stores/Details/5
    //    public ActionResult Details(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        Stores store = _repository.FindStoreById(id);
    //        if (store == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(store);
    //    }

    //    // GET: Stores/Create
    //    public ActionResult Create()
    //    {
    //        return View();
    //    }

    //    // POST: Stores/Create
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Create([Bind(Include = "Id,Title,Address,Photo")] Stores store)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            _repository.AddNewStore(store);
    //            return RedirectToAction("Index");
    //        }

    //        return View(store);
    //    }

    //    // GET: Stores/Edit/5
    //    public ActionResult Edit(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        Stores store = _repository.FindStoreById(id);
    //        if (store == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(store);
    //    }

    //    // POST: Stores/Edit/5
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Edit([Bind(Include = "Id,Title,Address,Photo")] Stores store)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            _repository.EditStore(store);
    //            return RedirectToAction("Index");
    //        }
    //        return View(store);
    //    }

    //    // GET: Stores/Delete/5
    //    public ActionResult Delete(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        Stores store = _repository.FindStoreById(id);
    //        if (store == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(store);
    //    }

    //    // POST: Stores/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult DeleteConfirmed(int id)
    //    {
    //        _repository.RemoveStore(id);
    //        return RedirectToAction("Index");
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing)
    //        {
    //            _repository.Dispose();
    //        }
    //        base.Dispose(disposing);
    //    }
    //}
}
