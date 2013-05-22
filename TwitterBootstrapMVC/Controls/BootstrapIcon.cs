using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TwitterBootstrapMVC.ControlInterfaces;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Controls
{
    public class BootstrapIcon : IHtmlString
    {
        private Icons _icon;
        private bool _isWhite;
        private object _htmlAttributes;
        private TooltipConfiguration _tooltipConfiguration;
        private PopoverConfiguration _popoverConfiguration;
        private string _iconCustomClass;

        public BootstrapIcon(Icons icon)
        {
            this._icon = icon;
        }

        public BootstrapIcon(Icons icon, bool isWhite)
        {
            this._icon = icon;
            this._isWhite = isWhite;
        }

        public BootstrapIcon(string iconCustomClass)
        {
            this._iconCustomClass = iconCustomClass;
        }

        public BootstrapIcon White()
        {
            this._isWhite = true;
            return this;
        }

        public BootstrapIcon HtmlAttributes(object htmlAttributes)
        {
            this._htmlAttributes = htmlAttributes;
            return this;
        }

        public BootstrapIcon Tooltip(TooltipConfiguration configuration)
        {
            this._tooltipConfiguration = configuration;
            return this;
        }

        public BootstrapIcon Tooltip(string title)
        {
            this._tooltipConfiguration = new TooltipConfiguration(title);
            return this;
        }

        public BootstrapIcon Popover(PopoverConfiguration configuration)
        {
            this._popoverConfiguration = configuration;
            return this;
        }

        public BootstrapIcon Popover(string title, string content)
        {
            this._popoverConfiguration = new PopoverConfiguration(title, content);
            return this;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual string ToHtmlString()
        {
            TagBuilder i = new TagBuilder("i");
            var attrs = _htmlAttributes.ToDictionary().FormatHtmlAttributes() ?? new Dictionary<string, object>();
            if (_tooltipConfiguration != null) attrs.AddRange(_tooltipConfiguration.ToDictionary());
            if (_popoverConfiguration != null) attrs.AddRange(_popoverConfiguration.ToDictionary());
            i.MergeAttributes(attrs, true);
            if(_icon != Icons._not_set) i.AddCssClass(_icon.GetEnumDescription());
            if (!string.IsNullOrEmpty(_iconCustomClass)) i.AddCssClass(_iconCustomClass);
            if (_isWhite) i.AddCssClass("icon-white");
            
            return i.ToString(TagRenderMode.Normal);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() { return ToHtmlString(); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) { return base.Equals(obj); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() { return base.GetHashCode(); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Type GetType() { return base.GetType(); }
    }
}
