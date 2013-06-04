using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Controls
{
    public class BootstrapActionLink : IHtmlString
    {
        private HtmlHelper html;
        private ActionResult result;
        private string linkText;
        private string id;
        private string routeName;
        private string actionName;
        private string controllerName;
        private string protocol;
        private string hostName;
        private string fragment;
        private IDictionary<string, object> htmlAttributes;
        private bool disabled;
        private bool isDropDownToggle;
        private RouteValueDictionary routeValues;
        private Icons iconPrepend;
        private Icons iconAppend;
        private bool iconPrependIsWhite;
        private bool iconAppendIsWhite;
        private string wrapTag;

        public BootstrapActionLink(HtmlHelper html, string linkText, ActionResult result)
        {
            this.html = html;
            this.linkText = linkText;
            this.result = result;
        }

        public BootstrapActionLink(HtmlHelper html, string linkText, string actionName)
        {
            this.html = html;
            this.linkText = linkText;
            this.actionName = actionName;
        }

        public BootstrapActionLink(HtmlHelper html, string linkText, string actionName, string controllerName)
        {
            this.html = html;
            this.linkText = linkText;
            this.actionName = actionName;
            this.controllerName = controllerName;
        }

        public BootstrapActionLink Id(string id)
        {
            this.id = id;
            return this;
        }

        public BootstrapActionLink Protocol(string protocol)
        {
            this.protocol = protocol;
            return this;
        }

        public BootstrapActionLink HostName(string hostName)
        {
            this.hostName = hostName;
            return this;
        }

        public BootstrapActionLink Fragment(string fragment)
        {
            this.fragment = fragment;
            return this;
        }

        public BootstrapActionLink RouteName(string routeName)
        {
            this.routeName = routeName;
            return this;
        }

        public BootstrapActionLink HtmlAttributes(object htmlAttributes)
        {
            this.htmlAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            return this;
        }

        public BootstrapActionLink RouteValues(object routeValues)
        {
            this.routeValues = HtmlHelper.AnonymousObjectToHtmlAttributes(routeValues);
            return this;
        }

        public BootstrapActionLink RouteValues(RouteValueDictionary routeValues)
        {
            this.routeValues = routeValues;
            return this;
        }

        public BootstrapActionLink Disabled()
        {
            this.disabled = true;
            return this;
        }

        public BootstrapActionLink DropDownToggle()
        {
            this.isDropDownToggle = true;
            return this;
        }

        public BootstrapActionLink IconPrepend(Icons icon)
        {
            this.iconPrepend = icon;
            return this;
        }

        public BootstrapActionLink IconPrepend(Icons icon, bool isWhite)
        {
            this.iconPrepend = icon;
            this.iconPrependIsWhite = isWhite;
            return this;
        }

        public BootstrapActionLink IconAppend(Icons icon)
        {
            this.iconAppend = icon;
            return this;
        }

        public BootstrapActionLink IconAppend(Icons icon, bool isWhite)
        {
            this.iconAppend = icon;
            this.iconAppendIsWhite = isWhite;
            return this;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public BootstrapActionLink WrapInto(string tag)
        {
            this.wrapTag = tag;
            return this;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ToHtmlString()
        {
            var mergedHtmlAttributes = htmlAttributes;
            if (!string.IsNullOrEmpty(id)) mergedHtmlAttributes.AddIfNotExist("id", id);

            if (isDropDownToggle)
            {
                mergedHtmlAttributes.AddOrMergeCssClass("class", "dropdown-toggle");
                mergedHtmlAttributes.AddIfNotExist("data-toggle", "dropdown");
            }
            if (disabled) mergedHtmlAttributes.AddOrMergeCssClass("class", "disabled");

            var input = string.Empty;
            string iPrependString = string.Empty;
            string iAppendString = string.Empty;

            if (this.iconPrepend != Icons._not_set || this.iconAppend != Icons._not_set)
            {
                if (this.iconPrepend != Icons._not_set) iPrependString = new BootstrapIcon(this.iconPrepend, this.iconPrependIsWhite).ToHtmlString() + " ";
                if (this.iconAppend != Icons._not_set) iAppendString = " " + new BootstrapIcon(this.iconAppend, this.iconAppendIsWhite).ToHtmlString();

                linkText = "{0}" + linkText + "{1}";
            }

            input = (result == null)
                ? html.ActionLink(linkText, actionName, controllerName, protocol, hostName, fragment, routeValues, mergedHtmlAttributes).ToHtmlString()
                : html.ActionLink(linkText, result, mergedHtmlAttributes, protocol, hostName, fragment).ToHtmlString();

            input = string.Format(input, iPrependString, iAppendString);

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