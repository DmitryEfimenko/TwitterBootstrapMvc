using System.Web.Mvc;
using System.Web.Mvc.Html;
using TwitterBootstrapMVC.ControlModels;
using TwitterBootstrapMVC.Controls;
using TwitterBootstrapMVC.Infrastructure.Enums;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Renderers
{
    internal static partial class Renderer
    {
        public static string RenderRadioButtonTrueFalse(HtmlHelper html, BootstrapRadioButtonTrueFalseModel model)
        {
            TagBuilder inputsContainer = new TagBuilder("div");
            inputsContainer.AddCssClass("container-radio-true-false");
            inputsContainer.AddCssStyle("display", "inline-block");
            inputsContainer.AddCssStyle("margin-top", "4px");
            if (model.tooltipConfiguration != null) inputsContainer.MergeAttributes(model.tooltipConfiguration.ToDictionary());
            if (model.tooltip != null) inputsContainer.MergeAttributes(model.tooltip.ToDictionary());

            string fullHtmlFieldName = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(model.htmlFieldName);

            bool trueValueIsSelected = false;
            bool falseValueIsSelected = false;
            if (model.metadata.Model != null)
            {
                trueValueIsSelected = model.inputTrueValue.ToString() == model.metadata.Model.ToString();
                falseValueIsSelected = model.inputTrueValue.ToString() != model.metadata.Model.ToString();
            }

            var inputTrue = Renderer.RenderLabel(html, new BootstrapLabelModel
            {
                htmlFieldName = model.htmlFieldName,
                labelText = model.labelTrueText,
                metadata = model.metadata,
                htmlAttributes = model.htmlAttributesLabelTrue,
                showRequiredStar = false,
                innerInputType = BootstrapInputType.Radio,
                innerInputModel = new BootstrapRadioButtonModel
                {
                    htmlFieldName = model.htmlFieldName,
                    value = model.inputTrueValue,
                    metadata = model.metadata,
                    isChecked = trueValueIsSelected,
                    htmlAttributes = model.htmlAttributesInputTrue.AddOrReplace("id", fullHtmlFieldName.FormatForMvcInputId() + "_t")
                }
            });

            var inputFalse = Renderer.RenderLabel(html, new BootstrapLabelModel
            {
                htmlFieldName = model.htmlFieldName,
                labelText = model.labelFalseText,
                metadata = model.metadata,
                htmlAttributes = model.htmlAttributesLabelFalse,
                showRequiredStar = false,
                innerInputType = BootstrapInputType.Radio,
                innerInputModel = new BootstrapRadioButtonModel
                {
                    htmlFieldName = model.htmlFieldName,
                    value = model.inputFalseValue,
                    metadata = model.metadata,
                    isChecked = falseValueIsSelected,
                    htmlAttributes = model.htmlAttributesInputFalse.AddOrReplace("id", fullHtmlFieldName.FormatForMvcInputId() + "_f")
                }
            });

            string helpText = model.helpText != null ? model.helpText.ToHtmlString() : string.Empty;
            string validationMessage = "";
            if (model.displayValidationMessage)
            {
                string validation = html.ValidationMessage(model.htmlFieldName).ToHtmlString();
                validationMessage = new BootstrapHelpText(validation, model.validationMessageStyle).ToHtmlString();
            }

            inputsContainer.InnerHtml = inputTrue + inputFalse;
            return inputsContainer.ToString() + helpText + validationMessage;
        }
    }
}
