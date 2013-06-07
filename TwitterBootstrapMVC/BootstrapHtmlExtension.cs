using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TwitterBootstrapMVC.BootstrapMethods;

namespace TwitterBootstrapMVC
{
    public static class BootstrapHtmlExtension
    {
        public static Bootstrap<TModel> Bootstrap<TModel>(this HtmlHelper<TModel> helper)
        {
            return new Bootstrap<TModel>(helper);
        }

        public static BootstrapAjax<TModel> Bootstrap<TModel>(this AjaxHelper<TModel> helper)
        {
            return new BootstrapAjax<TModel>(helper);
        }
    }
}
