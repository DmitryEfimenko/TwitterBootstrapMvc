using System.Web.Mvc;
using TwitterBootstrapMVC.Infrastructure;

namespace TwitterBootstrapMVC.Controls
{
    public class TableRowBuilder<TModel> : BuilderBase<TModel, TableRow>
    {
        internal TableRowBuilder(HtmlHelper<TModel> htmlHelper, TableRow tableRow)
            : base(htmlHelper, tableRow)
        {
        }
    }
}
