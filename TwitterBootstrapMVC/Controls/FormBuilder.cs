using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using TwitterBootstrapMVC.Infrastructure;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Controls
{
    public class FormBuilder<TModel> : BuilderBase<TModel, Form>
    {
        internal FormBuilder(HtmlHelper<TModel> htmlHelper, Form form)
            : base(htmlHelper, form)
        {
            var mergedHtmlAttributes = base.element.htmlAttributes;
            switch (base.element.formType)
            {
                case FormType.Horizontal:
                    mergedHtmlAttributes.AddOrMergeCssClass("class", "form-horizontal");
                    break;
                case FormType.Vertical:
                    mergedHtmlAttributes.AddOrMergeCssClass("class", "form-vertical");
                    break;
                case FormType.Inline:
                    mergedHtmlAttributes.AddOrMergeCssClass("class", "form-inline");
                    break;
                case FormType.Search:
                    mergedHtmlAttributes.AddOrMergeCssClass("class", "form-search");
                    break;
            }

            if (base.element.result != null && string.IsNullOrEmpty(base.element.action))
                htmlHelper.BeginForm(base.element.result, base.element.formMethod, mergedHtmlAttributes);
            else
                htmlHelper.BeginForm(base.element.action, base.element.controller, base.element.routeValues, base.element.formMethod, mergedHtmlAttributes);

        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Dispose()
        {
            // Close form tag:
            htmlHelper.EndForm();
            base.Dispose();
        }
    }
}
