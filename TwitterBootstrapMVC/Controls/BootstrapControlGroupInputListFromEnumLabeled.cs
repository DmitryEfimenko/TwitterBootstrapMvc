using System;
using System.ComponentModel;
using System.Web.Mvc;
using TwitterBootstrapMVC.Renderers;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Controls
{
    public class BootstrapControlGroupInputListFromEnumLabeled : BootstrapInputListFromEnumLabeled
    {
        public BootstrapControlGroupInputListFromEnumLabeled(HtmlHelper html, object inputModel)
            : base(html, inputModel)
        {
            this._labelModel.htmlAttributes = _labelModel.htmlAttributes.AddOrMergeCssClass("class", "control-label");
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToHtmlString()
        {
            if (string.IsNullOrEmpty(_inputModel.htmlFieldName)) return null;

            string input = Renderer.RenderInputListFromEnum(html, _inputModel);
            string label = Renderer.RenderLabel(html, _labelModel);

            bool fieldIsValid = true;
            if (this._inputModel != null && this._inputModel.htmlFieldName != null) fieldIsValid = html.ViewData.ModelState.IsValidField(this._inputModel.htmlFieldName);
            return new BootstrapControlGroup(input, label, ControlGroupType.textboxLike).ToHtmlString();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() { return ToHtmlString(); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) { return base.Equals(obj); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() { return base.GetHashCode(); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Type GetType() { return base.GetType(); }
    }
}
