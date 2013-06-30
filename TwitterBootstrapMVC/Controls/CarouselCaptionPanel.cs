using System;
using System.IO;

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
