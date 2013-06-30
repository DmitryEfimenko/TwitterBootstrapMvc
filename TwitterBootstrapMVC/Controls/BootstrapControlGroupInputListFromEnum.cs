using System.ComponentModel;
using System.Web.Mvc;
using TwitterBootstrapMVC.ControlInterfaces;
using TwitterBootstrapMVC.Infrastructure.Enums;
using TwitterBootstrapMVC.Renderers;

namespace TwitterBootstrapMVC.Controls
{
    public class BootstrapControlGroupInputListFromEnum : BootstrapInputListFromEnum
    {
        public BootstrapControlGroupInputListFromEnum(HtmlHelper html, string htmlFieldName, ModelMetadata metadata, BootstrapInputType inputType)
            : base(html, htmlFieldName, metadata, inputType)
        {
            this._model.displayValidationMessage = true;
        }

        public override IBootstrapLabel Label()
        {
            IBootstrapLabel l = new BootstrapControlGroupInputListFromEnumLabeled(html, _model);
            return l;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToHtmlString()
        {
            return Renderer.RenderControlGroupInputListFromEnum(html, _model);
        }
    }
}
