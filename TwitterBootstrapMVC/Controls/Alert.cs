using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using TwitterBootstrapMVC.Infrastructure;

namespace TwitterBootstrapMVC
{
    public class Alert : HtmlElement
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool _closeable { get; set; }

        public Alert()
            : base("div")
        {
            EnsureClass("alert");
        }

        public Alert Style(AlertColor style)
        {
            switch (style)
            {
                case AlertColor.Info:
                    EnsureClass("alert-info");
                    break;
                case AlertColor.Error:
                    EnsureClass("alert-error");
                    break;
                case AlertColor.Success:
                    EnsureClass("alert-success");
                    break;
            }
            return this;
        }

        public Alert Closeable()
        {
            this._closeable = true;
            return this;
        }

        public Alert IsLongMessage()
        {
            EnsureClass("alert-block");
            return this;
        }

        public Alert HtmlAttributes(IDictionary<string, object> htmlAttributes)
        {
            SetHtmlAttributes(htmlAttributes);
            return this;
        }

        public Alert HtmlAttributes(object htmlAttributes)
        {
            SetHtmlAttributes(htmlAttributes);
            return this;
        }
    }
}
