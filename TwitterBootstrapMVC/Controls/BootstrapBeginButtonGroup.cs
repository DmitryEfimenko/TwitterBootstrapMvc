using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Controls
{
    public class BootstrapBeginButtonGroup : IDisposable
    {
        private HtmlHelper html;
        

        public BootstrapBeginButtonGroup(HtmlHelper html)
        {
            this.html = html;
            TagBuilder div = new TagBuilder("div");
            div.AddCssClass("btn-group");
            html.ViewContext.Writer.Write(div.ToString(TagRenderMode.StartTag));
        }

        public BootstrapBeginButtonGroup(HtmlHelper html, object htmlAttributes)
        {
            this.html = html;
            TagBuilder div = new TagBuilder("div");
            div.MergeAttributes(htmlAttributes.ToDictionary().FormatHtmlAttributes());
            div.AddCssClass("btn-group");
            html.ViewContext.Writer.Write(div.ToString(TagRenderMode.StartTag));
        }

        public BootstrapBeginButtonGroup(HtmlHelper html, ButtonGroupType type)
        {
            this.html = html;
            TagBuilder div = new TagBuilder("div");
            if (type == ButtonGroupType.Vertical) div.AddCssClass("btn-group-vertical");
            if (type == ButtonGroupType.DropUp) div.AddCssClass("dropup");
            div.AddCssClass("btn-group");
            html.ViewContext.Writer.Write(div.ToString(TagRenderMode.StartTag));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose()
        {
            html.ViewContext.Writer.Write("</div>");
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() { return base.ToString(); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) { return base.Equals(obj); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() { return base.GetHashCode(); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Type GetType() { return base.GetType(); }
    }
}
