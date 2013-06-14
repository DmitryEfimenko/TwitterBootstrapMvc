using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwitterBootstrapMVC.Infrastructure;

namespace TwitterBootstrapMVC
{
    public class FormActions : HtmlElement
    {
        public FormActions()
            : base("div")
        {
            EnsureClass("form-actions");
        }

        public FormActions HtmlAttributes(IDictionary<string, object> htmlAttributes)
        {
            SetHtmlAttributes(htmlAttributes);
            return this;
        }

        public FormActions HtmlAttributes(object htmlAttributes)
        {
            SetHtmlAttributes(htmlAttributes);
            return this;
        }
    }
}
