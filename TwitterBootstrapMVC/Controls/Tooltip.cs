using System;
using System.Collections.Generic;
using System.ComponentModel;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC
{
    public class Tooltip : TooltipBase<Tooltip>
    {
        public Tooltip(string title)
            : base(title, "tooltip")
        {
        }
    }

    public class Popover : TooltipBase<Popover>
    {
        public Popover(string title, string content)
            : base(title, content, "popover")
        {
        }

        public Popover Closeable()
        {
            Html(true);
            SetTitle(GetTitle() + @"<span class='pull-right close'>&times;</span>");
            return this;
        }
    }

    public class TooltipBase<T> where T : TooltipBase<T>
    {
        private readonly string _type;
        private readonly string _content;
        private string _title;
        private bool? _animation;
        private bool? _html;
        private string _placement;
        private string _selector;
        private string _trigger;

        public TooltipBase(string title, string type)
        {
            _title = title;
            _type = type;
        }

        public TooltipBase(string title, string content, string type)
        {
            _title = title;
            _content = content;
            _type = type;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual IDictionary<string, object> ToDictionary()
        {
            var result = new Dictionary<string, object>();

            result.AddIfNotExist("rel", _type);
            if (_animation.HasValue) result.AddIfNotExist("data-animation", _animation.Value ? "true" : "false");
            if (_html.HasValue) result.AddIfNotExist("data-html", _html.Value ? "true" : "false");
            if (!string.IsNullOrEmpty(_placement)) result.AddIfNotExist("data-placement", _placement);
            if (!string.IsNullOrEmpty(_selector)) result.AddIfNotExist("data-selector", _selector);
            if (!string.IsNullOrEmpty(_title)) result.AddIfNotExist("data-title", _title);
            if (!string.IsNullOrEmpty(_trigger)) result.AddIfNotExist("data-trigger", _trigger);
            if (_type == "popover" && !string.IsNullOrEmpty(_content)) result.AddIfNotExist("data-content", _content);
            result.AddIfNotExist("data-placement", "right");
            
            return result;
        }

        public T Animation(bool allowAnimation)
        {
            _animation = allowAnimation;
            return (T)this;
        }

        public T Html(bool allowHtml)
        {
            _html = allowHtml;
            return (T)this;
        }

        public T Placement(string placement)
        {
            _placement = placement;
            return (T)this;
        }

        public T Selector(string selector)
        {
            _selector = selector;
            return (T)this;
        }

        public T Trigger(string trigger)
        {
            _trigger = trigger;
            return (T)this;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public T SetTitle(string title)
        {
            _title = title;
            return (T)this;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GetTitle()
        {
            return _title;
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
