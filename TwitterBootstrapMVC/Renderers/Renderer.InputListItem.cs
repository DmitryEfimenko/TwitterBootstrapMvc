using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using TwitterBootstrapMVC.ControlModels;
using TwitterBootstrapMVC.Infrastructure.Enums;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Renderers
{
    internal static partial class Renderer
    {
        public static string RenderInputListItem(
            HtmlHelper html,
            BootstrapInputType inputType,
            string htmlFieldName,
            ModelMetadata metadata,
            int index,
            string inputValue,
            string inputText,
            object inputHtmlAttributes,
            object labelHtmlAttributes,
            bool inputIsChecked,
            bool inputIsDisabled)
        {
            string input = string.Empty;
            string fullHtmlFieldName = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName);
            var htmlAttrs = labelHtmlAttributes.ToDictionary();

            switch (inputType)
            {
                case BootstrapInputType._NotSet:
                    break;
                case BootstrapInputType.CheckBoxList:
                    {
                        htmlAttrs.AddOrMergeCssClass("class", "checkbox").FormatHtmlAttributes();

                        BootstrapCheckBoxModel checkboxModel = new BootstrapCheckBoxModel
                        {
                            htmlFieldName = htmlFieldName,
                            value = inputValue,
                            metadata = metadata,
                            htmlAttributes = inputHtmlAttributes.ToDictionary().FormatHtmlAttributes().AddOrReplace("id", fullHtmlFieldName.FormatForMvcInputId() + "_" + index.ToString()),
                            isChecked = inputIsChecked,
                            isDisabled = inputIsDisabled
                        };

                        input = Renderer.RenderCheckBoxCustom(html, checkboxModel);
                        break;
                    }
                case BootstrapInputType.RadioList:
                    {
                        htmlAttrs.AddOrMergeCssClass("class", "radio").FormatHtmlAttributes();

                        BootstrapRadioButtonModel radiobuttonModel = new BootstrapRadioButtonModel
                        {
                            htmlFieldName = htmlFieldName,
                            value = inputValue,
                            metadata = metadata,
                            htmlAttributes = inputHtmlAttributes.ToDictionary().FormatHtmlAttributes().AddOrReplace("id", fullHtmlFieldName.FormatForMvcInputId() + "_" + index.ToString()),
                            isChecked = inputIsChecked,
                            isDisabled = inputIsDisabled
                        };

                        input = Renderer.RenderRadioButton(html, radiobuttonModel);
                        break;
                    }
                default:
                    break;
            }

            BootstrapLabelModel labelModel = new BootstrapLabelModel
            {
                index = index,
                htmlFieldName = htmlFieldName,
                labelText = inputText,
                metadata = metadata,
                htmlAttributes = htmlAttrs,
                innerInput = MvcHtmlString.Create(input),
                showRequiredStar = false
            };

            string labeledInput = Renderer.RenderLabel(html, labelModel);
            return labeledInput;
        }
    }
}
