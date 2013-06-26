using System.Linq;
using System.Web.Mvc;
using TwitterBootstrapMVC.ControlModels;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Renderers
{
    internal static partial class Renderer
    {
        public static string RenderCheckBoxCustom(HtmlHelper html, BootstrapCheckBoxModel model)
        {
            string fullHtmlFieldName = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(model.htmlFieldName);

            model.htmlAttributes.MergeHtmlAttributes(html.GetUnobtrusiveValidationAttributes(model.htmlFieldName, model.metadata));
            if (model.tooltipConfiguration != null) model.htmlAttributes.MergeHtmlAttributes(model.tooltipConfiguration.ToDictionary());
            
            ModelState modelState;
            if (html.ViewData.ModelState.TryGetValue(fullHtmlFieldName, out modelState))
            {
                if (modelState.Errors.Count > 0) model.htmlAttributes.AddOrMergeCssClass("class", "input-validation-error");
                if (modelState.Value != null && ((string[])modelState.Value.RawValue).Contains(model.value.ToString())) model.isChecked = true;
            }
            
            TagBuilder input = new TagBuilder("input");
            input.Attributes.Add("type", "checkbox");
            input.Attributes.Add("name", fullHtmlFieldName);
            input.Attributes.Add("id", model.id);
            input.Attributes.Add("value", model.value.ToString());
            if (model.isChecked) input.Attributes.Add("checked", "checked");
            if (model.isDisabled) input.Attributes.Add("disabled", "disabled");
            input.MergeAttributes(model.htmlAttributes.FormatHtmlAttributes());

            return input.ToString(TagRenderMode.SelfClosing);
        }
    }
}
