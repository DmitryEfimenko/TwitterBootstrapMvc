using System;
using System.ComponentModel;
using System.Web.Mvc;
using TwitterBootstrapMVC.Infrastructure.Enums;
using TwitterBootstrapMVC.Renderers;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Controls
{
    public class BootstrapInputLabeled : BootstrapLabel
    {
        protected dynamic _inputModel;
        protected BootstrapInputType _inputType;

        public BootstrapInputLabeled(HtmlHelper html, dynamic inputModel, BootstrapInputType inputType)
            : base(html, (string)inputModel.htmlFieldName, (ModelMetadata)inputModel.metadata)
        {
            this._inputModel = inputModel;
            this._inputType = inputType;
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
                case BootstrapInputType.TextBox:
                    {
                        var input = Renderer.RenderTextBox(html, _inputModel, false);
                        var label = Renderer.RenderLabel(html, _labelModel);

                        result = label + input;
                        break;
                    }
                case BootstrapInputType.Password:
                    {
                        var input = Renderer.RenderTextBox(html, _inputModel, true);
                        var label = Renderer.RenderLabel(html, _labelModel);

                        result = label + input;
                        break;
                    }
                case BootstrapInputType.File:
                    {
                        var input = Renderer.RenderFile(html, _inputModel);
                        var label = Renderer.RenderLabel(html, _labelModel);

                        result = label + input;
                        break;
                    }
                case BootstrapInputType.CheckBox:
                    {
                        _labelModel.htmlAttributes.AddOrMergeCssClass("class", "checkbox");
                        _labelModel.innerInputType = BootstrapInputType.CheckBox;
                        _labelModel.innerInputModel = _inputModel;

                        var label = Renderer.RenderLabel(html, _labelModel);

                        result = label;
                        break;
                    }
                case BootstrapInputType.Radio:
                    {
                        _labelModel.htmlAttributes.AddOrMergeCssClass("class", "radio");
                        _labelModel.innerInputType = BootstrapInputType.Radio;
                        _labelModel.innerInputModel = _inputModel;

                        var label = Renderer.RenderLabel(html, _labelModel);

                        result = label;
                        break;
                    }
                case BootstrapInputType.RadioTrueFalse:
                    {
                        var input = Renderer.RenderRadioButtonTrueFalse(html, _inputModel);
                        var label = Renderer.RenderLabel(html, _labelModel);

                        result = label + input;
                        break;
                    }
                case BootstrapInputType.DropDownList:
                    {
                        var input = Renderer.RenderSelectElement(html, _inputModel, BootstrapInputType.DropDownList);
                        var label = Renderer.RenderLabel(html, _labelModel);

                        result = label + input;
                        break;
                    }
                case BootstrapInputType.ListBox:
                    {
                        var input = Renderer.RenderSelectElement(html, _inputModel, BootstrapInputType.ListBox);
                        var label = Renderer.RenderLabel(html, _labelModel);

                        result = label + input;
                        break;
                    }
                case BootstrapInputType.TextArea:
                    {
                        var input = Renderer.RenderTextArea(html, _inputModel);
                        var label = Renderer.RenderLabel(html, _labelModel);

                        result = label + input;
                        break;
                    }
                case BootstrapInputType.Display:
                    {
                        var input = Renderer.RenderDisplayText(html, _inputModel);
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
