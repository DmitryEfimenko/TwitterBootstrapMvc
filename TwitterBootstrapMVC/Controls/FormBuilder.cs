using System.ComponentModel;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using TwitterBootstrapMVC.Infrastructure;
using TwitterBootstrapMVC.Infrastructure.Enums;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Controls
{
    public class FormBuilder<TModel> : BuilderBase<TModel, Form>
    {
        internal FormBuilder(HtmlHelper<TModel> htmlHelper, Form form)
            : base(htmlHelper, form)
        {
            FormBuilderCommon();

            switch (base.element._actionTypePassed)
            {
                case ActionTypePassed.HtmlRegular:
                    htmlHelper.BeginForm(base.element._action, base.element._controller, base.element._routeValues, base.element._formMethod, base.element.htmlAttributes);
                    break;
                case ActionTypePassed.HtmlActionResult:
                    htmlHelper.BeginForm(base.element._result, base.element._formMethod, base.element.htmlAttributes);
                    break;
                case ActionTypePassed.HtmlTaskResult:
                    htmlHelper.BeginForm(base.element._taskResult, base.element._formMethod, base.element.htmlAttributes);
                    break;
            }
        }

        internal FormBuilder(AjaxHelper<TModel> ajaxHelper, Form form)
            : base(ajaxHelper, form)
        {
            FormBuilderCommon();

            switch (base.element._actionTypePassed)
            {
                case ActionTypePassed.HtmlRegular:
                    ajaxHelper.BeginForm(base.element._action, base.element._controller, base.element._routeValues, base.element._ajaxOptions, base.element.htmlAttributes);
                    break;
                case ActionTypePassed.HtmlActionResult:
                    ajaxHelper.BeginForm(base.element._result, base.element._ajaxOptions, base.element.htmlAttributes);
                    break;
                case ActionTypePassed.HtmlTaskResult:
                    ajaxHelper.BeginForm(base.element._taskResult, base.element._ajaxOptions, base.element.htmlAttributes);
                    break;
            }
        }

        private void FormBuilderCommon()
        {
            switch (base.element._formType)
            {
                case FormType.Horizontal:
                    base.element.htmlAttributes.AddOrMergeCssClass("class", "form-horizontal");
                    break;
                case FormType.Vertical:
                    base.element.htmlAttributes.AddOrMergeCssClass("class", "form-vertical");
                    break;
                case FormType.Inline:
                    base.element.htmlAttributes.AddOrMergeCssClass("class", "form-inline");
                    break;
                case FormType.Search:
                    base.element.htmlAttributes.AddOrMergeCssClass("class", "form-search");
                    break;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Dispose()
        {
            // Close form tag:
            base.textWriter.Write(@"</form>");
            base.Dispose();
        }
    }
}
