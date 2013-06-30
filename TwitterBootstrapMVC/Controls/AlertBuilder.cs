using System.Web.Mvc;
using TwitterBootstrapMVC.Infrastructure;

namespace TwitterBootstrapMVC.Controls
{
    public class AlertBuilder<TModel> : BuilderBase<TModel, Alert>
    {
        internal AlertBuilder(HtmlHelper<TModel> htmlHelper, Alert alert)
            : base(htmlHelper, alert)
        {
            if (this.element._closeable)
                base.textWriter.Write(@"<button type=""button"" class=""close"" data-dismiss=""alert"">&times;</button>");
        }
    }
}
