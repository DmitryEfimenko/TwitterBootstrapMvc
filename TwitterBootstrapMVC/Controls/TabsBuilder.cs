using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using TwitterBootstrapMVC.Infrastructure;

namespace TwitterBootstrapMVC.Controls
{
    public class TabsBuilder<TModel> : BuilderBase<TModel, Tabs>
    {
        private int _tabIndex;
        private Queue<string> _tabIds;
        private bool _isFirstTab = true;
        private string _activeTabId;
        private bool _isHeaderClosed;

        internal TabsBuilder(HtmlHelper<TModel> htmlHelper, Tabs tabs)
            : base(htmlHelper, tabs)
        {
            _tabIndex = 1;
            this._tabIds = new Queue<string>();
            switch (base.element.Type)
            {
                case NavType.Pills:
                    base.textWriter.Write(@"<ul class=""nav nav-pills"">");
                    break;
                case NavType.List:
                    base.textWriter.Write(@"<ul class=""nav nav-list"">");
                    break;
                default:
                    base.textWriter.Write(@"<ul class=""nav nav-tabs"">");
                    break;
            }
        }

        public void Tab(string label)
        {
            if (string.IsNullOrWhiteSpace(label))
                throw new ArgumentNullException("label");

            string tabId = base.element._id + "-" + _tabIndex;
            this._tabIds.Enqueue(tabId);
            
            if (_isFirstTab)
            {
                _activeTabId = tabId;
                this.WriteTab(label, "#" + tabId, true);
                _isFirstTab = false;
            }
            else
            {
                this.WriteTab(label, "#" + tabId, false);
            }

            _tabIndex++;
        }

        public TabsPanel BeginPanel()
        {
            if (!this._isHeaderClosed)
            {
                base.textWriter.Write("</ul>");
                this._isHeaderClosed = true;
            }

            string tabId = this._tabIds.Dequeue();
            if (tabId == _activeTabId)
            {
                base.textWriter.Write(@"<div class=""tab-content"">");
                _isFirstTab = false;
                return new TabsPanel(base.textWriter, "div", tabId, true);
            }

            return new TabsPanel(base.textWriter, "div", tabId);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Dispose()
        {
            if (_tabIndex == 1) throw new ArgumentNullException("Tab", "You should specify at least one tab");
            if (_tabIds.Count > 0) throw new ArgumentNullException("BeginPanel", "The number of panels should be the same as the number of tabs.");

            // Close Tab Content Div:
            base.textWriter.Write("</div>");
            base.Dispose();
        }

        private void WriteTab(string label, string href, bool isActive)
        {
            if (isActive)
            {
                base.textWriter.Write(string.Format(@"<li class=""active""><a data-toggle=""tab"" href=""#{1}"">{0}</a></li>", label, href));
            }
            else
            {
                base.textWriter.Write(string.Format(@"<li><a data-toggle=""tab"" href=""#{1}"">{0}</a></li>", label, href));
            }
        }
    }
}
