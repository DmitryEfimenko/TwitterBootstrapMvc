using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Infrastructure
{
    public abstract class HtmlElement
    {
        // Fields
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IDictionary<string, object> htmlAttributes;
        protected string tag;
        protected string classToEnsure;

        // Methods
        internal HtmlElement(string tag)
        {
            this.htmlAttributes = new Dictionary<string, object>();
            this.tag = tag;
        }

        // Properties
        internal string EndTag
        {
            get
            {
                if (string.IsNullOrEmpty(this.tag)) return string.Empty;
                return string.Format("</{0}>", this.tag);
            }
        }

        internal virtual string StartTag
        {
            get
            {
                if (string.IsNullOrEmpty(this.tag)) return string.Empty;
                TagBuilder builder = new TagBuilder(this.tag);
                builder.MergeAttributes<string, object>(this.htmlAttributes);
                return builder.ToString(TagRenderMode.StartTag);
            }
        }

        protected void EnsureClass(string className)
        {
            //this.classToEnsure = className;
            if (this.htmlAttributes.ContainsKey("class"))
            {
                string currentValue = this.htmlAttributes["class"].ToString();
                if (!currentValue.Contains(className))
                {
                    this.htmlAttributes["class"] += " " + className;
                }
            }
            else
            {
                MergeHtmlAttribute("class", className);
            }
        }

        protected void EnsureClassRemoval(string className)
        {
            if (this.htmlAttributes.ContainsKey("class"))
            {
                string currentValue = this.htmlAttributes["class"].ToString();
                if (currentValue.Contains(className))
                {
                    this.htmlAttributes["class"] = currentValue.Replace(className, "").Replace("  ", "").Trim();
                }
            }
        }

        protected void EnsureHtmlAttribute(string key, string value, bool replaceExisting = true)
        {
            if (this.htmlAttributes.ContainsKey(key))
            {
                if (replaceExisting)
                {
                    this.htmlAttributes[key] = value;
                }
                else
                {
                    this.htmlAttributes[key] += " " + value;
                }
            }
            else
            {
                this.htmlAttributes.Add(key, value);
            }
        }

        protected void SetHtmlAttributes(IDictionary<string, object> htmlAttributes)
        {
            this.htmlAttributes.MergeHtmlAttributes(htmlAttributes.ObjectToHtmlAttributesDictionary());
            //if (!string.IsNullOrEmpty(this.classToEnsure)) EnsureClass(this.classToEnsure);
        }

        protected void SetHtmlAttributes(object htmlAttributes)
        {
            this.SetHtmlAttributes(htmlAttributes.ToDictionary().FormatHtmlAttributes());
        }

        protected void MergeHtmlAttribute(string key, string value)
        {
            if (this.htmlAttributes != null)
            {
                if (this.htmlAttributes.ContainsKey(key))
                {
                    this.htmlAttributes[key] = value;
                }
                else
                {
                    this.htmlAttributes.Add(key, value);
                }
            }
            else
            {
                this.htmlAttributes = new Dictionary<string, object>();
                htmlAttributes.Add(key, value);
            }
            if (!string.IsNullOrEmpty(this.classToEnsure)) EnsureClass(this.classToEnsure);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() { return base.ToString(); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) { return base.Equals(obj); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() { return base.GetHashCode(); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Type GetType() { return base.GetType(); }
    }
}
