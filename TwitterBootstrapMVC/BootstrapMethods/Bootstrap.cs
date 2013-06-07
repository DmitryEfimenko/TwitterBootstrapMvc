using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using TwitterBootstrapMVC.Controls;

namespace TwitterBootstrapMVC.BootstrapMethods
{
    public partial class Bootstrap<TModel>
    {
        public HtmlHelper<TModel> Html;

        public Bootstrap(HtmlHelper<TModel> _html)
        {
            this.Html = _html;
        }

        public BootstrapControlGroup<TModel> ControlGroup()
        {
            return new BootstrapControlGroup<TModel>(Html);
        }

        public BootstrapHelpText HelpText(string text, HelpTextStyle style)
        {
            return new BootstrapHelpText(text, style);
        }

        public BootstrapDropDownMenu DropDownMenu()
        {
            return new BootstrapDropDownMenu();
        }

        [Obsolete("Container() is deprecated, please use Begin() instead.")]
        public BootstrapContainer Container()
        {
            return new BootstrapContainer(Html);
        }

        public BootstrapIcon Icon(Icons icon)
        {
            return new BootstrapIcon(icon);
        }

        public BootstrapIcon Icon(string customCssClass)
        {
            return new BootstrapIcon(customCssClass);
        }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() { return null; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) { return base.Equals(obj); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() { return base.GetHashCode(); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Type GetType() { return base.GetType(); }
    }
}
