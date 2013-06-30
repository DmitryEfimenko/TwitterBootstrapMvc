using System;
using System.ComponentModel;
using System.Web;
using System.Web.Mvc;

namespace TwitterBootstrapMVC.Controls
{
    public class BootstrapDropDownMenuItem : IHtmlString
    {
        private MvcHtmlString _menuItem;
        private BootstrapDropDownMenu _dropDownMenu;
        private bool _isDevider;
        private bool _active;

        public BootstrapDropDownMenuItem(MvcHtmlString actionLink)
        {
            this._menuItem = actionLink;
        }

        public BootstrapDropDownMenuItem(string link)
        {
            this._menuItem = MvcHtmlString.Create(link);
        }

        public BootstrapDropDownMenuItem(bool isDivider)
        {
            _isDevider = isDivider;
        }

        public BootstrapDropDownMenu DropDownMenu()
        {
            _dropDownMenu = new BootstrapDropDownMenu();
            return _dropDownMenu;
        }

        public BootstrapDropDownMenuItem Active(bool active)
        {
            this._active = active;
            return this;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ToHtmlString()
        {
            if (_isDevider) return "<li class=\"divider\"></li>";

            string menuItem = _menuItem.ToHtmlString().Replace("<a", "<a tabindex=\"-1\"");
            string dropDownmenu = _dropDownMenu != null ? _dropDownMenu.ToHtmlString() : string.Empty;
            string dropDownSubMenu = _dropDownMenu != null ? " class=\"dropdown-submenu\"" : string.Empty;
            string active = _active ? " class=\"active\"" : string.Empty;

            return string.Format("<li{2}{3}>{0}{1}</li>", menuItem, dropDownmenu, dropDownSubMenu, active);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() { return base.ToString(); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) { return base.Equals(obj); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() { return base.GetHashCode(); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Type GetType() { return base.GetType(); }
    }
}
