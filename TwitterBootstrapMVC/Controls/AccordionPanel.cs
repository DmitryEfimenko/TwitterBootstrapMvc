using System;
using System.IO;
using System.Web.Mvc;

namespace TwitterBootstrapMVC.Controls
{
    public class AccordionPanel : IDisposable
    {
        private readonly TextWriter textWriter;

        internal AccordionPanel(TextWriter writer, string title, string panelId, string parentAccordionId)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException("title");
            }

            this.textWriter = writer;

            this.textWriter.Write(@"<div class=""accordion-group"">");

            TagBuilder builder = new TagBuilder("div");
            builder.AddCssClass("accordion-heading");

            TagBuilder builder2 = new TagBuilder("a");
            builder2.Attributes.Add("href", "#" + panelId);
            builder2.AddCssClass("accordion-toggle");
            builder2.InnerHtml = title;
            builder2.MergeAttribute("data-toggle", "collapse");
            builder2.MergeAttribute("data-parent", "#" + parentAccordionId);

            builder.InnerHtml = builder2.ToString();

            this.textWriter.Write(builder.ToString());

            builder = new TagBuilder("div");
            builder.AddCssClass("accordion-body collapse");
            builder.MergeAttribute("id", panelId);

            this.textWriter.Write(builder.ToString(TagRenderMode.StartTag));
            this.textWriter.Write(@"<div class=""accordion-inner"">");
        }

        public void Dispose()
        {
            this.textWriter.Write("</div></div></div>");
        }
    }
}
