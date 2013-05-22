using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using TwitterBootstrapMVC.ControlInterfaces;
using TwitterBootstrapMVC.ControlModels;
using TwitterBootstrapMVC.Infrastructure;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Controls
{
    public class BootstrapActionLinkButton : BootstrapButtonBase<BootstrapActionLinkButton>
    {
        private HtmlHelper html;
        private ActionResult _result;
        private string _routeName;
        private string _actionName;
        private string _controllerName;
        private string _protocol;
        private string _hostName;
        private string _fragment;
        private RouteValueDictionary _routeValues;

        public BootstrapActionLinkButton(HtmlHelper html, string linkText, ActionResult result)
            : base("")
        {
            this.html = html;
            this._model.text = linkText;
            this._result = result;
            this._model.size = ButtonSize.Default;
            this._model.style = ButtonStyle.Default;
        }

        public BootstrapActionLinkButton(HtmlHelper html, string linkText, string actionName)
            : base("")
        {
            this.html = html;
            this._model.text = linkText;
            this._actionName = actionName;
            this._model.size = ButtonSize.Default;
            this._model.style = ButtonStyle.Default;
        }

        public BootstrapActionLinkButton(HtmlHelper html, string linkText, string actionName, object routeValues)
            : base("")
        {
            this.html = html;
            this._model.text = linkText;
            this._actionName = actionName;
            this._routeValues = HtmlHelper.AnonymousObjectToHtmlAttributes(routeValues);
            this._model.size = ButtonSize.Default;
            this._model.style = ButtonStyle.Default;
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
        }

        public BootstrapActionLinkButton(HtmlHelper html, string linkText, string actionName, string controllerName, object routeValues)
            : base("")
        {
            this.html = html;
            this._model.text = linkText;
            this._actionName = actionName;
            this._controllerName = controllerName;
            this._routeValues = HtmlHelper.AnonymousObjectToHtmlAttributes(routeValues);
            this._model.size = ButtonSize.Default;
            this._model.style = ButtonStyle.Default;
        }

        public BootstrapActionLinkButton(HtmlHelper html, string linkText, string routeName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues)
            : base("")
        {
            this.html = html;
            this._model.text = linkText;
            this._routeName = routeName;
            this._protocol = protocol;
            this._hostName = hostName;
            this._fragment = fragment;
            this._routeValues = routeValues;
            this._model.size = ButtonSize.Default;
            this._model.style = ButtonStyle.Default;
        }

        public BootstrapActionLinkButton(HtmlHelper html, string linkText, string actionName, string controllerName, string protocol, string hostName, string fragment, object routeValues)
            : base("")
        {
            this.html = html;
            this._model.text = linkText;
            this._actionName = actionName;
            this._controllerName = controllerName;
            this._protocol = protocol;
            this._hostName = hostName;
            this._fragment = fragment;
            this._routeValues = HtmlHelper.AnonymousObjectToHtmlAttributes(routeValues);
            this._model.size = ButtonSize.Default;
            this._model.style = ButtonStyle.Default;
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
                input = (_result == null)
                    ? html.ActionLink(holder, _actionName, _controllerName, _protocol, _hostName, _fragment, _routeValues, mergedHtmlAttributes).ToHtmlString()
                    : html.ActionLink(holder, _result, mergedHtmlAttributes, _protocol, _hostName, _fragment).ToHtmlString();
                input = input.Replace(holder, combined);
            }
            else
            {
                input = (_result == null)
                    ? html.ActionLink(_model.text, _actionName, _controllerName, _protocol, _hostName, _fragment, _routeValues, mergedHtmlAttributes).ToHtmlString()
                    : html.ActionLink(_model.text, _result, mergedHtmlAttributes, _protocol, _hostName, _fragment).ToHtmlString();
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
