using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using TwitterBootstrapMVC.ControlInterfaces;
using TwitterBootstrapMVC.ControlModels;
using TwitterBootstrapMVC.Infrastructure.Enums;
using TwitterBootstrapMVC.Renderers;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Controls
{
    public class BootstrapCheckBox : IBootstrapCheckBox
    {
        protected HtmlHelper html;
        protected BootstrapCheckBoxModel _model = new BootstrapCheckBoxModel();

        public BootstrapCheckBox(HtmlHelper html, string htmlFieldName, ModelMetadata metadata)
        {
            this.html = html;
            this._model.htmlFieldName = htmlFieldName;
            this._model.metadata = metadata;
            this._model.isChecked = (metadata.Model != null) ? bool.Parse(metadata.Model.ToString()) : false;
        }

        public BootstrapCheckBox(HtmlHelper html, string htmlFieldName, ModelMetadata metadata, object value, bool isSingleInput)
        {
            this.html = html;
            this._model.htmlFieldName = htmlFieldName;
            this._model.metadata = metadata;
            this._model.isChecked = (metadata.Model != null) ? bool.Parse(metadata.Model.ToString()) : false;
            this._model.value = value;
            this._model.isSingleInput = isSingleInput;
        }

        public IBootstrapCheckBox Id(string id)
        {
            this._model.id = id;
            return this;
        }

        public IBootstrapCheckBox IsChecked(bool isChecked)
        {
            this._model.isChecked = isChecked;
            return this;
        }

        public IBootstrapCheckBox HtmlAttributes(IDictionary<string, object> htmlAttributes)
        {
            this._model.htmlAttributes = htmlAttributes;
            return this;
        }

        public IBootstrapCheckBox HtmlAttributes(object htmlAttributes)
        {
            this._model.htmlAttributes = htmlAttributes.ToDictionary();
            return this;
        }

        public IBootstrapCheckBox Tooltip(TooltipConfiguration configuration)
        {
            this._model.tooltipConfiguration = configuration;
            return this;
        }

        public IBootstrapCheckBox Tooltip(string title)
        {
            this._model.tooltipConfiguration = new TooltipConfiguration(title);
            return this;
        }

        public IBootstrapCheckBox ShowValidationMessage(bool displayValidationMessage)
        {
            _model.displayValidationMessage = displayValidationMessage;
            if (displayValidationMessage) _model.validationMessageStyle = HelpTextStyle.Inline;
            return this;
        }

        public IBootstrapCheckBox ShowValidationMessage(bool displayValidationMessage, HelpTextStyle validationMessageStyle)
        {
            _model.displayValidationMessage = displayValidationMessage;
            _model.validationMessageStyle = validationMessageStyle;
            return this;
        }

        public virtual IBootstrapLabel Label()
        {
            IBootstrapLabel l = new BootstrapInputLabeled(html, _model, BootstrapInputType.CheckBox);
            return l;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual string ToHtmlString()
        {
            return (_model.isSingleInput)
                ? Renderer.RenderCheckBoxCustom(html, _model)
                : Renderer.RenderCheckBox(html, _model);
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
