using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using TwitterBootstrapMVC.ControlModels;
using TwitterBootstrapMVC.Controls;
using TwitterBootstrapMVC.Infrastructure;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Renderers
{
    internal static partial class Renderer
    {
        public static string RenderFile(HtmlHelper html, BootstrapFileModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.htmlFieldName)) return null;

            string validationMessage = "";
            if (model.displayValidationMessage)
            {
                string validation = html.ValidationMessage(model.htmlFieldName).ToHtmlString();
                validationMessage = new BootstrapHelpText(validation, model.validationMessageStyle).ToHtmlString();
            }

            model.htmlAttributes.AddRange(html.GetUnobtrusiveValidationAttributes(model.htmlFieldName, model.metadata));
            if (model.tooltipConfiguration != null) model.htmlAttributes.AddRange(model.tooltipConfiguration.ToDictionary());
            var mergedHtmlAttrs = model.htmlAttributes.FormatHtmlAttributes().AddOrReplace("type", "File");
            if (!string.IsNullOrEmpty(model.id)) mergedHtmlAttrs.AddOrReplace("id", model.id);

            return html.TextBox(model.htmlFieldName, null, mergedHtmlAttrs).ToHtmlString() + validationMessage;
        }
    }
}
