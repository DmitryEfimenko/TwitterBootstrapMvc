using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TwitterBootstrapMVC.ControlInterfaces;
using TwitterBootstrapMVC.ControlModels;
using TwitterBootstrapMVC.TypeExtensions;
using TwitterBootstrapMVC.Renderers;

namespace TwitterBootstrapMVC.Controls
{
    public class BootstrapLabel : IBootstrapLabel
    {
        protected HtmlHelper html;
        protected BootstrapLabelModel _labelModel = new BootstrapLabelModel();

        public BootstrapLabel(HtmlHelper html, string htmlFieldName, ModelMetadata metadata)
        {
            this.html = html;
            this._labelModel.htmlFieldName = htmlFieldName;
            this._labelModel.metadata = metadata;
        }

        public IBootstrapLabel LabelText(string labelText)
        {
            this._labelModel.labelText = labelText;
            return this;
        }

        public IBootstrapLabel LabelHtml(params IHtmlString[] label)
        {
            label.ToList().ForEach(x => this._labelModel.labelText += x.ToHtmlString());
            return this;
        }

        public IBootstrapLabel ShowRequiredStar(bool showRequiredStar)
        {
            this._labelModel.showRequiredStar = showRequiredStar;
            return this;
        }

        public IBootstrapLabel HtmlAttributes(IDictionary<string, object> htmlAttributes)
        {
            this._labelModel.htmlAttributes = htmlAttributes;
            return this;
        }

        public IBootstrapLabel HtmlAttributes(object htmlAttributes)
        {
            this._labelModel.htmlAttributes = htmlAttributes.ToDictionary();
            return this;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual string ToHtmlString()
        {
            return Renderer.RenderLabel(html, _labelModel);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() { return ToHtmlString(); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) { return base.Equals(obj); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() { return base.GetHashCode(); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Type GetType() { return base.GetType(); }
    }
}
