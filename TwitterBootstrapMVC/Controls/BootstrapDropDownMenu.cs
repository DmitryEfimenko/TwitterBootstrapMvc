using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Controls
{
    public class BootstrapDropDownMenu : IHtmlString
    {
        private List<BootstrapDropDownMenuItem> _menuItems;
        private string _alignToDirection;
        private IDictionary<string, object> _htmlAttributes;
        private int? _maxHeight;

        public BootstrapDropDownMenu()
        {
            _menuItems = new List<BootstrapDropDownMenuItem>();
            _alignToDirection = "left";
        }

        public BootstrapDropDownMenu MenuItems(Action<DropDownMenuBuilder> dropDownMenuBuilder)
        {
            DropDownMenuBuilder builder = new DropDownMenuBuilder();
            dropDownMenuBuilder(builder);

            foreach (var item in builder)
            {
                _menuItems.Add(item);
            }
            return this;
        }

        public BootstrapDropDownMenu MaxHeight(int heightInPixels)
        {
            this._maxHeight = heightInPixels;
            return this;
        }

        public BootstrapDropDownMenu HtmlAttributes(IDictionary<string, object> htmlAttributes)
        {
            this._htmlAttributes = htmlAttributes;
            return this;
        }

        public BootstrapDropDownMenu HtmlAttributes(object htmlAttributes)
        {
            this._htmlAttributes = htmlAttributes.ToDictionary();
            return this;
        }

        /// <summary>
        /// Allign menu to "right" or "left"
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public BootstrapDropDownMenu AlignTo(string direction)
        {
            if (string.IsNullOrEmpty(direction) || (direction.Trim().ToLower() != "right" && direction.Trim().ToLower() != "left")) return this;
            _alignToDirection = direction;
            return this;
        }


        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ToHtmlString()
        {
            TagBuilder ul = new TagBuilder("ul");
            ul.MergeAttributes(_htmlAttributes.FormatHtmlAttributes());
            if(_maxHeight.HasValue)
            {
                ul.AddCssStyle("max-height", _maxHeight.ToString() + "px");
                ul.AddCssStyle("overflow-y", "scroll");
            }
            ul.AddCssClass("dropdown-menu");
            if (_alignToDirection == "right") ul.AddCssClass("pull-right");
            
            _menuItems.ForEach(x => ul.InnerHtml += x.ToHtmlString());

            return ul.ToString(TagRenderMode.Normal);
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

    public class DropDownMenuBuilder : IList<BootstrapDropDownMenuItem>
    {
        private readonly List<BootstrapDropDownMenuItem> _menuItems = new List<BootstrapDropDownMenuItem>();

        public BootstrapDropDownMenuItem MenuItem(MvcHtmlString actionLink)
        {
            var item = new BootstrapDropDownMenuItem(actionLink);
            Add(item);
            return item; 
        }

        public BootstrapDropDownMenuItem MenuItem(string link)
        {
            var item = new BootstrapDropDownMenuItem(link);
            Add(item);
            return item;
        }

        public BootstrapDropDownMenuItem Divider()
        {
            var item = new BootstrapDropDownMenuItem(true);
            Add(item);
            return item;
        }

        public int IndexOf(BootstrapDropDownMenuItem item)
        {
            return _menuItems.IndexOf(item);
        }

        public void Insert(int index, BootstrapDropDownMenuItem item)
        {
            _menuItems.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _menuItems.RemoveAt(index);
        }

        public BootstrapDropDownMenuItem this[int index]
        {
            get { return _menuItems[index]; }
            set { _menuItems[index] = value; }
        }

        public void Add(BootstrapDropDownMenuItem item)
        {
            _menuItems.Add(item);
        }

        public void Clear()
        {
            _menuItems.Clear();
        }

        public bool Contains(BootstrapDropDownMenuItem item)
        {
            return _menuItems.Contains(item);
        }

        public void CopyTo(BootstrapDropDownMenuItem[] array, int arrayIndex)
        {
            _menuItems.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _menuItems.Count(); }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(BootstrapDropDownMenuItem item)
        {
            return _menuItems.Remove(item);
        }

        public IEnumerator<BootstrapDropDownMenuItem> GetEnumerator()
        {
            return _menuItems.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
