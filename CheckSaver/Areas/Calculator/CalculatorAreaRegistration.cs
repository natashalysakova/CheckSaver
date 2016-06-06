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
                "Calculator/{controller}/{action}",
                new { action = "Index" }, new[] { "CheckSaver.Areas.Calculator.Controllers" }
            );
        }
    }
}