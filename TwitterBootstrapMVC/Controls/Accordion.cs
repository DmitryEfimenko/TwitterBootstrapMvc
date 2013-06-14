using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using TwitterBootstrapMVC.Infrastructure;

namespace TwitterBootstrapMVC
{
    public class Accordion : HtmlElement
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Id { get; set; }

        public Accordion(string id)
            : base("div")
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException("id");

            this.Id = HtmlHelper.GenerateIdFromName(id);
            EnsureClass("accordion");
            EnsureHtmlAttribute("id", this.Id);
        }

        public Accordion HtmlAttributes(IDictionary<string, object> htmlAttributes)
        {
            SetHtmlAttributes(htmlAttributes);
            return this;
        }

        public Accordion HtmlAttributes(object htmlAttributes)
        {
            SetHtmlAttributes(htmlAttributes);
            return this;
        }
    }
}
