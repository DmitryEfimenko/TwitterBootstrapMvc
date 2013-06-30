using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;
using TwitterBootstrapMVC.ControlInterfaces;
using TwitterBootstrapMVC.ControlModels;
using TwitterBootstrapMVC.Infrastructure;
using TwitterBootstrapMVC.Infrastructure.Enums;
using TwitterBootstrapMVC.Renderers;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Controls
{
    public class BootstrapFile : IBootstrapFile
    {
        protected HtmlHelper html;
        protected BootstrapFileModel _model = new BootstrapFileModel();

        public BootstrapFile(HtmlHelper html, string htmlFieldName, ModelMetadata metadata)
        {
            this.html = html;
            this._model.htmlFieldName = htmlFieldName;
            this._model.metadata = metadata;
        }

        public IBootstrapFile Id(string id)
        {
            this._model.id = id;
            return this;
        }

        public IBootstrapFile HtmlAttributes(IDictionary<string, object> htmlAttributes)
        {
            this._model.htmlAttributes = htmlAttributes;
            return this;
        }

        public IBootstrapFile HtmlAttributes(object htmlAttributes)
        {
            this._model.htmlAttributes = htmlAttributes.ToDictionary();
            return this;
        }

        public IBootstrapFile HelpText()
        {
            this._model.helpText = new BootstrapHelpText(BootstrapHelper.GetHelpTextFromMetadata(_model.metadata), HelpTextStyle.Inline);
            return this;
        }

        public IBootstrapFile HelpText(string text)
        {
            this._model.helpText = new BootstrapHelpText(text, HelpTextStyle.Inline);
            return this;
        }

        public IBootstrapFile HelpText(string text, HelpTextStyle style)
        {
            this._model.helpText = new BootstrapHelpText(text, style);
            return this;
        }

        [Obsolete("This overload is deprecated and will be removed in the future versions. Use .Tooltip(Tooltip tooltip) instead.")]
        public IBootstrapFile Tooltip(TooltipConfiguration configuration)
        {
            this._model.tooltipConfiguration = configuration;
            return this;
        }

        public IBootstrapFile Tooltip(Tooltip tooltip)
        {
            this._model.tooltip = tooltip;
            return this;
        }

        public IBootstrapFile Tooltip(string title)
        {
            this._model.tooltip = new Tooltip(title);
            return this;
        }

        public IBootstrapFile ShowValidationMessage(bool displayValidationMessage)
        {
            this._model.displayValidationMessage = displayValidationMessage;
            if (displayValidationMessage) this._model.validationMessageStyle = HelpTextStyle.Inline;
            return this;
        }

        public IBootstrapFile ShowValidationMessage(bool displayValidationMessage, HelpTextStyle validationMessageStyle)
        {
            this._model.displayValidationMessage = displayValidationMessage;
            this._model.validationMessageStyle = validationMessageStyle;
            return this;
        }

        public virtual IBootstrapLabel Label()
        {
            IBootstrapLabel l = new BootstrapInputLabeled(html, _model, BootstrapInputType.File);
            return l;
        }

        public virtual string ToHtmlString()
        {
            return Renderer.RenderFile(html, _model);
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
