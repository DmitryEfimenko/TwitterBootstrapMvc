using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using TwitterBootstrapMVC.Infrastructure;

namespace TwitterBootstrapMVC
{
    public class Table : HtmlElement
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string caption;

        public Table()
            : base("table")
        {
            EnsureClass("table");
        }

        public Table Striped()
        {
            EnsureClass("table-striped");
            return this;
        }

        public Table Bordered()
        {
            EnsureClass("table-bordered");
            return this;
        }

        public Table Hover()
        {
            EnsureClass("table-hover");
            return this;
        }

        public Table Condensed()
        {
            EnsureClass("table-condensed");
            return this;
        }

        public Table Caption(string caption)
        {
            this.caption = caption;
            return this;
        }

        public Table HtmlAttributes(object htmlAttributes)
        {
            SetHtmlAttributes(htmlAttributes);
            return this;
        }
    }
}
