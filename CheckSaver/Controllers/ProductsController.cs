using System.Net;
using System.Web.Mvc;
using CheckSaver.Models;
using CheckSaver.Models.Repository;

namespace CheckSaver.Controllers
{
    public class ProductsController : Controller
    {
        readonly CheckSaveDbRepository _repository = new CheckSaveDbRepository();

        // GET: Products
        public ActionResult Index()
        {
            var product = _repository.GetAllProducts();
            return View(product);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _repository.FindProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.StoreId = new SelectList(_repository.GetStoresList(), "Id", "Title");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,StoreId")] Product product)
        {
            if (ModelState.IsValid)
            {
                _repository.AddNewProduct(product);
                return RedirectToAction("Index");
            }

            ViewBag.StoreId = new SelectList(_repository.GetStoresList(), "Id", "Title", product.StoreId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _repository.FindProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.StoreId = new SelectList(_repository.GetStoresList(), "Id", "Title", product.StoreId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,StoreId")] Product product)
        {
            if (ModelState.IsValid)
            {
                _repository.EditProduct(product);
                return RedirectToAction("Index");
            }
            ViewBag.StoreId = new SelectList(_repository.GetStoresList(), "Id", "Title", product.StoreId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _repository.FindProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.RemoveProduct(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
