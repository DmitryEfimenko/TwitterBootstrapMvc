using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using TwitterBootstrapMVC.Infrastructure.Enums;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Controls
{
    public class BootstrapActionLink : IHtmlString
    {
        private HtmlHelper html;
        private AjaxHelper ajax;
        private ActionResult result;
        private Task<ActionResult> taskResult;
        private AjaxOptions ajaxOptions;
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
        private ActionTypePassed actionTypePassed;

        public BootstrapActionLink(HtmlHelper html, string linkText, ActionResult result)
        {
            this.html = html;
            this.linkText = linkText;
            this.result = result;
            this.actionTypePassed = ActionTypePassed.HtmlActionResult;
        }

        public BootstrapActionLink(HtmlHelper html, string linkText, Task<ActionResult> taskResult)
        {
            this.html = html;
            this.linkText = linkText;
            this.taskResult = taskResult;
            this.actionTypePassed = ActionTypePassed.HtmlTaskResult;
        }

        public BootstrapActionLink(HtmlHelper html, string linkText, string actionName)
        {
            this.html = html;
            this.linkText = linkText;
            this.actionName = actionName;
            this.actionTypePassed = ActionTypePassed.HtmlRegular;
        }

        public BootstrapActionLink(HtmlHelper html, string linkText, string actionName, string controllerName)
        {
            this.html = html;
            this.linkText = linkText;
            this.actionName = actionName;
            this.controllerName = controllerName;
            this.actionTypePassed = ActionTypePassed.HtmlRegular;
        }

        public BootstrapActionLink(AjaxHelper ajax, string linkText, ActionResult result, AjaxOptions ajaxOptions)
        {
            this.ajax = ajax;
            this.linkText = linkText;
            this.result = result;
            this.ajaxOptions = ajaxOptions;
            this.actionTypePassed = ActionTypePassed.AjaxActionResult;
        }

        public BootstrapActionLink(AjaxHelper ajax, string linkText, Task<ActionResult> taskResult, AjaxOptions ajaxOptions)
        {
            this.ajax = ajax;
            this.linkText = linkText;
            this.taskResult = taskResult;
            this.ajaxOptions = ajaxOptions;
            this.actionTypePassed = ActionTypePassed.AjaxTaskResult;
        }

        public BootstrapActionLink(AjaxHelper ajax, string linkText, string actionName, AjaxOptions ajaxOptions)
        {
            this.ajax = ajax;
            this.linkText = linkText;
            this.actionName = actionName;
            this.ajaxOptions = ajaxOptions;
            this.actionTypePassed = ActionTypePassed.AjaxRegular;
        }

        public BootstrapActionLink(AjaxHelper ajax, string linkText, string actionName, string controllerName, AjaxOptions ajaxOptions)
        {
            this.ajax = ajax;
            this.linkText = linkText;
            this.actionName = actionName;
            this.controllerName = controllerName;
            this.ajaxOptions = ajaxOptions;
            this.actionTypePassed = ActionTypePassed.AjaxRegular;
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

        public BootstrapActionLink HtmlAttributes(IDictionary<string, object> htmlAttributes)
        {
            this.htmlAttributes = htmlAttributes;
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

            switch (this.actionTypePassed)
            {
                case ActionTypePassed.HtmlRegular:
                    input = html.ActionLink(linkText, actionName, controllerName, protocol, hostName, fragment, routeValues, mergedHtmlAttributes).ToHtmlString();
                    break;
                case ActionTypePassed.HtmlActionResult:
                    input = html.ActionLink(linkText, result, mergedHtmlAttributes, protocol, hostName, fragment).ToHtmlString();
                    break;
                case ActionTypePassed.HtmlTaskResult:
                    input = html.ActionLink(linkText, taskResult, mergedHtmlAttributes, protocol, hostName, fragment).ToHtmlString();
                    break;
                case ActionTypePassed.AjaxRegular:
                    input = ajax.ActionLink(linkText, actionName, controllerName, protocol, hostName, fragment, routeValues, ajaxOptions, mergedHtmlAttributes).ToHtmlString();
                    break;
                case ActionTypePassed.AjaxActionResult:
                    input = ajax.ActionLink(linkText, result, ajaxOptions, mergedHtmlAttributes).ToHtmlString();
                    break;
                case ActionTypePassed.AjaxTaskResult:
                    input = ajax.ActionLink(linkText, taskResult, ajaxOptions, mergedHtmlAttributes).ToHtmlString();
                    break;
                default:
                    break;
            }

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