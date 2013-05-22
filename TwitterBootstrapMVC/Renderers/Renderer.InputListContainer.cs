using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using TwitterBootstrapMVC.ControlInterfaces;
using TwitterBootstrapMVC.Controls;
using TwitterBootstrapMVC.Infrastructure.Enums;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Renderers
{
    internal static partial class Renderer
    {
        public static string RenderInputListContainer(
            HtmlHelper html,
            string htmlFieldName,
            List<string> inputs,
            int? numberOfColumns,
            bool displayInColumnsCondition,
            int columnPixelWidth,
            bool displayInlineBlock,
            int marginRightPx,
            bool displayValidationMessage,
            HelpTextStyle validationMessageStyle
            )
        {
            TagBuilder container = new TagBuilder("div");
            container.AddCssClass("input-list-container");
            if (displayValidationMessage)
            {
                container.AddCssStyle("display", "inline-block");
                container.AddCssStyle("vertical-align", "middle");
                container.AddCssStyle("margin-top", "4px");
            }

            if (numberOfColumns.HasValue && displayInColumnsCondition)
            {
                container.AddCssStyle("max-width", (columnPixelWidth * numberOfColumns).ToString() + "px");
                List<string> columnedInputs = new List<string>();
                TagBuilder columnDiv = new TagBuilder("div");
                columnDiv.AddCssClass("input-list-column");
                columnDiv.AddCssStyle("width", columnPixelWidth.ToString() + "px");
                columnDiv.AddCssStyle("display", "inline-block");
                foreach (var input in inputs)
                {
                    columnDiv.InnerHtml = input;
                    columnedInputs.Add(columnDiv.ToString());
                }
                inputs = columnedInputs;
            }

            if (displayInlineBlock)
            {
                List<string> columnedInputs = new List<string>();
                TagBuilder columnDiv = new TagBuilder("div");
                columnDiv.AddCssClass("input-list-inline");
                columnDiv.AddCssStyle("display", "inline-block");
                columnDiv.AddCssStyle("margin-right", marginRightPx.ToString() + "px");
                foreach (var input in inputs)
                {
                    columnDiv.InnerHtml = input;
                    columnedInputs.Add(columnDiv.ToString());
                }
                inputs = columnedInputs;
            }

            string inputsCombined = string.Empty;
            inputs.ForEach(c => inputsCombined += c);
            container.InnerHtml = inputsCombined;

            string validationMessage = "";
            if (displayValidationMessage)
            {
                string validation = html.ValidationMessage(htmlFieldName).ToHtmlString();
                validationMessage = new BootstrapHelpText(validation, validationMessageStyle).ToHtmlString();
            }

            return container.ToString(TagRenderMode.Normal) + validationMessage;
        }
    }
}
