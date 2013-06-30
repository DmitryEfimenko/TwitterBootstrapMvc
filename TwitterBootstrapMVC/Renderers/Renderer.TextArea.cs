using System.Web.Mvc;
using System.Web.Mvc.Html;
using TwitterBootstrapMVC.ControlModels;
using TwitterBootstrapMVC.Controls;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Renderers
{
    internal static partial class Renderer
    {
        public static string RenderTextArea(HtmlHelper html, BootstrapTextAreaModel model)
        {
            string validationMessage = "";
            if (model.displayValidationMessage)
            {
                string validation = html.ValidationMessage(model.htmlFieldName).ToHtmlString();
                validationMessage = new BootstrapHelpText(validation, model.validationMessageStyle).ToHtmlString();
            }
            model.htmlAttributes.MergeHtmlAttributes(html.GetUnobtrusiveValidationAttributes(model.htmlFieldName, model.metadata));
            if(!string.IsNullOrEmpty(model.id)) model.htmlAttributes.AddOrReplace("id", model.id);

            if (model.tooltipConfiguration != null) model.htmlAttributes.MergeHtmlAttributes(model.tooltipConfiguration.ToDictionary());
            if (model.tooltip != null) model.htmlAttributes.MergeHtmlAttributes(model.tooltip.ToDictionary());

            return html.TextArea(model.htmlFieldName, model.value, model.rows, model.columns, model.htmlAttributes.FormatHtmlAttributes()).ToHtmlString() + validationMessage;
        }
    }
}
