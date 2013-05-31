using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TwitterBootstrapMVC.Controls
{
    public class CarouselCaptionPanel : IDisposable
    {
        private readonly TextWriter textWriter;

        internal CarouselCaptionPanel(TextWriter writer)
        {
            this.textWriter = writer;
            this.textWriter.Write(@"<div class=""carousel-caption"">");
        }

        public void Dispose()
        {
            this.textWriter.Write("</div></div>");
        }
    }
}
