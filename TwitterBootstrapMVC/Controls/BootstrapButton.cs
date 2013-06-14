using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TwitterBootstrapMVC.ControlInterfaces;
using TwitterBootstrapMVC.ControlModels;
using TwitterBootstrapMVC.Infrastructure;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Controls
{
    public class BootstrapButton : BootstrapButtonBase<BootstrapButton>   
    {
        public BootstrapButton(string type)
            : base(type)
        {
            this._model.text = "Submit";
        }

        public BootstrapButton WithCaret()
        {
            this._withCaret = true;
            return this;
        }

        public BootstrapButton DropDownToggle()
        {
            this._model.isDropDownToggle = true;
            return this;
        }

        public BootstrapButton LoadingText(string loadingText)
        {
            this._loadingText = loadingText;
            return this;
        }
    }

    public class BootstrapButtonBase<T> : IBootstrapButton<T>
        where T : BootstrapButtonBase<T>
    {
        protected BootstrapButtonModel _model = new BootstrapButtonModel();
        protected string _loadingText;
        protected bool _withCaret;

        public BootstrapButtonBase(string type)
        {
            this._model.type = type;
            this._model.size = ButtonSize.Default;
            this._model.style = ButtonStyle.Default;
            this._model.iconPrepend = Icons._not_set;
            this._model.iconAppend = Icons._not_set;
        }

        public T Text(string text)
        {
            this._model.text = text;
            return (T)this;
        }

        public T Name(string name)
        {
            this._model.name = name;
            return (T)this;
        }

        public T Id(string id)
        {
            this._model.id = id;
            return (T)this;
        }

        public T Value(string value)
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

        public T Size(ButtonSize size)
        {
            this._model.size = size;
            return (T)this;
        }

        public T Style(ButtonStyle style)
        {
            this._model.style = style;
            return (T)this;
        }

        public T ButtonBlock()
        {
            this._model.buttonBlock = true;
            return (T)this;
        }

        public T IconPrepend(Icons icon)
        {
            this._model.iconPrepend = icon;
            return (T)this;
        }

        public T IconPrepend(Icons icon, bool isWhite)
        {
            this._model.iconPrepend = icon;
            this._model.iconPrependIsWhite = isWhite;
            return (T)this;
        }

        public T IconPrepend(string customCssClass)
        {
            this._model.iconPrependCustomClass = customCssClass;
            return (T)this;
        }

        public T IconAppend(Icons icon)
        {
            this._model.iconAppend = icon;
            return (T)this;
        }

        public T IconAppend(Icons icon, bool isWhite)
        {
            this._model.iconAppend = icon;
            this._model.iconAppendIsWhite = isWhite;
            return (T)this;
        }

        public T IconAppend(string customCssClass)
        {
            this._model.iconAppendCustomClass = customCssClass;
            return (T)this;
        }

        public T Disabled()
        {
            this._model.disabled = true;
            return (T)this;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual string ToHtmlString()
        {
            TagBuilder input = new TagBuilder("button");
            input.Attributes.Add("type", _model.type);
            if (!string.IsNullOrEmpty(_model.name)) input.Attributes.Add("name", _model.name);
            if (!string.IsNullOrEmpty(_model.id)) input.Attributes.Add("id", _model.id);
            if (!string.IsNullOrEmpty(_model.value)) input.Attributes.Add("value", _model.value);
            input.MergeAttributes(_model.htmlAttributes.FormatHtmlAttributes());
            input.AddCssClass(BootstrapHelper.GetClassForButtonSize(_model.size));
            input.AddCssClass(BootstrapHelper.GetClassForButtonStyle(_model.style));
            if (_model.buttonBlock) input.AddCssClass("btn-block");
            if (_model.isDropDownToggle)
            {
                input.AddCssClass("dropdown-toggle");
                input.AddOrMergeAttribute("data-toggle", "dropdown");
            }
            if (_model.disabled)
            {
                input.AddCssClass("disabled");
                input.AddOrMergeAttribute("disabled", "");
            }

            if (!string.IsNullOrEmpty(_loadingText)) input.AddOrMergeAttribute("data-loading-text", _loadingText);
            input.AddCssClass("btn");

            if (_withCaret)
            {
                if (!string.IsNullOrEmpty(_model.text)) _model.text += " ";
                _model.text += "<span class='caret'></span>";
            }

            if (_model.iconPrepend != Icons._not_set || _model.iconAppend != Icons._not_set || !string.IsNullOrEmpty(_model.iconPrependCustomClass) || !string.IsNullOrEmpty(_model.iconAppendCustomClass))
            {
                string iPrependString = string.Empty;
                string iAppendString = string.Empty;
                if (_model.iconPrepend != Icons._not_set) iPrependString = new BootstrapIcon(_model.iconPrepend, _model.iconPrependIsWhite).ToHtmlString();
                if (_model.iconAppend != Icons._not_set) iAppendString = new BootstrapIcon(_model.iconAppend, _model.iconAppendIsWhite).ToHtmlString();
                if (!string.IsNullOrEmpty(_model.iconPrependCustomClass))
                {
                    var i = new TagBuilder("i");
                    i.AddCssClass(_model.iconPrependCustomClass);
                    iPrependString = i.ToString(TagRenderMode.Normal);
                }
                if (!string.IsNullOrEmpty(_model.iconAppendCustomClass))
                {
                    var i = new TagBuilder("i");
                    i.AddCssClass(_model.iconAppendCustomClass);
                    iAppendString = i.ToString(TagRenderMode.Normal);
                }

                _model.text =
                    iPrependString +
                    (!string.IsNullOrEmpty(iPrependString) && (!string.IsNullOrEmpty(_model.text) || !string.IsNullOrEmpty(iAppendString)) ? " " : "") +
                    _model.text +
                    (!string.IsNullOrEmpty(iAppendString) && (!string.IsNullOrEmpty(_model.text) || !string.IsNullOrEmpty(iPrependString)) ? " " : "") +
                    iAppendString;
            }

            input.InnerHtml = _model.text;
            return input.ToString();
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
