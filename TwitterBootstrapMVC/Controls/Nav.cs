using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwitterBootstrapMVC.Infrastructure;

namespace TwitterBootstrapMVC
{
    public class Nav : HtmlElement
    {
        public Nav()
            : base("ul")
        {
            EnsureClass("nav nav-tabs");
        }

        public Nav Style(NavType type)
        {
            EnsureClassRemoval("nav-tabs");
            switch (type)
            {
                case NavType.Tabs:
                    EnsureClass("nav-tabs");
                    break;
                case NavType.Pills:
                    EnsureClass("bav-pills");
                    break;
                case NavType.List:
                    EnsureClass("nav-tabs");
                    break;
                default:
                    break;
            }
            return this;
        }

        public Nav Stacked()
        {
            EnsureClass("nav-stacked");
            return this;
        }
    }
}
