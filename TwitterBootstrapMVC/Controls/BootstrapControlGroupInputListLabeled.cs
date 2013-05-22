using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using TwitterBootstrapMVC.Infrastructure.Enums;
using TwitterBootstrapMVC.TypeExtensions;
using TwitterBootstrapMVC.Renderers;

namespace TwitterBootstrapMVC.Controls
{
    public class BootstrapControlGroupInputListLabeled<TModel, TSource, SValue, SText> : BootstrapInputLabeled
    {
        public BootstrapControlGroupInputListLabeled(HtmlHelper html, object inputModel, BootstrapInputType inputType)
            : base(html, inputModel, inputType)
        {
            this._labelModel.htmlAttributes = _labelModel.htmlAttributes.AddOrMergeCssClass("class", "control-label");
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToHtmlString()
        {
            if (string.IsNullOrEmpty(_inputModel.htmlFieldName)) return null;

            string input = RendererList<TModel, TSource, SValue, SText>.RenderInputList(html, _inputModel);
            string label = Renderer.RenderLabel(html, _labelModel);

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
