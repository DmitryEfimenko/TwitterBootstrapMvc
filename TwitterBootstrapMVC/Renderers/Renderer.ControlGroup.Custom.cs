using System.Web.Mvc;
using TwitterBootstrapMVC.ControlModels;
using TwitterBootstrapMVC.Controls;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Renderers
{
    internal static partial class Renderer
    {
        public static string RenderControlGroupCustom(HtmlHelper html, string input, BootstrapLabelModel labelModel)
        {
            string label = Renderer.RenderLabel(html, labelModel ?? new BootstrapLabelModel
            {
                htmlFieldName = labelModel.htmlFieldName,
                metadata = labelModel.metadata,
                htmlAttributes = new { @class = "control-label" }.ToDictionary()
            });

            bool fieldIsValid = true;
            if (labelModel != null && labelModel.htmlFieldName != null) fieldIsValid = html.ViewData.ModelState.IsValidField(labelModel.htmlFieldName);
            return new BootstrapControlGroup(input, label, ControlGroupType.textboxLike, fieldIsValid).ToHtmlString();
        }
    }
}
