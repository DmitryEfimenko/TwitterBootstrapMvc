using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Web.Mvc;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC
{
    public class Typehead
    {
        private ActionResult _result;
        private Task<ActionResult> _taskResult;
        private string _actionName;
        private string _controllerName;
        private string _source;
        private int? _items;
        private int? _minLength;
        private string _matcher;
        private string _sorter;
        private string _updater;
        private string _highlighter;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual IDictionary<string, object> ToDictionary(HtmlHelper html)
        {
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);
            var result = new Dictionary<string, object>();

            result.AddIfNotExist("data-provide", "typeahead");
            result.AddIfNotExist("autocomplete", "off");
            if (_result != null) result.AddIfNotExist("data-url", urlHelper.Action(_result));
            if (_taskResult != null) result.AddIfNotExist("data-url", urlHelper.Action(_taskResult));
            if (!string.IsNullOrEmpty(_actionName) || !string.IsNullOrEmpty(_controllerName))
                result.AddIfNotExist("data-url", urlHelper.Action(actionName: _actionName, controllerName: _controllerName));
            if (_items.HasValue) result.AddIfNotExist("data-items", _items.Value.ToString());
            if (_minLength.HasValue) result.AddIfNotExist("data-minLength", _minLength.Value.ToString());
            if (!string.IsNullOrEmpty(_source)) result.AddIfNotExist("data-source", _source);
            if (!string.IsNullOrEmpty(_matcher)) result.AddIfNotExist("data-matcher", _matcher);
            if (!string.IsNullOrEmpty(_sorter)) result.AddIfNotExist("data-sorter", _sorter);
            if (!string.IsNullOrEmpty(_updater)) result.AddIfNotExist("data-updater", _updater);
            if (!string.IsNullOrEmpty(_highlighter)) result.AddIfNotExist("data-highlighter", _highlighter);

            return result;
        }

        public Typehead ActionResult(ActionResult result)
        {
            _result = result;
            return this;
        }

        public Typehead TaskResult(Task<ActionResult> taskResult)
        {
            _taskResult = taskResult;
            return this;
        }

        public Typehead Action(string action)
        {
            _actionName = action;
            return this;
        }

        public Typehead Controller(string controller)
        {
            _controllerName = controller;
            return this;
        }

        public Typehead Source(string source)
        {
            _source = source;
            return this;
        }

        public Typehead Items(int items)
        {
            _items = items;
            return this;
        }

        public Typehead MinLength(int minLength)
        {
            _minLength = minLength;
            return this;
        }

        public Typehead Matcher(string matcher)
        {
            _matcher = matcher;
            return this;
        }

        public Typehead Sorter(string sorter)
        {
            _sorter = sorter;
            return this;
        }

        public Typehead Updater(string updater)
        {
            _updater = updater;
            return this;
        }

        public Typehead Highlighter(string highlighter)
        {
            _highlighter = highlighter;
            return this;
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
