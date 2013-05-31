using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace TwitterBootstrapMVC.Controls
{
    public class CarouselCustomItem : IDisposable
    {
        private readonly TextWriter textWriter;
        private readonly UrlHelper urlHelper;

        internal CarouselCustomItem(TextWriter writer, UrlHelper urlHelper, bool isFirstItem)
        {
            this.textWriter = writer;
            this.urlHelper = urlHelper;
            if (isFirstItem)
            {
                this.textWriter.Write(@"<div class=""item active"">");
            }
            else
            {
                this.textWriter.Write(@"<div class=""item"">");
            }
        }

        public void Dispose()
        {
            this.textWriter.Write("</div>");
        }
    }
}
