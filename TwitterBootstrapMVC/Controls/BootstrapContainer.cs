using System;
using System.ComponentModel;
using System.Web.Mvc;

namespace TwitterBootstrapMVC.Controls
{
    public class BootstrapContainer
    {
        private HtmlHelper html;

        public BootstrapContainer(HtmlHelper html)
        {
            this.html = html;
        }

        public BootstrapBeginDiv BeginFormActions()
        {
            return new BootstrapBeginDiv(html, "form-actions", null);
        }

        public BootstrapBeginDiv BeginFormActions(object htmlAttributes)
        {
            return new BootstrapBeginDiv(html, "form-actions", htmlAttributes);
        }

        public BootstrapBeginDiv ButtonToolBar()
        {
            return new BootstrapBeginDiv(html, "btn-toolbar", null);
        }

        public BootstrapBeginButtonGroup ButtonGroup()
        {
            return new BootstrapBeginButtonGroup(html);
        }

        public BootstrapBeginButtonGroup ButtonGroup(object htmlAttributes)
        {
            return new BootstrapBeginButtonGroup(html, htmlAttributes);
        }

        public BootstrapBeginButtonGroup ButtonGroup(ButtonGroupType type)
        {
            return new BootstrapBeginButtonGroup(html, type);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() { return null; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) { return base.Equals(obj); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() { return base.GetHashCode(); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Type GetType() { return base.GetType(); }
    }
}
