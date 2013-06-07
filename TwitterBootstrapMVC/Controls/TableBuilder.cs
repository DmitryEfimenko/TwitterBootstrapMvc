using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using TwitterBootstrapMVC.Infrastructure;

namespace TwitterBootstrapMVC.Controls
{
    public class TableBuilder<TModel> : BuilderBase<TModel, Table>
    {
        internal TableBuilder(HtmlHelper<TModel> htmlHelper, Table table)
            : base(htmlHelper, table)
        {
            if (!string.IsNullOrEmpty(base.element.caption)) this.textWriter.Write(string.Format(@"<caption>{0}</caption>", base.element.caption));
        }

        public TableRowBuilder<TModel> BeginRow()
        {
            return new TableRowBuilder<TModel>(base.htmlHelper, new TableRow());
        }

        public TableRowBuilder<TModel> BeginRow(RowColor style)
        {
            var tr = new TableRow().Style(style);
            return new TableRowBuilder<TModel>(base.htmlHelper, tr);
        }

        public TableRowBuilder<TModel> BeginRow(object htmlAttributes)
        {
            var tr = new TableRow().HtmlAttributes(htmlAttributes);
            return new TableRowBuilder<TModel>(base.htmlHelper, tr);
        }

        public TableRowBuilder<TModel> BeginRow(RowColor style, object htmlAttributes)
        {
            var tr = new TableRow().Style(style).HtmlAttributes(htmlAttributes);
            return new TableRowBuilder<TModel>(base.htmlHelper, tr);
        }
    }
}
