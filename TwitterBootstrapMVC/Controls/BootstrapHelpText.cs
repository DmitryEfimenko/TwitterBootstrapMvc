using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace TwitterBootstrapMVC.Controls
{
    public class BootstrapHelpText : IHtmlString
    {
        string _text;
        HelpTextStyle _style;

        public BootstrapHelpText(string text, HelpTextStyle style)
        {
            _text = text;
            _style = style;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ToHtmlString()
        {
            TagBuilder span = new TagBuilder("span");
            if (_style == HelpTextStyle.Block) span.AddCssClass("help-block");
            if (_style == HelpTextStyle.Inline) span.AddCssClass("help-inline");
            span.InnerHtml = _text;
            return span.ToString();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() { return ToHtmlString(); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) { return base.Equals(obj); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() { return base.GetHashCode(); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Type GetType() { return base.GetType(); }
    }
}
