using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public static string RenderControlGroupSelectElement(HtmlHelper html, BootstrapSelectElementModel inputModel, BootstrapLabelModel labelModel, BootstrapInputType inputType)
        {
            if (string.IsNullOrEmpty(inputModel.htmlFieldName) || inputModel.selectList == null) return null;

            string input = string.Empty;
            
            if(inputType == BootstrapInputType.DropDownList)
                input = Renderer.RenderSelectElement(html, inputModel, BootstrapInputType.DropDownList);

            if (inputType == BootstrapInputType.ListBox)
                input = Renderer.RenderSelectElement(html, inputModel, BootstrapInputType.ListBox);

            string label = Renderer.RenderLabel(html, labelModel ?? new BootstrapLabelModel
            {
                htmlFieldName = inputModel.htmlFieldName,
                metadata = inputModel.metadata,
                htmlAttributes = new { @class = "control-label" }.ToDictionary()
            });

            bool fieldIsValid = true;
            if(inputModel != null) fieldIsValid = html.ViewData.ModelState.IsValidField(inputModel.htmlFieldName);
            return new BootstrapControlGroup(input, label, ControlGroupType.textboxLike, fieldIsValid).ToHtmlString();
        }
    }
}
