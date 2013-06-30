using System.ComponentModel;
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
