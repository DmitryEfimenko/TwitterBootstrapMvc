using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TwitterBootstrapMVC.ControlInterfaces;
using TwitterBootstrapMVC.ControlModels;
using TwitterBootstrapMVC.Infrastructure.Enums;
using TwitterBootstrapMVC.Renderers;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Controls
{
    public class BootstrapControlGroupLabeled : BootstrapInputLabeled
    {
        public BootstrapControlGroupLabeled(HtmlHelper html, object inputModel, BootstrapInputType inputType)
            : base(html, inputModel, inputType)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToHtmlString()
        {
            var input = string.Empty;
            switch (_inputType)
            {
                case BootstrapInputType._NotSet:
                    return null;
                case BootstrapInputType.TextBox:
                    _labelModel.htmlAttributes.AddOrMergeCssClass("class", "control-label");
                    input = Renderer.RenderControlGroupTextBox(html, _inputModel, _labelModel);
                    break;
                case BootstrapInputType.Password:
                    _labelModel.htmlAttributes.AddOrMergeCssClass("class", "control-label");
                    input = Renderer.RenderControlGroupPassword(html, _inputModel, _labelModel);
                    break;
                case BootstrapInputType.File:
                    _labelModel.htmlAttributes.AddOrMergeCssClass("class", "control-label");
                    input = Renderer.RenderControlGroupFile(html, _inputModel, _labelModel);
                    break;
                case BootstrapInputType.CheckBox:
                    _labelModel.htmlAttributes.AddOrMergeCssClass("class", "checkbox");
                    _labelModel.innerInputType = BootstrapInputType.CheckBox;
                    _labelModel.innerInputModel = _inputModel;
                    input = Renderer.RenderControlGroupCheckBox(html, _inputModel, _labelModel);
                    break;
                case BootstrapInputType.Radio:
                    _labelModel.htmlAttributes.AddOrMergeCssClass("class", "radio");
                    _labelModel.innerInputType = BootstrapInputType.Radio;
                    _labelModel.innerInputModel = _inputModel;
                    input = Renderer.RenderControlGroupRadioButton(html, _inputModel, _labelModel);
                    break;
                case BootstrapInputType.RadioTrueFalse:
                    _labelModel.htmlAttributes.AddOrMergeCssClass("class", "control-label");
                    input = Renderer.RenderControlGroupRadioButtonTrueFalse(html, _inputModel, _labelModel);
                    break;
                case BootstrapInputType.DropDownList:
                    _labelModel.htmlAttributes.AddOrMergeCssClass("class", "control-label");
                    input = Renderer.RenderControlGroupSelectElement(html, _inputModel, _labelModel, BootstrapInputType.DropDownList);
                    break;
                case BootstrapInputType.ListBox:
                    _labelModel.htmlAttributes.AddOrMergeCssClass("class", "control-label");
                    input = Renderer.RenderControlGroupSelectElement(html, _inputModel, _labelModel, BootstrapInputType.ListBox);
                    break;
                case BootstrapInputType.TextArea:
                    _labelModel.htmlAttributes.AddOrMergeCssClass("class", "control-label");
                    input = Renderer.RenderControlGroupTextArea(html, _inputModel, _labelModel);
                    break;
                case BootstrapInputType.Custom:
                    _labelModel.htmlAttributes.AddOrMergeCssClass("class", "control-label");
                    input = Renderer.RenderControlGroupCustom(html, _inputModel.input, _labelModel);
                    break;
                case BootstrapInputType.Display:
                    _labelModel.htmlAttributes.AddOrMergeCssClass("class", "control-label");
                    input = Renderer.RenderControlGroupDisplayText(html, _inputModel, _labelModel);
                    break;
            }
            return input;
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
