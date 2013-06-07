using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TwitterBootstrapMVC.Controls;

namespace TwitterBootstrapMVC.BootstrapMethods
{
    public partial class Bootstrap<TModel>
    {
        public BootstrapActionLinkButton ActionLinkButton(string linkText, ActionResult result)
        {
            return new BootstrapActionLinkButton(Html, linkText, result);
        }

        public BootstrapActionLinkButton ActionLinkButton(string linkText, Task<ActionResult> taskResult)
        {
            return new BootstrapActionLinkButton(Html, linkText, taskResult);
        }
        
        public BootstrapActionLinkButton ActionLinkButton(string linkText, string actionName)
        {
            return new BootstrapActionLinkButton(Html, linkText, actionName);
        }

        public BootstrapActionLinkButton ActionLinkButton(string linkText, string actionName, string controllerName)
        {
            return new BootstrapActionLinkButton(Html, linkText, actionName, controllerName);
        }

        public BootstrapLink Link(string linkText, string url)
        {
            return new BootstrapLink(Html, linkText, url);
        }

        public BootstrapActionLink ActionLink(string linkText, ActionResult result)
        {
            return new BootstrapActionLink(Html, linkText, result);
        }

        public BootstrapActionLink ActionLink(string linkText, Task<ActionResult> taskResult)
        {
            return new BootstrapActionLink(Html, linkText, taskResult);
        }

        public BootstrapActionLink ActionLink(string linkText, string actionName)
        {
            return new BootstrapActionLink(Html, linkText, actionName);
        }

        public BootstrapActionLink ActionLink(string linkText, string actionName, string controllerName)
        {
            return new BootstrapActionLink(Html, linkText, actionName, controllerName);
        }
    }
}
