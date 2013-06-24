using System.Collections.Generic;
using System.ComponentModel;
using TwitterBootstrapMVC.Infrastructure;

namespace TwitterBootstrapMVC
{
    public class Modal : HtmlElement
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool _closeable { get; set; }

        public Modal()
            : base("div")
        {
            EnsureClass("modal hide");
        }

        public Modal Id(string id)
        {
            MergeHtmlAttribute("id", id);
            return this;
        }

        public Modal HtmlAttributes(IDictionary<string, object> htmlAttributes)
        {
            SetHtmlAttributes(htmlAttributes);
            return this;
        }

        public Modal HtmlAttributes(object htmlAttributes)
        {
            SetHtmlAttributes(htmlAttributes);
            return this;
        }

        public Modal Fade()
        {
            EnsureClass("fade");
            return this;
        }

        public Modal Closeable()
        {
            this._closeable = true;
            return this;
        }
    }
}
