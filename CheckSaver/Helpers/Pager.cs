using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;

namespace CheckSaver.Helpers
{
    public static class Paging
    {
        public static MvcHtmlString PagedNavigatorFirst(this HtmlHelper helper, int pageNumber, int maxPage, int secondPagenumber)
        {
           string minus = "Transactions?pageNum=" + (pageNumber - 1) + "&pageNum2=" + secondPagenumber; 
           string plus = "Transactions?pageNum=" + (pageNumber + 1) + "&pageNum2=" + secondPagenumber;
            return GetString(plus, minus, pageNumber, maxPage);
        }

        public static MvcHtmlString PagedNavigatorSecond(this HtmlHelper helper, int pageNumber, int maxPage, int secondPagenumber)
        {
            string minus = "Transactions?pageNum=" + secondPagenumber + "&pageNum2=" + (pageNumber - 1);
            string plus = "Transactions?pageNum=" + secondPagenumber + "&pageNum2=" + (pageNumber + 1);

            return GetString(plus, minus, pageNumber, maxPage);
        }

        private static MvcHtmlString GetString(string plus, string minus, int pageNumber, int maxPage)
        {
            StringBuilder s = new StringBuilder();
            s.Append("<nav><ul class=\"pager\">");
            if (pageNumber == 0)
            {
                s.Append("<li class=\"previous disabled\"><a href = \"#\" ><span aria-hidden=\"true\">&larr;</span></a></li>");
            }
            else
            {
                s.Append("<li class=\"previous\"><a href = \"" + minus + "\"><span aria-hidden=\"true\">&larr;</span></a></li>");
            }
            if (pageNumber == maxPage)
            {
                s.Append("<li class=\"next disabled\"><a href = \"#\" ><span aria-hidden=\"true\">&rarr;</span></a></li>");
            }
            else
            {
                s.Append("<li class=\"next\"><a href = \"" + plus + "\"><span aria-hidden=\"true\">&rarr;</span></a></li>");
            }

            s.Append("</ul></nav>");

            return MvcHtmlString.Create(s.ToString());
        }

        public static MvcHtmlString PageNavigator(this HtmlHelper helper, int pageNumber, int maxPage)
        {
            MvcHtmlString minus = helper.Action("Index", new { pageNum = (pageNumber - 1) });
            MvcHtmlString plus = helper.Action("Index", new { pageNum = (pageNumber + 1) });

            return GetString(plus.ToString(), minus.ToString(), pageNumber, maxPage);
        }


        public static MvcHtmlString PageNavigator(this AjaxHelper helper, int pageNumber, int maxPage, string target)
        {
            AjaxOptions options = new AjaxOptions();
            options.UpdateTargetId = target;
            options.InsertionMode = InsertionMode.Replace;


            StringBuilder s = new StringBuilder();
            s.Append("<nav><ul class=\"pager\">");

            if (pageNumber == 0)
            {
                s.Append("<li class=\"previous disabled\"><a href = \"#\" ><span aria-hidden=\"true\">←</span></a></li>");
            }
            else
            {
                s.Append("<li class=\"next\">" + helper.ActionLink("<span aria-hidden=\"true\">←</span>", "Index", new { pageNum = pageNumber - 1 }, options) + "</li>");
            }
            if (pageNumber == maxPage)
            {
                s.Append("<li class=\"next disabled\"><a href = \"#\" ><span aria-hidden=\"true\">→</span></a></li>");
            }
            else
            {
                s.Append("<li class=\"next\">" + helper.ActionLink("→", "Index", new { pageNum = pageNumber + 1 }, options) + "</li>");
            }

            s.Append("</ul></nav>");


            return MvcHtmlString.Create(s.ToString());
        }

    }
}