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
        private readonly HtmlHelper html;
        private readonly AjaxHelper ajax;
        private readonly ActionResult _result;
        private readonly Task<ActionResult> _taskResult;
        private readonly AjaxOptions _ajaxOptions;
        private string _linkText;
        private string _id;
        private string _routeName;
        private readonly string _actionName;
        private readonly string _controllerName;
        private string _protocol;
        private string _hostName;
        private string _fragment;
        private IDictionary<string, object> _htmlAttributes = new Dictionary<string, object>();
        private bool _disabled;
        private bool _isDropDownToggle;
        private RouteValueDictionary _routeValues;
        private Icons _iconPrepend;
        private Icons _iconAppend;
        private bool _iconPrependIsWhite;
        private bool _iconAppendIsWhite;
        private string _iconPrependCustomClass;
        private string _iconAppendCustomClass;
        private string _wrapTag;
        private bool _wrapTagControllerAware;
        private bool _wrapTagControllerAndActionAware;
        private string _title;
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

        public BootstrapActionLink IconPrepend(string customCssClass)
        {
            this._iconPrependCustomClass = customCssClass;
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

        public BootstrapActionLink IconAppend(string customCssClass)
        {
            this._iconAppendCustomClass = customCssClass;
            return this;
        }

        public BootstrapActionLink Title(string title)
        {
            this._title = title;
            return this;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public BootstrapActionLink WrapInto(string tag)
        {
            this._wrapTag = tag;
            return this;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public BootstrapActionLink WrapTagControllerAware(bool aware)
        {
            this._wrapTagControllerAware = aware;
            return this;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public BootstrapActionLink WrapTagControllerAndActionAware(bool aware)
        {
            this._wrapTagControllerAndActionAware = aware;
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
            if (!string.IsNullOrEmpty(_title)) mergedHtmlAttributes.AddOrReplace("title", _title);

            var input = string.Empty;
            var iPrependString = string.Empty;
            var iAppendString = string.Empty;

            if (_iconPrepend != Icons._not_set || _iconAppend != Icons._not_set || !string.IsNullOrEmpty(_iconPrependCustomClass) || !string.IsNullOrEmpty(_iconAppendCustomClass))
            {
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
                _linkText = "{0}" + _linkText + "{1}";
            }

            var requestedController = "";
            var requestedAction = "";
            var requestedArea = "";

            switch (_actionTypePassed)
            {
                case ActionTypePassed.HtmlRegular:
                    requestedArea = _routeValues != null && _routeValues.ContainsKey("area") ? _routeValues["area"].ToString() : html.ViewContext.RouteData.DataTokens.ContainsKey("area") ? html.ViewContext.RouteData.DataTokens["area"].ToString() : string.Empty;
                    requestedController = string.IsNullOrEmpty(_controllerName) ? html.ViewContext.RouteData.GetRequiredString("controller") : _controllerName;
                    requestedAction = _actionName;
                    input = html.ActionLink(_linkText, _actionName, _controllerName, _protocol, _hostName, _fragment, _routeValues, mergedHtmlAttributes).ToHtmlString();
                    break;
                case ActionTypePassed.HtmlActionResult:
                    requestedArea = _result.GetRouteValueDictionary().ContainsKey("area") ? _result.GetRouteValueDictionary()["area"].ToString() : string.Empty;
                    requestedController = _result.GetRouteValueDictionary()["controller"].ToString();
                    requestedAction = _result.GetRouteValueDictionary()["action"].ToString();
                    input = html.ActionLink(_linkText, _result, mergedHtmlAttributes, _protocol, _hostName, _fragment).ToHtmlString();
                    break;
                case ActionTypePassed.HtmlTaskResult:
                    requestedArea = _taskResult.Result.GetRouteValueDictionary().ContainsKey("area") ? _taskResult.Result.GetRouteValueDictionary()["area"].ToString() : string.Empty;
                    requestedController = _taskResult.Result.GetRouteValueDictionary()["controller"].ToString();
                    requestedAction = _taskResult.Result.GetRouteValueDictionary()["action"].ToString();
                    input = html.ActionLink(_linkText, _taskResult, mergedHtmlAttributes, _protocol, _hostName, _fragment).ToHtmlString();
                    break;
                case ActionTypePassed.AjaxRegular:
                    requestedArea = _routeValues != null && _routeValues.ContainsKey("area") ? _routeValues["area"].ToString() : ajax.ViewContext.RouteData.DataTokens.ContainsKey("area") ? ajax.ViewContext.RouteData.DataTokens["area"].ToString() : string.Empty;
                    requestedController = string.IsNullOrEmpty(_controllerName) ? ajax.ViewContext.RouteData.GetRequiredString("controller") : _controllerName;
                    requestedAction = _actionName;
                    input = ajax.ActionLink(_linkText, _actionName, _controllerName, _protocol, _hostName, _fragment, _routeValues, _ajaxOptions, mergedHtmlAttributes).ToHtmlString();
                    break;
                case ActionTypePassed.AjaxActionResult:
                    requestedArea = _result.GetRouteValueDictionary().ContainsKey("area") ? _result.GetRouteValueDictionary()["area"].ToString() : string.Empty;
                    requestedController = _result.GetRouteValueDictionary()["controller"].ToString();
                    requestedAction = _result.GetRouteValueDictionary()["action"].ToString();
                    input = ajax.ActionLink(_linkText, _result, _ajaxOptions, mergedHtmlAttributes).ToHtmlString();
                    break;
                case ActionTypePassed.AjaxTaskResult:
                    requestedArea = _taskResult.Result.GetRouteValueDictionary().ContainsKey("area") ? _taskResult.Result.GetRouteValueDictionary()["area"].ToString() : string.Empty;
                    requestedController = _taskResult.Result.GetRouteValueDictionary()["controller"].ToString();
                    requestedAction = _taskResult.Result.GetRouteValueDictionary()["action"].ToString();
                    input = ajax.ActionLink(_linkText, _taskResult, _ajaxOptions, mergedHtmlAttributes).ToHtmlString();
                    break;
            }

            input = string.Format(input, iPrependString, iAppendString);

            if (!string.IsNullOrEmpty(_wrapTag))
            {
                var currentAction = string.Empty;
                var currentController = string.Empty;
                var currentArea = string.Empty;
                switch (_actionTypePassed)
                {
                    case ActionTypePassed.HtmlRegular:
                    case ActionTypePassed.HtmlActionResult:
                    case ActionTypePassed.HtmlTaskResult:
                        currentAction = html.ViewContext.RouteData.GetRequiredString("action");
                        currentController = html.ViewContext.RouteData.GetRequiredString("controller");
                        currentArea = html.ViewContext.RouteData.DataTokens.ContainsKey("area") ? html.ViewContext.RouteData.DataTokens["area"].ToString() : string.Empty;
                        break;
                    case ActionTypePassed.AjaxRegular:
                    case ActionTypePassed.AjaxActionResult:
                    case ActionTypePassed.AjaxTaskResult:
                        currentAction = ajax.ViewContext.RouteData.GetRequiredString("action");
                        currentController = ajax.ViewContext.RouteData.GetRequiredString("controller");
                        currentArea = ajax.ViewContext.RouteData.DataTokens.ContainsKey("area") ? ajax.ViewContext.RouteData.DataTokens["area"].ToString() : string.Empty;
                        break;
                }
                
                var classActive = "";
                if (_wrapTagControllerAware && currentArea == requestedArea && currentController == requestedController) classActive = @" class=""active""";
                if (_wrapTagControllerAndActionAware && currentArea == requestedArea && currentController == requestedController && currentAction == requestedAction) classActive = @" class=""active""";
                input = string.Format("<{0}{1}>{2}</{0}>", _wrapTag, classActive, input);
            }

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