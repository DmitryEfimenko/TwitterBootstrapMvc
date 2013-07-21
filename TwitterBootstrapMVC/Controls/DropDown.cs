using System.ComponentModel;
using TwitterBootstrapMVC.Infrastructure;

namespace TwitterBootstrapMVC
{
    public class DropDown : HtmlElement
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string _actionText;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool _activeLinksByController;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool _activeLinksByControllerAndAction;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool _activeLinksByAreaControllerAction;

        public DropDown(string actionText)
            : base(null)
        {
            _actionText = actionText;
        }

        public DropDown SetLinksActiveByController()
        {
            _activeLinksByController = true;
            return this;
        }

        public DropDown SetLinksActiveByControllerAndAction()
        {
            _activeLinksByControllerAndAction = true;
            return this;
        }

        public DropDown SetLinksActiveByAreaControllerAction()
        {
            _activeLinksByAreaControllerAction = true;
            return this;
        }
    }
}
