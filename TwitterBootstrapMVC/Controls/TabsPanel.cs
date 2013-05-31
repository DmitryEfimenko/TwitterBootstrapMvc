using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace TwitterBootstrapMVC.Controls
{
    public class TabsPanel : IDisposable
    {
        private string tag;
        private readonly TextWriter textWriter;

        internal TabsPanel(TextWriter writer, string tag, string id, bool isActive = false)
        {
            if (string.IsNullOrWhiteSpace(tag)) throw new ArgumentNullException("tag");
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException("id");

            this.textWriter = writer;
            this.tag = tag;
            TagBuilder builder = new TagBuilder(this.tag);
            builder.Attributes.Add("id", id);
            builder.AddCssClass("tab-pane");

            if (isActive) builder.AddCssClass("active");

            this.textWriter.Write(builder.ToString(TagRenderMode.StartTag));
        }

        public void Dispose()
        {
            this.textWriter.Write("</{0}>", this.tag);
        }
    }
}
