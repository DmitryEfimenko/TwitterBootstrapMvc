using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Controls
{
    public class BootstrapLink : IHtmlString
    {
        private string linkText;
        private string id;
        private string url;
        private IDictionary<string, object> htmlAttributes;
        private bool disabled;
        private string wrapTag;

        public BootstrapLink(HtmlHelper html, string linkText, string url)
        {
            this.linkText = linkText;
            this.url = url;
        }

        public BootstrapLink Id(string id)
        {
            this.id = id;
            return this;
        }

        public BootstrapLink HtmlAttributes(object htmlAttributes)
        {
            this.htmlAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            return this;
        }

        public BootstrapLink Disabled()
        {
            this.disabled = true;
            return this;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public BootstrapLink WrapInto(string tag)
        {
            this.wrapTag = tag;
            return this;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ToHtmlString()
        {
            var mergedHtmlAttributes = htmlAttributes;
            if (!string.IsNullOrEmpty(id)) mergedHtmlAttributes.AddIfNotExist("id", id);
            if (disabled) mergedHtmlAttributes.AddOrMergeCssClass("class", "disabled");

            var linkBuilder = new TagBuilder("a");
            linkBuilder.MergeAttributes(mergedHtmlAttributes);
            linkBuilder.MergeAttribute("href", url);
            linkBuilder.SetInnerText(linkText);

            string input = linkBuilder.ToString(TagRenderMode.Normal);
            if (!string.IsNullOrEmpty(this.wrapTag)) input = string.Format("<{0}>{1}</{0}>", this.wrapTag, input);

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
