using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TwitterBootstrapMVC.Controls
{
    public class ModalSectionPanel : IDisposable
    {
        private readonly TextWriter textWriter;

        internal ModalSectionPanel(ModalSection section, TextWriter writer)
        {
            this.textWriter = writer;

            switch (section)
            {
                case ModalSection.Header: this.textWriter.Write(@"<div class=""modal-header"">"); break;
                case ModalSection.Body: this.textWriter.Write(@"<div class=""modal-body"">"); break;
                case ModalSection.Footer: this.textWriter.Write(@"<div class=""modal-footer"">"); break;
            }
        }

        public void Dispose()
        {
            this.textWriter.Write("</div>");
        }
    }

    internal enum ModalSection
    {
        Header,
        Body,
        Footer
    }
}
