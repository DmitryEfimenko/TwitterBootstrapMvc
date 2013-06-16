using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using TwitterBootstrapMVC.Infrastructure;

namespace TwitterBootstrapMVC
{
    public class DropDown : HtmlElement
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string _actionText;

        public DropDown(string actionText)
            : base(null)
        {
            this._actionText = actionText;
        }
    }
}
