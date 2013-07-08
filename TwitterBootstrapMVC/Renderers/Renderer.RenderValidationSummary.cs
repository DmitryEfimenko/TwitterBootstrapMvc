using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace TwitterBootstrapMVC.Renderers
{
    internal static partial class Renderer
    {
        public static MvcHtmlString RenderValidationSummary(HtmlHelper html, bool closeable)
        {
            var errors = html.ViewContext.ViewData.ModelState.SelectMany(state => state.Value.Errors.Select(error => error.ErrorMessage));
            var errorList = errors as IList<string> ?? errors.ToList();
            var errorCount = errorList.Count();

            if (errorCount == 0)
            {
                return new MvcHtmlString(string.Empty);
            }

            var div = new TagBuilder("div");
            div.AddCssClass("alert");
            div.AddCssClass("alert-error");

            string message;

            if (errorCount == 1)
            {
                message = errorList.First();
            }
            else
            {
                message = "Please fix the errors listed below and try again.";
                div.AddCssClass("alert-block");
            }

            if (closeable)
            {
                var button = new TagBuilder("button");
                button.AddCssClass("close");
                button.MergeAttribute("type", "button");
                button.MergeAttribute("data-dismiss", "alert");
                button.InnerHtml = "&times;";
                div.InnerHtml += button.ToString();
            }

            div.InnerHtml += string.Format("<strong>Validation error{0}</strong> {1}", errorCount > 1 ? "s." : ":", message);

            if (errorCount > 1)
            {
                var ul = new TagBuilder("ul");

                foreach (var error in errorList)
                {
                    var li = new TagBuilder("li");
                    li.AddCssClass("text-error");
                    li.SetInnerText(error);
                    ul.InnerHtml += li.ToString();
                }

                div.InnerHtml += ul.ToString();
            }

            return new MvcHtmlString(div.ToString());
        }
    }
}
