using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using TwitterBootstrapMVC.Infrastructure;

namespace TwitterBootstrapMVC.Controls
{
    public class AccordionBuilder<TModel> : BuilderBase<TModel, Accordion>
    {
        private int PanelsCount { get; set; }

        internal AccordionBuilder(HtmlHelper<TModel> htmlHelper, Accordion accordion)
            : base(htmlHelper, accordion)
        {
        }

        public AccordionPanel BeginPanel(string title)
        {
            this.PanelsCount++;
            return new AccordionPanel(base.textWriter, title, base.element.Id + "-" + this.PanelsCount.ToString(), base.element.Id);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
