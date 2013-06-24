using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using TwitterBootstrapMVC.Infrastructure;

namespace TwitterBootstrapMVC.Controls
{
    public class ModalBuilder<TModel> : BuilderBase<TModel, Modal>
    {
        internal ModalBuilder(HtmlHelper<TModel> htmlHelper, Modal modal)
            : base(htmlHelper, modal)
        {
        }

        public ModalSectionPanel BeginHeader()
        {
            return new ModalSectionPanel(ModalSection.Header, base.textWriter, base.element._closeable);
        }

        public ModalSectionPanel BeginBody()
        {
            return new ModalSectionPanel(ModalSection.Body, base.textWriter, false);
        }

        public ModalSectionPanel BeginFooter()
        {
            return new ModalSectionPanel(ModalSection.Footer, base.textWriter, false);
        }
    }
}
