using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;
using TwitterBootstrapMVC.ControlInterfaces;
using TwitterBootstrapMVC.Infrastructure.Enums;
using TwitterBootstrapMVC.Renderers;

namespace TwitterBootstrapMVC.Controls
{
    public class BootstrapControlGroupDropDownList : BootstrapDropDownList
    {
        public BootstrapControlGroupDropDownList(HtmlHelper html, string htmlFieldName, IEnumerable<SelectListItem> selectList, ModelMetadata metadata)
            : base(html, htmlFieldName, selectList, metadata)
        {
            this._model.displayValidationMessage = true;
        }

        public override IBootstrapLabel Label()
        {
            IBootstrapLabel l = new BootstrapControlGroupLabeled(html, _model, BootstrapInputType.DropDownList);
            return l;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToHtmlString()
        {
            return Renderer.RenderControlGroupSelectElement(html, _model, null, BootstrapInputType.DropDownList);
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
