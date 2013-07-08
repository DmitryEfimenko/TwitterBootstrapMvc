using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;
using TwitterBootstrapMVC.Infrastructure;

namespace TwitterBootstrapMVC.Controls
{
    public class TabsBuilder<TModel> : BuilderBase<TModel, Tabs>
    {
        private int _tabIndex;
        private int _panelIndex;
        private readonly Queue<string> _tabIds;
        private bool _isFirstTab = true;
        private int _activeTabIndex;
        private bool _isHeaderClosed;

        internal TabsBuilder(HtmlHelper<TModel> htmlHelper, Tabs tabs)
            : base(htmlHelper, tabs)
        {
            _tabIndex = 1;
            _activeTabIndex = element._activeTabIndex;
            _tabIds = new Queue<string>();
            switch (element.Type)
            {
                case NavType.Pills:
                    textWriter.Write(@"<ul class=""nav nav-pills"">");
                    break;
                case NavType.List:
                    textWriter.Write(@"<ul class=""nav nav-list"">");
                    break;
                default:
                    textWriter.Write(@"<ul class=""nav nav-tabs"">");
                    break;
            }
        }

        public void Tab(string label)
        {
            if (string.IsNullOrWhiteSpace(label))
                throw new ArgumentNullException("label");

            var tabId = base.element._id + "-" + _tabIndex;
            _tabIds.Enqueue(tabId);
            
            if (_isFirstTab)
            {
                if (_activeTabIndex == 0) _activeTabIndex = 1;
                WriteTab(label, tabId, _tabIndex == _activeTabIndex);
                _isFirstTab = false;
            }
            else
            {
                WriteTab(label, tabId, _tabIndex == _activeTabIndex);
            }

            _tabIndex++;
        }

        public TabsPanel BeginPanel()
        {
            _panelIndex++;
            if (!_isHeaderClosed)
            {
                textWriter.Write("</ul>");
                _isHeaderClosed = true;
            }

            var tabId = _tabIds.Dequeue();
            if (_panelIndex == 1)
            {
                textWriter.Write(@"<div class=""tab-content"">");
                _isFirstTab = false;
                return new TabsPanel(textWriter, "div", tabId, _panelIndex == _activeTabIndex);
            }

            return new TabsPanel(base.textWriter, "div", tabId, _panelIndex == _activeTabIndex);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Dispose()
        {
            if (_tabIndex == 1) throw new ArgumentNullException("Tab", "You should specify at least one tab");
            if (_tabIds.Count > 0) throw new ArgumentNullException("BeginPanel", "The number of panels should be the same as the number of tabs.");

            // Close Tab Content Div:
            textWriter.Write("</div>");
            base.Dispose();
        }

        private void WriteTab(string label, string href, bool isActive)
        {
            textWriter.Write(isActive
                ? string.Format(@"<li class=""active""><a data-toggle=""tab"" href=""#{1}"">{0}</a></li>", label, href)
                : string.Format(@"<li><a data-toggle=""tab"" href=""#{1}"">{0}</a></li>", label, href)
            );
        }
    }
}
