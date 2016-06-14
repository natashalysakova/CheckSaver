using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.UI.DataVisualization.Charting;
using CheckSaver.Models;
using CheckSaver.Models.Repository;

namespace CheckSaver.Controllers
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

        public ActionResult NeigbourMonthStat(int? id)
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

            var pays = _repository.Get12MonthPays(id);

            //Bitmap image = new Bitmap(1700, 1700);
            //Graphics g = Graphics.FromImage(image);
            Chart chart = new Chart
            {
                Width = 950,
                Height = 400
            };


            ChartArea area = new ChartArea("area")
            {
                BackColor = Color.FromArgb(64, Color.White),
                AxisX =
                {
                    IsLabelAutoFit = true,
                    LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep30,
                    LabelStyle = {Enabled = true},
                    Interval = 1,
                    MajorGrid = {LineColor = Color.LightGray}
                }
            };
            area.AxisY.MajorGrid.LineColor = Color.LightGray;

            Series series = new Series
            {
                IsValueShownAsLabel = true,
                Color = Color.FromArgb(0, 150, 136)
            };
            series.Points.DataBindXY(pays.Keys.ToArray(), pays.Values.ToArray());

            chart.ChartAreas.Add(area);
            chart.Series.Add(series);
            MemoryStream imageStream = new MemoryStream();
            chart.SaveImage(imageStream, ChartImageFormat.Png);
            chart.TextAntiAliasingQuality = TextAntiAliasingQuality.SystemDefault;
            Response.ContentType = "image/png";
            imageStream.WriteTo(Response.OutputStream);
            //g.Dispose();
            //image.Dispose();
            return null;
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
