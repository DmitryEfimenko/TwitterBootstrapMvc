using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using TwitterBootstrapMVC.Infrastructure;

namespace TwitterBootstrapMVC.Controls
{
    public class FormActionsBuilder<TModel> : BuilderBase<TModel, FormActions>
    {
        internal FormActionsBuilder(HtmlHelper<TModel> htmlHelper, FormActions formActions)
            : base(htmlHelper, formActions)
        {
        }
    }
}
