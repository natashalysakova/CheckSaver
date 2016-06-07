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
                "{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new { controller = "Checks|Neighbors|Prices|Products|Stores|Transactions" },
                new[] { "CheckSaver.Areas.Checks.Controllers" }
            );
        }
    }
}