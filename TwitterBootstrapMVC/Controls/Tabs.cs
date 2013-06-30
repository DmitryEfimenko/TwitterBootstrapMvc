using System.ComponentModel;
using TwitterBootstrapMVC.Infrastructure;

namespace TwitterBootstrapMVC
{
    public class Tabs : HtmlElement
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string _id { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public NavType Type { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public int _activeTabIndex { get; set; }

        public Tabs(string id)
            : base("div")
        {
            this._id = id;
            EnsureClass("tabbable");
            this.Type = NavType.Tabs;
        }

        public Tabs Position(Direction position)
        {
            switch (position)
            {
                case Direction.Left:
                    EnsureClass("tabs-left");
                    break;
                case Direction.Right:
                    EnsureClass("tabs-right");
                    break;
                case Direction.Bottom:
                    EnsureClass("tabs-below");
                    break;
            }
            return this;
        }

        public Tabs ActiveTab(int activeTabIndex)
        {
            _activeTabIndex = activeTabIndex;
            return this;
        }

        public Tabs Style(NavType type)
        {
            this.Type = type;
            return this;
        }
    }
}
