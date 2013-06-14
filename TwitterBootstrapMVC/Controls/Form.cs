using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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
        public string action;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string controller;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public ActionResult result;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Task<ActionResult> taskResult;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public RouteValueDictionary routeValues;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public FormMethod formMethod;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public FormType formType;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public ActionTypePassed actionTypePassed;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public AjaxOptions ajaxOptions;

        public Form()
            : base(null)
        {
            this.formMethod = System.Web.Mvc.FormMethod.Post;
        }

        public Form(string action)
            : base(null)
        {
            this.action = action;
            this.formMethod = System.Web.Mvc.FormMethod.Post;
            actionTypePassed = ActionTypePassed.HtmlRegular;
        }

        public Form(string action, string controller)
            : base(null)
        {
            this.action = action;
            this.controller = controller;
            this.formMethod = System.Web.Mvc.FormMethod.Post;
            actionTypePassed = ActionTypePassed.HtmlRegular;
        }

        public Form(ActionResult result)
            : base(null)
        {
            this.result = result;
            this.formMethod = System.Web.Mvc.FormMethod.Post;
            actionTypePassed = ActionTypePassed.HtmlActionResult;
        }

        public Form(Task<ActionResult> taskResult)
            : base(null)
        {
            this.taskResult = taskResult;
            this.formMethod = System.Web.Mvc.FormMethod.Post;
            actionTypePassed = ActionTypePassed.HtmlTaskResult;
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
            this.routeValues = HtmlHelper.AnonymousObjectToHtmlAttributes(routeValues);
            return this;
        }

        public Form RouteValues(RouteValueDictionary routeValues)
        {
            this.routeValues = routeValues;
            return this;
        }

        public Form FormMethod(FormMethod formMethod)
        {
            this.formMethod = formMethod;
            return this;
        }

        public Form Type(FormType type)
        {
            this.formType = type;
            return this;
        }

        public Form AjaxOptions(AjaxOptions ajaxOptions)
        {
            this.ajaxOptions = ajaxOptions;
            return this;
        }
    }
}
