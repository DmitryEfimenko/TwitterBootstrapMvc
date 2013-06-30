using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private ActionResult _result;
        private Task<ActionResult> _taskResult;
        private AjaxOptions _ajaxOptions;
        private string _linkText;
        private string _id;
        private string _routeName;
        private string _actionName;
        private string _controllerName;
        private string _protocol;
        private string _hostName;
        private string _fragment;
        private IDictionary<string, object> _htmlAttributes;
        private bool _disabled;
        private bool _isDropDownToggle;
        private RouteValueDictionary _routeValues;
        private Icons _iconPrepend;
        private Icons _iconAppend;
        private bool _iconPrependIsWhite;
        private bool _iconAppendIsWhite;
        private string _wrapTag;
        private readonly ActionTypePassed _actionTypePassed;

        public BootstrapActionLink(HtmlHelper html, string linkText, ActionResult result)
        {
            this.html = html;
            this._linkText = linkText;
            this._result = result;
            this._actionTypePassed = ActionTypePassed.HtmlActionResult;
        }

        public BootstrapActionLink(HtmlHelper html, string linkText, Task<ActionResult> taskResult)
        {
            this.html = html;
            this._linkText = linkText;
            this._taskResult = taskResult;
            this._actionTypePassed = ActionTypePassed.HtmlTaskResult;
        }

        public BootstrapActionLink(HtmlHelper html, string linkText, string actionName)
        {
            this.html = html;
            this._linkText = linkText;
            this._actionName = actionName;
            this._actionTypePassed = ActionTypePassed.HtmlRegular;
        }

        public BootstrapActionLink(HtmlHelper html, string linkText, string actionName, string controllerName)
        {
            this.html = html;
            this._linkText = linkText;
            this._actionName = actionName;
            this._controllerName = controllerName;
            this._actionTypePassed = ActionTypePassed.HtmlRegular;
        }

        public BootstrapActionLink(AjaxHelper ajax, string linkText, ActionResult result, AjaxOptions ajaxOptions)
        {
            this.ajax = ajax;
            this._linkText = linkText;
            this._result = result;
            this._ajaxOptions = ajaxOptions;
            this._actionTypePassed = ActionTypePassed.AjaxActionResult;
        }

        public BootstrapActionLink(AjaxHelper ajax, string linkText, Task<ActionResult> taskResult, AjaxOptions ajaxOptions)
        {
            this.ajax = ajax;
            this._linkText = linkText;
            this._taskResult = taskResult;
            this._ajaxOptions = ajaxOptions;
            this._actionTypePassed = ActionTypePassed.AjaxTaskResult;
        }

        public BootstrapActionLink(AjaxHelper ajax, string linkText, string actionName, AjaxOptions ajaxOptions)
        {
            this.ajax = ajax;
            this._linkText = linkText;
            this._actionName = actionName;
            this._ajaxOptions = ajaxOptions;
            this._actionTypePassed = ActionTypePassed.AjaxRegular;
        }

        public BootstrapActionLink(AjaxHelper ajax, string linkText, string actionName, string controllerName, AjaxOptions ajaxOptions)
        {
            this.ajax = ajax;
            this._linkText = linkText;
            this._actionName = actionName;
            this._controllerName = controllerName;
            this._ajaxOptions = ajaxOptions;
            this._actionTypePassed = ActionTypePassed.AjaxRegular;
        }

        public BootstrapActionLink Id(string id)
        {
            this._id = id;
            return this;
        }

        public BootstrapActionLink Protocol(string protocol)
        {
            this._protocol = protocol;
            return this;
        }

        public BootstrapActionLink HostName(string hostName)
        {
            this._hostName = hostName;
            return this;
        }

        public BootstrapActionLink Fragment(string fragment)
        {
            this._fragment = fragment;
            return this;
        }

        public BootstrapActionLink RouteName(string routeName)
        {
            this._routeName = routeName;
            return this;
        }

        public BootstrapActionLink HtmlAttributes(IDictionary<string, object> htmlAttributes)
        {
            this._htmlAttributes = htmlAttributes;
            return this;
        }

        public BootstrapActionLink HtmlAttributes(object htmlAttributes)
        {
            this._htmlAttributes = htmlAttributes.ToDictionary();
            return this;
        }

        public BootstrapActionLink RouteValues(object routeValues)
        {
            this._routeValues = routeValues.ToDictionary();
            return this;
        }

        public BootstrapActionLink RouteValues(RouteValueDictionary routeValues)
        {
            this._routeValues = routeValues;
            return this;
        }

        public BootstrapActionLink Disabled()
        {
            this._disabled = true;
            return this;
        }

        public BootstrapActionLink DropDownToggle()
        {
            this._isDropDownToggle = true;
            return this;
        }

        public BootstrapActionLink IconPrepend(Icons icon)
        {
            this._iconPrepend = icon;
            return this;
        }

        public BootstrapActionLink IconPrepend(Icons icon, bool isWhite)
        {
            this._iconPrepend = icon;
            this._iconPrependIsWhite = isWhite;
            return this;
        }

        public BootstrapActionLink IconAppend(Icons icon)
        {
            this._iconAppend = icon;
            return this;
        }

        public BootstrapActionLink IconAppend(Icons icon, bool isWhite)
        {
            this._iconAppend = icon;
            this._iconAppendIsWhite = isWhite;
            return this;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public BootstrapActionLink WrapInto(string tag)
        {
            this._wrapTag = tag;
            return this;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ToHtmlString()
        {
            var mergedHtmlAttributes = _htmlAttributes;
            if (!string.IsNullOrEmpty(_id)) mergedHtmlAttributes.AddIfNotExist("id", _id);

            if (_isDropDownToggle)
            {
                mergedHtmlAttributes.AddOrMergeCssClass("class", "dropdown-toggle");
                mergedHtmlAttributes.AddIfNotExist("data-toggle", "dropdown");
            }
            if (_disabled) mergedHtmlAttributes.AddOrMergeCssClass("class", "disabled");

            var input = string.Empty;
            string iPrependString = string.Empty;
            string iAppendString = string.Empty;

            if (this._iconPrepend != Icons._not_set || this._iconAppend != Icons._not_set)
            {
                if (this._iconPrepend != Icons._not_set) iPrependString = new BootstrapIcon(this._iconPrepend, this._iconPrependIsWhite).ToHtmlString() + " ";
                if (this._iconAppend != Icons._not_set) iAppendString = " " + new BootstrapIcon(this._iconAppend, this._iconAppendIsWhite).ToHtmlString();

                _linkText = "{0}" + _linkText + "{1}";
            }

            switch (this._actionTypePassed)
            {
                case ActionTypePassed.HtmlRegular:
                    input = html.ActionLink(_linkText, _actionName, _controllerName, _protocol, _hostName, _fragment, _routeValues, mergedHtmlAttributes).ToHtmlString();
                    break;
                case ActionTypePassed.HtmlActionResult:
                    input = html.ActionLink(_linkText, _result, mergedHtmlAttributes, _protocol, _hostName, _fragment).ToHtmlString();
                    break;
                case ActionTypePassed.HtmlTaskResult:
                    input = html.ActionLink(_linkText, _taskResult, mergedHtmlAttributes, _protocol, _hostName, _fragment).ToHtmlString();
                    break;
                case ActionTypePassed.AjaxRegular:
                    input = ajax.ActionLink(_linkText, _actionName, _controllerName, _protocol, _hostName, _fragment, _routeValues, _ajaxOptions, mergedHtmlAttributes).ToHtmlString();
                    break;
                case ActionTypePassed.AjaxActionResult:
                    input = ajax.ActionLink(_linkText, _result, _ajaxOptions, mergedHtmlAttributes).ToHtmlString();
                    break;
                case ActionTypePassed.AjaxTaskResult:
                    input = ajax.ActionLink(_linkText, _taskResult, _ajaxOptions, mergedHtmlAttributes).ToHtmlString();
                    break;
                default:
                    break;
            }

            input = string.Format(input, iPrependString, iAppendString);

            if (!string.IsNullOrEmpty(this._wrapTag)) input = string.Format("<{0}>{1}</{0}>", this._wrapTag, input);

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