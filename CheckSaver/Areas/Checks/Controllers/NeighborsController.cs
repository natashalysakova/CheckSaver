using System.Net;
using System.Web.Mvc;
using CheckSaver.Models;
using CheckSaver.Models.Repository;

namespace CheckSaver.Areas.Checks.Controllers
{
    public class NeighborsController : Controller
    {
        private readonly CheckSaveDbRepository _repository = new CheckSaveDbRepository();

        // GET: Neighbors
        public ActionResult Index()
        {
            return View(_repository.GetAllNeighbours());
        }

        // GET: Neighbors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Neighbours neighbor = _repository.FindNeighbourById(id);
            if (neighbor == null)
            {
                return HttpNotFound();
            }

            ViewBag.MonthPay = _repository.GetMonthPays(id);
            return View(neighbor);
        }

        // GET: Neighbors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Neighbors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Photo")] Neighbours neighbor)
        {
            if (ModelState.IsValid)
            {
                _repository.AddNewNeighbour(neighbor);
                return RedirectToAction("Index");
            }

            return View(neighbor);
        }

        // GET: Neighbors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Neighbours neighbor = _repository.FindNeighbourById(id);
            if (neighbor == null)
            {
                return HttpNotFound();
            }
            return View(neighbor);
        }

        // POST: Neighbors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Neighbours neighbor)
        {
            if (ModelState.IsValid)
            {
                _repository.EditNeighbour(neighbor);
                return RedirectToAction("Index");
            }
            return View(neighbor);
        }

        // GET: Neighbors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Neighbours neighbor = _repository.FindNeighbourById(id);
            if (neighbor == null)
            {
                return HttpNotFound();
            }
            return View(neighbor);
        }

        // POST: Neighbors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.RemoveNeighbour(id);
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
