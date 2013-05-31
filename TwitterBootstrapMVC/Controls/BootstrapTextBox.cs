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
using TwitterBootstrapMVC.TypeExtensions;
using TwitterBootstrapMVC.Renderers;
using TwitterBootstrapMVC.ControlModels;
using TwitterBootstrapMVC.Infrastructure;
using TwitterBootstrapMVC.Infrastructure.Enums;

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

        public T Tooltip(TooltipConfiguration configuration)
        {
            this._model.tooltipConfiguration = configuration;
            return (T)this;
        }

        public T Tooltip(string title)
        {
            this._model.tooltipConfiguration = new TooltipConfiguration(title);
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

        public virtual IBootstrapLabel Label()
        {
            IBootstrapLabel l = new BootstrapInputLabeled(html, _model, BootstrapInputType.TextBox);
            return l;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual string ToHtmlString()
        {
            return Renderer.RenderTextBox(html, _model);
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
