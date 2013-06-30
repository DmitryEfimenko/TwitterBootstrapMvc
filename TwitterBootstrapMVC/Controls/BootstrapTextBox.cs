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
    public class BootstrapTextBox : BootstrapTextBoxBase<BootstrapTextBox>
    {
        public BootstrapTextBox(HtmlHelper html, string htmlFieldName, ModelMetadata metadata)
            : base(html, htmlFieldName, metadata)
        {

        }
    }

    public class BootstrapTextBoxBase<T> : IBootstrapTextBox<T>
        where T : BootstrapTextBoxBase<T>
    {
        protected HtmlHelper html;
        protected BootstrapTextBoxModel _model = new BootstrapTextBoxModel();

        public BootstrapTextBoxBase(HtmlHelper html, string htmlFieldName, ModelMetadata metadata)
        {
            this.html = html;
            this._model.htmlFieldName = htmlFieldName;
            this._model.metadata = metadata;
            this._model.value = metadata.Model;
        }

        public T Id(string id)
        {
            this._model.id = id;
            return (T)this;
        }

        public T Value(object value)
        {
            this._model.value = value;
            return (T)this;
        }

        public T HtmlAttributes(IDictionary<string, object> htmlAttributes)
        {
            this._model.htmlAttributes = htmlAttributes;
            return (T)this;
        }

        public T HtmlAttributes(object htmlAttributes)
        {
            this._model.htmlAttributes = htmlAttributes.ToDictionary();
            return (T)this;
        }

        public T Format(string format)
        {
            this._model.format = format;
            return (T)this;
        }

        public T Placeholder()
        {
            this._model.placeholder = BootstrapHelper.GetPlaceholderFromMetadata(_model.metadata);
            return (T)this;
        }

        public T Placeholder(string placeholder)
        {
            this._model.placeholder = placeholder;
            return (T)this;
        }

        public T Prepend(string prependString)
        {
            this._model.prependString = prependString;
            return (T)this;
        }

        public T Prepend(BootstrapButton button)
        {
            this._model.prependButtons.Add(button);
            return (T)this;
        }

        public T PrependIcon(Icons icon)
        {
            this._model.iconPrepend = icon;
            return (T)this;
        }

        public T PrependIcon(Icons icon, bool isWhite)
        {
            this._model.iconPrepend = icon;
            this._model.iconPrependIsWhite = isWhite;
            return (T)this;
        }

        public T PrependIcon(string customCssClass)
        {
            this._model.iconPrependCustomClass = customCssClass;
            return (T)this;
        }

        public T Append(string appendString)
        {
            this._model.appendString = appendString;
            return (T)this;
        }

        public T Append(BootstrapButton button)
        {
            this._model.appendButtons.Add(button);
            return (T)this;
        }

        public T AppendIcon(Icons icon)
        {
            this._model.iconAppend = icon;
            return (T)this;
        }

        public T AppendIcon(Icons icon, bool isWhite)
        {
            this._model.iconAppend = icon;
            this._model.iconAppendIsWhite = isWhite;
            return (T)this;
        }

        public T AppendIcon(string customCssClass)
        {
            this._model.iconAppendCustomClass = customCssClass;
            return (T)this;
        }

        public T HelpText()
        {
            this._model.helpText = new BootstrapHelpText(BootstrapHelper.GetHelpTextFromMetadata(_model.metadata), HelpTextStyle.Inline);
            return (T)this;
        }

        public T HelpText(string text)
        {
            this._model.helpText = new BootstrapHelpText(text, HelpTextStyle.Inline);
            return (T)this;
        }

        public T HelpText(string text, HelpTextStyle style)
        {
            this._model.helpText = new BootstrapHelpText(text, style);
            return (T)this;
        }

        public T Size(InputSize size)
        {
            this._model.size = size;
            return (T)this;
        }

        public T Tooltip(Tooltip tooltip)
        {
            this._model.tooltip = tooltip;
            return (T)this;
        }

        [Obsolete("This overload is deprecated and will be removed in the future versions. Use .Tooltip(Tooltip tooltip) instead.")]
        public T Tooltip(TooltipConfiguration configuration)
        {
            this._model.tooltipConfiguration = configuration;
            return (T)this;
        }

        public T Tooltip(string title)
        {
            this._model.tooltip = new Tooltip(title);
            return (T)this;
        }

        public T ShowValidationMessage(bool displayValidationMessage)
        {
            this._model.displayValidationMessage = displayValidationMessage;
            if (displayValidationMessage) this._model.validationMessageStyle = HelpTextStyle.Inline;
            return (T)this;
        }

        public T ShowValidationMessage(bool displayValidationMessage, HelpTextStyle validationMessageStyle)
        {
            this._model.displayValidationMessage = displayValidationMessage;
            this._model.validationMessageStyle = validationMessageStyle;
            return (T)this;
        }

        public T Typehead(Typehead typehead)
        {
            _model.typehead = typehead;
            return (T)this;
        }

        public virtual IBootstrapLabel Label()
        {
            IBootstrapLabel l = new BootstrapInputLabeled(html, _model, BootstrapInputType.TextBox);
            return l;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual string ToHtmlString()
        {
            return Renderer.RenderTextBox(html, _model, false);
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
