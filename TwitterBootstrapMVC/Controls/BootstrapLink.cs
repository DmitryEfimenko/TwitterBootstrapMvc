using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.Mvc;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Controls
{
    public class BootstrapLink : IHtmlString
    {
        private string _linkText;
        private string _id;
        private string _url;
        private IDictionary<string, object> _htmlAttributes;
        private bool _disabled;
        private Icons _iconPrepend;
        private Icons _iconAppend;
        private bool _iconPrependIsWhite;
        private bool _iconAppendIsWhite;
        private string _iconPrependCustomClass;
        private string _iconAppendCustomClass;
        private string _wrapTag;

        public BootstrapLink(HtmlHelper html, string linkText, string url)
        {
            this._linkText = linkText;
            this._url = url;
        }

        public BootstrapLink Id(string id)
        {
            this._id = id;
            return this;
        }

        public BootstrapLink HtmlAttributes(IDictionary<string, object> htmlAttributes)
        {
            this._htmlAttributes = htmlAttributes;
            return this;
        }

        public BootstrapLink HtmlAttributes(object htmlAttributes)
        {
            this._htmlAttributes = htmlAttributes.ToDictionary();
            return this;
        }

        public BootstrapLink Disabled()
        {
            this._disabled = true;
            return this;
        }

        public BootstrapLink IconPrepend(Icons icon)
        {
            this._iconPrepend = icon;
            return this;
        }

        public BootstrapLink IconPrepend(Icons icon, bool isWhite)
        {
            this._iconPrepend = icon;
            this._iconPrependIsWhite = isWhite;
            return this;
        }

        public BootstrapLink IconPrepend(string customCssClass)
        {
            this._iconPrependCustomClass = customCssClass;
            return this;
        }

        public BootstrapLink IconAppend(Icons icon)
        {
            this._iconAppend = icon;
            return this;
        }

        public BootstrapLink IconAppend(Icons icon, bool isWhite)
        {
            this._iconAppend = icon;
            this._iconAppendIsWhite = isWhite;
            return this;
        }

        public BootstrapLink IconAppend(string customCssClass)
        {
            this._iconAppendCustomClass = customCssClass;
            return this;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public BootstrapLink WrapInto(string tag)
        {
            this._wrapTag = tag;
            return this;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ToHtmlString()
        {
            var mergedHtmlAttributes = _htmlAttributes;
            if (!string.IsNullOrEmpty(_id)) mergedHtmlAttributes.AddIfNotExist("id", _id);
            if (_disabled) mergedHtmlAttributes.AddOrMergeCssClass("class", "disabled");

            var linkBuilder = new TagBuilder("a");
            linkBuilder.MergeAttributes(mergedHtmlAttributes);
            linkBuilder.MergeAttribute("href", _url);

            if (_iconPrepend != Icons._not_set || _iconAppend != Icons._not_set || !string.IsNullOrEmpty(_iconPrependCustomClass) || !string.IsNullOrEmpty(_iconAppendCustomClass))
            {
                var iPrependString = string.Empty;
                var iAppendString = string.Empty;

                if (_iconPrepend != Icons._not_set) iPrependString = new BootstrapIcon(_iconPrepend, _iconPrependIsWhite).ToHtmlString() + " ";
                if (_iconAppend != Icons._not_set) iAppendString = " " + new BootstrapIcon(_iconAppend, _iconAppendIsWhite).ToHtmlString();
                if (!string.IsNullOrEmpty(_iconPrependCustomClass))
                {
                    var i = new TagBuilder("i");
                    i.AddCssClass(_iconPrependCustomClass);
                    iPrependString = i.ToString(TagRenderMode.Normal) + " ";
                }
                if (!string.IsNullOrEmpty(_iconAppendCustomClass))
                {
                    var i = new TagBuilder("i");
                    i.AddCssClass(_iconAppendCustomClass);
                    iAppendString = " " + i.ToString(TagRenderMode.Normal);
                }

                _linkText = iPrependString + _linkText + iAppendString;
            }

            linkBuilder.InnerHtml = _linkText;

            string input = linkBuilder.ToString(TagRenderMode.Normal);
            if (!string.IsNullOrEmpty(_wrapTag)) input = string.Format("<{0}>{1}</{0}>", _wrapTag, input);

            return MvcHtmlString.Create(input).ToString();
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
