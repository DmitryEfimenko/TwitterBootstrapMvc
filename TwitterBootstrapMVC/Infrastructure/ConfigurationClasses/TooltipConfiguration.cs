using System;
using System.Collections.Generic;
using System.ComponentModel;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC
{
    public class TooltipConfiguration
    {
        public bool? Animation;
        public bool? Html;
        public string Placement;
        public string Selector;
        protected string Title;
        public string Trigger;

        public TooltipConfiguration(string title)
        {
            Title = title;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual IDictionary<string, object> ToDictionary()
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            
            result.AddIfNotExist("rel", "tooltip");
            if (Animation.HasValue) result.AddIfNotExist("data-animation", Animation.Value ? "true" : "false");
            if (Html.HasValue) result.AddIfNotExist("data-html", Html.Value ? "true" : "false");
            if (!string.IsNullOrEmpty(Placement)) result.AddIfNotExist("data-placement", Placement);
            if (!string.IsNullOrEmpty(Selector)) result.AddIfNotExist("data-selector", Selector);
            if (!string.IsNullOrEmpty(Title)) result.AddIfNotExist("data-title", Title);
            if (!string.IsNullOrEmpty(Trigger)) result.AddIfNotExist("data-trigger", Trigger);
            result.AddIfNotExist("data-placement", "right");
            
            return result;
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
