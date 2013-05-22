using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using TwitterBootstrapMVC.ControlModels;
using TwitterBootstrapMVC.Controls;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Renderers
{
    internal static partial class Renderer
    {
        public static string RenderControlGroupInputListFromEnum(HtmlHelper html, BootstrapInputListFromEnumModel model)
        {
            if (string.IsNullOrEmpty(model.htmlFieldName)) return null;

            var input = Renderer.RenderInputListFromEnum(html, model);

            string label = Renderer.RenderLabel(html, new BootstrapLabelModel
            {
                htmlFieldName = model.htmlFieldName,
                metadata = model.metadata,
                htmlAttributes = new { @class = "control-label" }.ToDictionary()
            });

            bool fieldIsValid = true;
            if(model != null) fieldIsValid = html.ViewData.ModelState.IsValidField(model.htmlFieldName);
            return new BootstrapControlGroup(input, label, ControlGroupType.textboxLike, fieldIsValid).ToHtmlString();
        }
    }
}
