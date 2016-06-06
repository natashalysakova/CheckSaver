using System.Web.Mvc;

namespace CheckSaver.Areas.Invoices
{
    public class InvoicesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Invoices";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
    "Invoices_default",
    "Invoices/{controller}/{action}/{id}", new { action = "Index", id = UrlParameter.Optional },
    new[] { "CheckSaver.Areas.Invoices.Controllers" });

        }
    }
}