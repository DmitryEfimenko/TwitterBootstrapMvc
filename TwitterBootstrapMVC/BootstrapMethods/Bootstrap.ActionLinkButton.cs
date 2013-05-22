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
        
        public BootstrapActionLinkButton ActionLinkButton(string linkText, string actionName)
        {
            return new BootstrapActionLinkButton(Html, linkText, actionName);
        }

        public BootstrapActionLinkButton ActionLinkButton(string linkText, string actionName, object routeValues)
        {
            return new BootstrapActionLinkButton(Html, linkText, actionName, routeValues);
        }

        public BootstrapActionLinkButton ActionLinkButton(string linkText, string actionName, string controllerName)
        {
            return new BootstrapActionLinkButton(Html, linkText, actionName, controllerName);
        }

        public BootstrapActionLinkButton ActionLinkButton(string linkText, string actionName, string controllerName, object routeValues)
        {
            return new BootstrapActionLinkButton(Html, linkText, actionName, controllerName, routeValues);
        }

        public BootstrapActionLinkButton ActionLinkButton(string linkText, ActionResult result, string protocol = null, string hostName = null, string fragment = null)
        {
            return new BootstrapActionLinkButton(Html, linkText, null, protocol ?? result.GetT4MVCResult().Protocol, hostName, fragment, result.GetRouteValueDictionary());
        }

        public BootstrapActionLinkButton ActionLinkButton(string linkText, string actionName, string controllerName, string protocol, string hostName, string fragment, object routeValues)
        {
            return new BootstrapActionLinkButton(Html, linkText, actionName, controllerName, protocol, hostName, fragment, routeValues);
        }
    }
}
