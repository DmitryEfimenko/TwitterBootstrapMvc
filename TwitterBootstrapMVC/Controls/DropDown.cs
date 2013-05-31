using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwitterBootstrapMVC.Infrastructure;

namespace TwitterBootstrapMVC
{
    public class DropDown : HtmlElement
    {
        public string actionText;

        public DropDown(string actionText)
            : base(null)
        {
            this.actionText = actionText;
        }
    }
}
