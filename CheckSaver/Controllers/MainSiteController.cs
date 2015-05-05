using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace CheckSaver.Controllers
{
    public class MainSiteController : Controller
    {
        // GET: MainSite
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetBlock(string name)
        {
            //return PartialView("~/Views/MainSite/" + name);
            //string result = RenderPartialToString(this, name, null, ViewData, TempData);
            //return Json(result);
            if(ViewEngines.Engines.FindView(ControllerContext, name, null).View!=null)
                return PartialView(name);

            return null;
    
        }

        public static string RenderPartialToString(Controller controller, string partialViewName, object model, ViewDataDictionary viewData, TempDataDictionary tempData)
        {
            ViewEngineResult result = ViewEngines.Engines.FindPartialView(controller.ControllerContext, partialViewName);

            if (result.View != null)
            {
                controller.ViewData.Model = model;
                StringBuilder sb = new StringBuilder();
                using (StringWriter sw = new StringWriter(sb))
                {
                    using (HtmlTextWriter output = new HtmlTextWriter(sw))
                    {
                        ViewContext viewContext = new ViewContext(controller.ControllerContext, result.View, viewData, tempData, output);
                        result.View.Render(viewContext, output);
                    }
                }

                return sb.ToString();
            }

            return String.Empty;
        }
    }
}