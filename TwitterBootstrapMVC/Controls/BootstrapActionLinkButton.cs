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
using TwitterBootstrapMVC.ControlInterfaces;
using TwitterBootstrapMVC.ControlModels;
using TwitterBootstrapMVC.Infrastructure;
using TwitterBootstrapMVC.Infrastructure.Enums;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Controls
{
    public class BootstrapActionLinkButton : BootstrapButtonBase<BootstrapActionLinkButton>
    {
        private HtmlHelper html;
        private AjaxHelper ajax;
        private ActionResult _result;
        private Task<ActionResult> _taskResult;
        private string _routeName;
        private string _actionName;
        private string _controllerName;
        private string _protocol;
        private string _hostName;
        private string _fragment;
        private AjaxOptions _ajaxOptions;
        private RouteValueDictionary _routeValues;
        private ActionTypePassed _actionTypePassed;

        public BootstrapActionLinkButton(HtmlHelper html, string linkText, ActionResult result)
            : base("")
        {
            this.html = html;
            this._model.text = linkText;
            this._result = result;
            this._model.size = ButtonSize.Default;
            this._model.style = ButtonStyle.Default;
            this._actionTypePassed = ActionTypePassed.HtmlActionResult;
        }

        public BootstrapActionLinkButton(HtmlHelper html, string linkText, Task<ActionResult> taskResult)
            : base("")
        {
            this.html = html;
            this._model.text = linkText;
            this._taskResult = taskResult;
            this._model.size = ButtonSize.Default;
            this._model.style = ButtonStyle.Default;
            this._actionTypePassed = ActionTypePassed.HtmlTaskResult;
        }

        public BootstrapActionLinkButton(HtmlHelper html, string linkText, string actionName)
            : base("")
        {
            this.html = html;
            this._model.text = linkText;
            this._actionName = actionName;
            this._model.size = ButtonSize.Default;
            this._model.style = ButtonStyle.Default;
            this._actionTypePassed = ActionTypePassed.HtmlRegular;
        }

        public BootstrapActionLinkButton(HtmlHelper html, string linkText, string actionName, string controllerName)
            : base("")
        {
            this.html = html;
            this._model.text = linkText;
            this._actionName = actionName;
            this._controllerName = controllerName;
            this._model.size = ButtonSize.Default;
            this._model.style = ButtonStyle.Default;
            this._actionTypePassed = ActionTypePassed.HtmlRegular;
        }

        public BootstrapActionLinkButton(AjaxHelper ajax, string linkText, ActionResult result, AjaxOptions ajaxOptions)
            : base("")
        {
            this.ajax = ajax;
            this._model.text = linkText;
            this._result = result;
            this._model.size = ButtonSize.Default;
            this._model.style = ButtonStyle.Default;
            this._ajaxOptions = ajaxOptions;
            this._actionTypePassed = ActionTypePassed.AjaxActionResult;
        }

        public BootstrapActionLinkButton(AjaxHelper ajax, string linkText, Task<ActionResult> taskResult, AjaxOptions ajaxOptions)
            : base("")
        {
            this.ajax = ajax;
            this._model.text = linkText;
            this._taskResult = taskResult;
            this._model.size = ButtonSize.Default;
            this._model.style = ButtonStyle.Default;
            this._ajaxOptions = ajaxOptions;
            this._actionTypePassed = ActionTypePassed.AjaxTaskResult;
        }

        public BootstrapActionLinkButton(AjaxHelper ajax, string linkText, string actionName, AjaxOptions ajaxOptions)
            : base("")
        {
            this.ajax = ajax;
            this._model.text = linkText;
            this._actionName = actionName;
            this._model.size = ButtonSize.Default;
            this._model.style = ButtonStyle.Default;
            this._ajaxOptions = ajaxOptions;
            this._actionTypePassed = ActionTypePassed.AjaxRegular;
        }

        public BootstrapActionLinkButton(AjaxHelper ajax, string linkText, string actionName, string controllerName, AjaxOptions ajaxOptions)
            : base("")
        {
            this.ajax = ajax;
            this._model.text = linkText;
            this._actionName = actionName;
            this._controllerName = controllerName;
            this._model.size = ButtonSize.Default;
            this._model.style = ButtonStyle.Default;
            this._ajaxOptions = ajaxOptions;
            this._actionTypePassed = ActionTypePassed.AjaxRegular;
        }

        public BootstrapActionLinkButton Protocol(string protocol)
        {
            this._protocol = protocol;
            return this;
        }

        public BootstrapActionLinkButton HostName(string hostName)
        {
            this._hostName = hostName;
            return this;
        }

        public BootstrapActionLinkButton Fragment(string fragment)
        {
            this._fragment = fragment;
            return this;
        }

        public BootstrapActionLinkButton RouteName(string routeName)
        {
            this._routeName = routeName;
            return this;
        }

        public BootstrapActionLinkButton RouteValues(object routeValues)
        {
            this._routeValues = HtmlHelper.AnonymousObjectToHtmlAttributes(routeValues);
            return this;
        }

        public BootstrapActionLinkButton RouteValues(RouteValueDictionary routeValues)
        {
            this._routeValues = routeValues;
            return this;
        }

        public BootstrapActionLinkButton DropDownToggle()
        {
            this._model.isDropDownToggle = true;
            return this;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToHtmlString()
        {
            var mergedHtmlAttributes = _model.htmlAttributes;
            mergedHtmlAttributes.AddOrMergeCssClass("class", "btn");
            if(!string.IsNullOrEmpty(_model.id)) mergedHtmlAttributes.AddIfNotExist("id", _model.id);

            mergedHtmlAttributes.AddOrMergeCssClass("class", BootstrapHelper.GetClassForButtonSize(_model.size));
            mergedHtmlAttributes.AddOrMergeCssClass("class", BootstrapHelper.GetClassForButtonStyle(_model.style));

            if (_model.buttonBlock) mergedHtmlAttributes.AddOrMergeCssClass("class", "btn-block");
            if (_model.isDropDownToggle)
            {
                mergedHtmlAttributes.AddOrMergeCssClass("class", "dropdown-toggle");
                mergedHtmlAttributes.AddIfNotExist("data-toggle", "dropdown");
            }
            if (_model.disabled) mergedHtmlAttributes.AddOrMergeCssClass("class", "disabled");

            var input = string.Empty;
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
                    iPrependString = i.ToString(TagRenderMode.Normal);
                }

                string combined = 
                    iPrependString +
                    (!string.IsNullOrEmpty(iPrependString) && (!string.IsNullOrEmpty(_model.text) || !string.IsNullOrEmpty(iAppendString)) ? " " : "") +
                    _model.text +
                    (!string.IsNullOrEmpty(iAppendString) && (!string.IsNullOrEmpty(_model.text) || !string.IsNullOrEmpty(iPrependString)) ? " " : "") +
                    iAppendString;

                string holder = Guid.NewGuid().ToString();

                input = GenerateActionLink(holder, mergedHtmlAttributes);
                input = input.Replace(holder, combined);
            }
            else
            {
                input = GenerateActionLink(_model.text, mergedHtmlAttributes);
            }
            
            return MvcHtmlString.Create(input).ToString();
        }

        private string GenerateActionLink(string linkText, IDictionary<string, object> htmlAttributes)
        {
            string input = string.Empty;
            switch (this._actionTypePassed)
            {
                case ActionTypePassed.HtmlRegular:
                    input = html.ActionLink(linkText, _actionName, _controllerName, _protocol, _hostName, _fragment, _routeValues, htmlAttributes).ToHtmlString();
                    break;
                case ActionTypePassed.HtmlActionResult:
                    input = html.ActionLink(linkText, _result, htmlAttributes, _protocol, _hostName, _fragment).ToHtmlString();
                    break;
                case ActionTypePassed.HtmlTaskResult:
                    input = html.ActionLink(linkText, _taskResult, htmlAttributes, _protocol, _hostName, _fragment).ToHtmlString();
                    break;
                case ActionTypePassed.AjaxRegular:
                    input = ajax.ActionLink(linkText, _actionName, _controllerName, _protocol, _hostName, _fragment, _routeValues, _ajaxOptions, htmlAttributes).ToHtmlString();
                    break;
                case ActionTypePassed.AjaxActionResult:
                    input = ajax.ActionLink(linkText, _result, _ajaxOptions, htmlAttributes).ToHtmlString();
                    break;
                case ActionTypePassed.AjaxTaskResult:
                    input = ajax.ActionLink(linkText, _taskResult, _ajaxOptions, htmlAttributes).ToHtmlString();
                    break;
                default:
                    break;
            }
            return input;
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
