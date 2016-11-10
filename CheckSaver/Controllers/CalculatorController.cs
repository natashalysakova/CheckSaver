using System.Web.Mvc;
using CheckSaver.Controllers.API;

namespace CheckSaver.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: Calculator
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FileBrowser()
        {
            TestController t = new TestController();
            var f = t.Get();
            return View("FileBrowser", f);
        }

        public ActionResult GetAll(string path)
        {
            TestController t = new TestController();
            var f = t.Get(path);
            return View("FileBrowser", f);
        }
    }
}