using System.Web.Mvc;

namespace CheckSaver.Areas.Checks
{
    public class ChecksAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Checks";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Checks_default",
                "Checks/{controller}/{action}/{id}",new { action = "Index", id = UrlParameter.Optional }, 
                new[] { "CheckSaver.Areas.Checks.Controllers" });
        }
    }
}