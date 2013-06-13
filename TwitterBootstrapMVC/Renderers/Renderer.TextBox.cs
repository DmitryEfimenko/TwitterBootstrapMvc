using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using TwitterBootstrapMVC.ControlInterfaces;
using TwitterBootstrapMVC.ControlModels;
using TwitterBootstrapMVC.Controls;
using TwitterBootstrapMVC.Infrastructure;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Renderers
{
    internal static partial class Renderer
    {
        public static string RenderTextBox(HtmlHelper html, BootstrapTextBoxModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.htmlFieldName)) return null;

            string combinedHtml = "{0}{1}{2}";

            if (!string.IsNullOrEmpty(model.id)) model.htmlAttributes.Add("id", model.id);
            if (model.tooltipConfiguration != null) model.htmlAttributes.AddRange(model.tooltipConfiguration.ToDictionary());
            // assign placeholder class
            if (!string.IsNullOrEmpty(model.placeholder)) model.htmlAttributes.Add("placeholder", model.placeholder);
            // assign size class
            model.htmlAttributes.AddOrMergeCssClass("class", BootstrapHelper.GetClassForInputSize(model.size));
            // build html for input
            var input = html.TextBox(model.htmlFieldName, model.value, model.format, model.htmlAttributes.FormatHtmlAttributes()).ToHtmlString();

            // account for appendString, prependString, and AppendButtons
            if (!string.IsNullOrEmpty(model.prependString) ||
                !string.IsNullOrEmpty(model.appendString) ||
                model.prependButtons.Any() ||
                model.appendButtons.Any() ||
                model.iconPrepend != Icons._not_set ||
                model.iconAppend != Icons._not_set ||
                !string.IsNullOrEmpty(model.iconPrependCustomClass) ||
                !string.IsNullOrEmpty(model.iconAppendCustomClass))
            {
                TagBuilder appendPrependContainer = new TagBuilder("div");
                string addOnPrependString = "";
                string addOnAppendString = "";
                string addOnPrependButtons = "";
                string addOnAppendButtons = "";
                string addOnPrependIcon = "";
                string addOnAppendIcon = "";

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
                if (model.prependButtons.Count() > 0)
                {
                    appendPrependContainer.AddOrMergeCssClass("input-prepend");
                    model.prependButtons.ForEach(x => addOnPrependButtons += x.ToHtmlString());
                }
                if (model.appendButtons.Count() > 0)
                {
                    appendPrependContainer.AddOrMergeCssClass("input-append");
                    model.appendButtons.ForEach(x => addOnAppendButtons += x.ToHtmlString());
                }
                if (model.iconPrepend != Icons._not_set)
                {
                    appendPrependContainer.AddOrMergeCssClass("input-prepend");
                    addOn.InnerHtml = new BootstrapIcon(model.iconPrepend, model.iconPrependIsWhite).ToHtmlString();
                    addOnPrependIcon = addOn.ToString();
                }
                if (model.iconAppend != Icons._not_set)
                {
                    appendPrependContainer.AddOrMergeCssClass("input-append");
                    addOn.InnerHtml = new BootstrapIcon(model.iconAppend, model.iconAppendIsWhite).ToHtmlString();
                    addOnAppendIcon = addOn.ToString();
                }
                if (!string.IsNullOrEmpty(model.iconPrependCustomClass))
                {
                    appendPrependContainer.AddOrMergeCssClass("input-prepend");
                    var i = new TagBuilder("i");
                    i.AddCssClass(model.iconPrependCustomClass);
                    addOn.InnerHtml = i.ToString(TagRenderMode.Normal);
                    addOnPrependIcon = addOn.ToString();
                }
                if (!string.IsNullOrEmpty(model.iconAppendCustomClass))
                {
                    appendPrependContainer.AddOrMergeCssClass("input-append");
                    var i = new TagBuilder("i");
                    i.AddCssClass(model.iconAppendCustomClass);
                    addOn.InnerHtml = i.ToString(TagRenderMode.Normal);
                    addOnAppendIcon = addOn.ToString();
                }

                appendPrependContainer.InnerHtml = addOnPrependButtons + addOnPrependIcon + addOnPrependString + "{0}" + addOnAppendString + addOnAppendIcon + addOnAppendButtons;
                combinedHtml = appendPrependContainer.ToString(TagRenderMode.Normal) + "{1}{2}";
            }

            string helpText = model.helpText != null ? model.helpText.ToHtmlString() : string.Empty;
            string validationMessage = "";
            if(model.displayValidationMessage)
            {
                string validation = html.ValidationMessage(model.htmlFieldName).ToHtmlString();
                validationMessage = new BootstrapHelpText(validation, model.validationMessageStyle).ToHtmlString();
            }

            return MvcHtmlString.Create(string.Format(combinedHtml, input, validationMessage, helpText)).ToString();
        }
    }
}
