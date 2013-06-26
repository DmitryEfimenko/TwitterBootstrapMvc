using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using TwitterBootstrapMVC.ControlModels;
using TwitterBootstrapMVC.Controls;
using TwitterBootstrapMVC.Infrastructure;
using TwitterBootstrapMVC.Infrastructure.Enums;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Renderers
{
    internal static partial class Renderer
    {
        public static string RenderSelectElement(HtmlHelper html, BootstrapSelectElementModel model, BootstrapInputType inputType)
        {
            string combinedHtml = "{0}{1}{2}";
            if (model.selectedValue != null)
            {
                foreach (var item in model.selectList)
                {
                    if (item.Value == model.selectedValue.ToString())
                        item.Selected = true;
                }
            }

            model.htmlAttributes.MergeHtmlAttributes(html.GetUnobtrusiveValidationAttributes(model.htmlFieldName, model.metadata));
            if (model.tooltipConfiguration != null) model.htmlAttributes.MergeHtmlAttributes(model.tooltipConfiguration.ToDictionary());
            if (!string.IsNullOrEmpty(model.id)) model.htmlAttributes.AddOrReplace("id", model.id);
            
            // assign size class
            model.htmlAttributes.AddOrMergeCssClass("class", BootstrapHelper.GetClassForInputSize(model.size));
            
            // build html for input
            string input = string.Empty;

            if(inputType == BootstrapInputType.DropDownList)
                input = html.DropDownList(model.htmlFieldName, model.selectList, model.optionLabel, model.htmlAttributes.FormatHtmlAttributes()).ToHtmlString();

            if(inputType == BootstrapInputType.ListBox)
                input = html.ListBox(model.htmlFieldName, model.selectList, model.htmlAttributes.FormatHtmlAttributes()).ToHtmlString();
            
            // account for appendString, prependString, and AppendButtons
            TagBuilder appendPrependContainer = new TagBuilder("div");
            if (!string.IsNullOrEmpty(model.prependString) | !string.IsNullOrEmpty(model.appendString) | model.appendButtons.Count() > 0)
            {
                string addOnPrependString = "";
                string addOnAppendString = "";
                string addOnPrependButtons = "";
                string addOnAppendButtons = "";

                TagBuilder addOn = new TagBuilder("span");
                addOn.AddCssClass("add-on");
                if (!string.IsNullOrEmpty(model.prependString))
                {
                    appendPrependContainer.AddOrMergeCssClass("input-prepend");
                    addOn.InnerHtml = model.prependString;
                    addOnPrependString = addOn.ToString();
                }
                if (!string.IsNullOrEmpty(model.appendString))
                {
                    appendPrependContainer.AddOrMergeCssClass("input-append");
                    addOn.InnerHtml = model.appendString;
                    addOnAppendString = addOn.ToString();
                }
                if (model.appendButtons.Count() > 0)
                {
                    appendPrependContainer.AddOrMergeCssClass("input-append");
                    ((List<BootstrapButton>)model.appendButtons).ForEach(x => addOnAppendButtons += x.ToHtmlString());
                }
                if (model.prependButtons.Count() > 0)
                {
                    appendPrependContainer.AddOrMergeCssClass("input-append");
                    ((List<BootstrapButton>)model.prependButtons).ForEach(x => addOnPrependButtons += x.ToHtmlString());
                }

                appendPrependContainer.InnerHtml = addOnPrependButtons + addOnPrependString + "{0}" + addOnAppendString + addOnAppendButtons;
                combinedHtml = appendPrependContainer.ToString(TagRenderMode.Normal) + "{1}{2}";
            }

            string helpText = model.helpText != null ? model.helpText.ToHtmlString() : string.Empty;
            string validationMessage = "";
            if (model.displayValidationMessage)
            {
                string validation = html.ValidationMessage((string)model.htmlFieldName).ToHtmlString();
                validationMessage = new BootstrapHelpText(validation, model.validationMessageStyle).ToHtmlString();
            }

            return MvcHtmlString.Create(string.Format(combinedHtml, input, validationMessage, helpText)).ToString();
        }
    }
}
