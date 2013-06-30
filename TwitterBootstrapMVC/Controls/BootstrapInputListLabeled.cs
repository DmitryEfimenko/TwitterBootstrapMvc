using System;
using System.ComponentModel;
using System.Web.Mvc;
using TwitterBootstrapMVC.ControlModels;
using TwitterBootstrapMVC.Infrastructure.Enums;
using TwitterBootstrapMVC.Renderers;

namespace TwitterBootstrapMVC.Controls
{
    public class BootstrapInputListLabeled<TModel, TSource, SValue, SText> : BootstrapInputLabeled
    {
        public BootstrapInputListLabeled(HtmlHelper html, object inputModel, BootstrapInputType inputType)
            : base(html, inputModel, inputType)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToHtmlString()
        {
            if (_inputModel == null) return null;
            string result = string.Empty;
            switch (_inputType)
            {
                case BootstrapInputType._NotSet:
                    return null;
                case BootstrapInputType.CheckBoxList:
                case BootstrapInputType.RadioList:
                    {
                        var input = RendererList<TModel, TSource, SValue, SText>
                            .RenderInputList(html, (BootstrapInputListModel<TModel, TSource, SValue, SText>)_inputModel);
                        var label = Renderer.RenderLabel(html, _labelModel);

                        result = label + input;
                        break;
                    }
            }
            return result;
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
