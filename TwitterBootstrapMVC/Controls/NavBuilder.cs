using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using TwitterBootstrapMVC.Infrastructure;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Controls
{
    public class NavBuilder<TModel> : BuilderBase<TModel, Nav>
    {
        private readonly UrlHelper urlHelper;

        internal NavBuilder(HtmlHelper<TModel> htmlHelper, Nav nav)
            : base(htmlHelper, nav)
        {
            this.urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
        }

        public BootstrapLink Link(string linkText, string url)
        {
            return new BootstrapLink(base.htmlHelper, linkText, url).WrapInto("li");
        }

        public BootstrapActionLink ActionLink(string linkText, ActionResult result)
        {
            return new BootstrapActionLink(htmlHelper, linkText, result).WrapInto("li");
        }

        public BootstrapActionLink ActionLink(string linkText, string actionName)
        {
            return new BootstrapActionLink(htmlHelper, linkText, actionName).WrapInto("li");
        }

        public BootstrapActionLink ActionLink(string linkText, string actionName, string controllerName)
        {
            return new BootstrapActionLink(htmlHelper, linkText, actionName, controllerName).WrapInto("li");
        }
    }
}
