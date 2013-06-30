using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.Mvc;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Controls
{
    public class BootstrapIcon : IHtmlString
    {
        private readonly Icons _icon;
        private bool _isWhite;
        private IDictionary<string, object> _htmlAttributes;
        private TooltipConfiguration _tooltipConfiguration;
        private Tooltip _tooltip;
        private PopoverConfiguration _popoverConfiguration;
        private Popover _popover;
        private readonly string _iconCustomClass;

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

        public BootstrapIcon HtmlAttributes(IDictionary<string, object> htmlAttributes)
        {
            this._htmlAttributes = htmlAttributes;
            return this;
        }

        public BootstrapIcon HtmlAttributes(object htmlAttributes)
        {
            this._htmlAttributes = htmlAttributes.ToDictionary();
            return this;
        }

        [Obsolete("This overload is deprecated and will be removed in the future versions. Use .Tooltip(Tooltip tooltip) instead.")]
        public BootstrapIcon Tooltip(TooltipConfiguration configuration)
        {
            this._tooltipConfiguration = configuration;
            return this;
        }

        public BootstrapIcon Tooltip(Tooltip tooltip)
        {
            this._tooltip = tooltip;
            return this;
        }

        public BootstrapIcon Tooltip(string title)
        {
            this._tooltip = new Tooltip(title);
            return this;
        }

        [Obsolete("This overload is deprecated and will be removed in the future versions. Use .Popover(Popover popover) instead.")]
        public BootstrapIcon Popover(PopoverConfiguration configuration)
        {
            this._popoverConfiguration = configuration;
            return this;
        }

        public BootstrapIcon Popover(Popover popover)
        {
            this._popover = popover;
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
            var attrs = _htmlAttributes.FormatHtmlAttributes() ?? new Dictionary<string, object>();
            if (_tooltipConfiguration != null) attrs.MergeHtmlAttributes(_tooltipConfiguration.ToDictionary());
            if (_tooltip != null) attrs.MergeHtmlAttributes(_tooltip.ToDictionary());
            if (_popoverConfiguration != null) attrs.MergeHtmlAttributes(_popoverConfiguration.ToDictionary());
            if (_popover != null) attrs.MergeHtmlAttributes(_popover.ToDictionary());
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
