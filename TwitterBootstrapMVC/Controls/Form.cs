using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Routing;
using TwitterBootstrapMVC.Infrastructure;
using TwitterBootstrapMVC.Infrastructure.Enums;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC
{
    public class Form : HtmlElement
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string _action;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string _controller;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public ActionResult _result;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Task<ActionResult> _taskResult;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public RouteValueDictionary _routeValues;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public FormMethod _formMethod;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public FormType _formType;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public ActionTypePassed _actionTypePassed;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public AjaxOptions _ajaxOptions;

        public Form()
            : base(null)
        {
            this._formMethod = System.Web.Mvc.FormMethod.Post;
        }

        public Form(string action)
            : base(null)
        {
            this._action = action;
            this._formMethod = System.Web.Mvc.FormMethod.Post;
            _actionTypePassed = ActionTypePassed.HtmlRegular;
        }

        public Form(string action, string controller)
            : base(null)
        {
            this._action = action;
            this._controller = controller;
            this._formMethod = System.Web.Mvc.FormMethod.Post;
            _actionTypePassed = ActionTypePassed.HtmlRegular;
        }

        public Form(ActionResult result)
            : base(null)
        {
            this._result = result;
            this._formMethod = System.Web.Mvc.FormMethod.Post;
            _actionTypePassed = ActionTypePassed.HtmlActionResult;
        }

        public Form(Task<ActionResult> taskResult)
            : base(null)
        {
            this._taskResult = taskResult;
            this._formMethod = System.Web.Mvc.FormMethod.Post;
            _actionTypePassed = ActionTypePassed.HtmlTaskResult;
        }

        public Form HtmlAttributes(IDictionary<string, object> htmlAttributes)
        {
            this.htmlAttributes = htmlAttributes;
            return this;
        }

        public Form HtmlAttributes(object htmlAttributes)
        {
            this.htmlAttributes = htmlAttributes.ObjectToHtmlAttributesDictionary();
            return this;
        }

        public Form RouteValues(object routeValues)
        {
            this._routeValues = routeValues.ToDictionary();
            return this;
        }

        public Form RouteValues(RouteValueDictionary routeValues)
        {
            this._routeValues = routeValues;
            return this;
        }

        public Form FormMethod(FormMethod formMethod)
        {
            this._formMethod = formMethod;
            return this;
        }

        public Form Type(FormType type)
        {
            this._formType = type;
            return this;
        }

        public Form AjaxOptions(AjaxOptions ajaxOptions)
        {
            this._ajaxOptions = ajaxOptions;
            return this;
        }
    }
}
