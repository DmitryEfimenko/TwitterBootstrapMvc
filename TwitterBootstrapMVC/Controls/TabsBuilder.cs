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
        private int tabIndex;
        private Queue<string> tabIds;
        private bool isFirstTab = true;
        private string activeTabId;
        private bool isHeaderClosed;

        internal TabsBuilder(HtmlHelper<TModel> htmlHelper, Tabs tabs)
            : base(htmlHelper, tabs)
        {
            tabIndex = 1;
            this.tabIds = new Queue<string>();
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

            string tabId = base.element.Id + "-" + tabIndex;
            this.tabIds.Enqueue(tabId);
            
            if (isFirstTab)
            {
                activeTabId = tabId;
                this.WriteTab(label, "#" + tabId, true);
                isFirstTab = false;
            }
            else
            {
                this.WriteTab(label, "#" + tabId, false);
            }

            tabIndex++;
        }

        public TabsPanel BeginPanel()
        {
            if (!this.isHeaderClosed)
            {
                base.textWriter.Write("</ul>");
                this.isHeaderClosed = true;
            }

            string tabId = this.tabIds.Dequeue();
            if (tabId == activeTabId)
            {
                base.textWriter.Write(@"<div class=""tab-content"">");
                isFirstTab = false;
                return new TabsPanel(base.textWriter, "div", tabId, true);
            }

            return new TabsPanel(base.textWriter, "div", tabId);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Dispose()
        {
            if (tabIndex == 1) throw new ArgumentNullException("Tab", "You should specify at least one tab");
            if (tabIds.Count > 0) throw new ArgumentNullException("BeginPanel", "The number of panels should be the same as the number of tabs.");

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
