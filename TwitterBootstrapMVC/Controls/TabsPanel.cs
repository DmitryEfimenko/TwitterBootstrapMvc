using System;
using System.IO;
using System.Web.Mvc;

namespace TwitterBootstrapMVC.Controls
{
    public class TabsPanel : IDisposable
    {
        private readonly TextWriter textWriter;
        private string _tag;

        internal TabsPanel(TextWriter writer, string tag, string id, bool isActive = false)
        {
            if (string.IsNullOrWhiteSpace(tag)) throw new ArgumentNullException("tag");
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException("id");

            this.textWriter = writer;
            this._tag = tag;
            TagBuilder builder = new TagBuilder(this._tag);
            builder.Attributes.Add("id", id);
            builder.AddCssClass("tab-pane");

            if (isActive) builder.AddCssClass("active");

            this.textWriter.Write(builder.ToString(TagRenderMode.StartTag));
        }

        public void Dispose()
        {
            this.textWriter.Write("</{0}>", this._tag);
        }
    }
}
