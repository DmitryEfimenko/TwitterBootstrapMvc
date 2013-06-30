using System.Collections.Generic;
using TwitterBootstrapMVC.Infrastructure;

namespace TwitterBootstrapMVC
{
    public class TableRow : HtmlElement
    {
        public TableRow()
            : base("tr")
        {

        }

        public TableRow Style(RowColor style)
        {
            switch (style)
            {
                case RowColor.Info:
                    EnsureClass("info");
                    break;
                case RowColor.Error:
                    EnsureClass("error");
                    break;
                case RowColor.Success:
                    EnsureClass("success");
                    break;
                case RowColor.Warning:
                    EnsureClass("warning");
                    break;
            }
            return this;
        }

        public TableRow HtmlAttributes(IDictionary<string, object> htmlAttributes)
        {
            SetHtmlAttributes(htmlAttributes);
            return this;
        }

        public TableRow HtmlAttributes(object htmlAttributes)
        {
            SetHtmlAttributes(htmlAttributes);
            return this;
        }
    }
}
