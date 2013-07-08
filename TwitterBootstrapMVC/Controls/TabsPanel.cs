using System;
using System.ComponentModel;
using System.IO;
using System.Web.Mvc;

namespace TwitterBootstrapMVC.Controls
{
    public class TabsPanel : IDisposable
    {
        private readonly TextWriter _textWriter;
        private readonly string _tag;

        internal TabsPanel(TextWriter writer, string tag, string id, bool isActive = false)
        {
            if (string.IsNullOrWhiteSpace(tag)) throw new ArgumentNullException("tag");
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException("id");

            _textWriter = writer;
            _tag = tag;
            var builder = new TagBuilder(_tag);
            builder.Attributes.Add("id", id);
            builder.AddCssClass("tab-pane");

            if (isActive) builder.AddCssClass("active");

            _textWriter.Write(builder.ToString(TagRenderMode.StartTag));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose()
        {
            this._textWriter.Write("</{0}>", this._tag);
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
