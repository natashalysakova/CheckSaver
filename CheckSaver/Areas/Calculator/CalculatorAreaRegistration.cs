using System.Web.Mvc;

namespace CheckSaver.Areas.Calculator
{
    public class CalculatorAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Calculator";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Calculator_default",
                "{controller}/{action}",
                new { action = "Index"},
                new { controller = "Calculator" },
                new[] { "CheckSaver.Areas.Calculator.Controllers" }
                );
        }
    }
}