using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace TwitterBootstrapMVC.Controls
{
    public class ModalSectionPanel : IDisposable
    {
        private readonly TextWriter textWriter;

        internal ModalSectionPanel(ModalSection section, TextWriter writer, bool isCloseable)
        {
            this.textWriter = writer;

            switch (section)
            {
                case ModalSection.Header: 
                    this.textWriter.Write(@"<div class=""modal-header"">");
                    if (isCloseable) this.textWriter.Write(@"<button type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true"">&times;</button>");
                    break;
                case ModalSection.Body: this.textWriter.Write(@"<div class=""modal-body"">"); break;
                case ModalSection.Footer: this.textWriter.Write(@"<div class=""modal-footer"">"); break;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose()
        {
            this.textWriter.Write("</div>");
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

    internal enum ModalSection
    {
        Header,
        Body,
        Footer
    }
}
