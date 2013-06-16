using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using TwitterBootstrapMVC.Controls;

namespace TwitterBootstrapMVC.BootstrapMethods
{
    public class BootstrapAjax<TModel>
    {
        public AjaxHelper<TModel> Ajax;

        public BootstrapAjax(AjaxHelper<TModel> ajax)
        {
            this.Ajax = ajax;
        }

        public FormBuilder<TModel> Begin(Form form, AjaxOptions ajaxOptions)
        {
            form._ajaxOptions = ajaxOptions;
            return new FormBuilder<TModel>(Ajax, form);
        }

        public BootstrapActionLinkButton ActionLinkButton(string linkText, ActionResult result, AjaxOptions ajaxOptions)
        {
            return new BootstrapActionLinkButton(Ajax, linkText, result, ajaxOptions);
        }

        public BootstrapActionLinkButton ActionLinkButton(string linkText, string actionName, AjaxOptions ajaxOptions)
        {
            return new BootstrapActionLinkButton(Ajax, linkText, actionName, ajaxOptions);
        }

        public BootstrapActionLinkButton ActionLinkButton(string linkText, string actionName, string controllerName, AjaxOptions ajaxOptions)
        {
            return new BootstrapActionLinkButton(Ajax, linkText, actionName, controllerName, ajaxOptions);
        }

        public BootstrapActionLink ActionLink(string linkText, ActionResult result, AjaxOptions ajaxOptions)
        {
            return new BootstrapActionLink(Ajax, linkText, result, ajaxOptions);
        }

        public BootstrapActionLink ActionLink(string linkText, string actionName, AjaxOptions ajaxOptions)
        {
            return new BootstrapActionLink(Ajax, linkText, actionName, ajaxOptions);
        }

        public BootstrapActionLink ActionLink(string linkText, string actionName, string controllerName, AjaxOptions ajaxOptions)
        {
            return new BootstrapActionLink(Ajax, linkText, actionName, controllerName, ajaxOptions);
        }
    }
}
