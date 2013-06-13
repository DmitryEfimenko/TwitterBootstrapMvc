using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TwitterBootstrapMVC.ControlInterfaces;
using TwitterBootstrapMVC.ControlModels;
using TwitterBootstrapMVC.Infrastructure.Enums;

namespace TwitterBootstrapMVC.Controls
{
    public class BootstrapControlGroupCustom<TModel> : IHtmlString
    {
        private HtmlHelper html;
        private BootstrapControlGroupCustomModel model = new BootstrapControlGroupCustomModel();

        public BootstrapControlGroupCustom(HtmlHelper html, string input)
        {
            this.model.input = input;
            this.html = html;
        }

        public BootstrapControlGroupCustom<TModel> CustomLabel(string label)
        {
            this.model.labelString = label;
            return this;
        }

        public BootstrapControlGroupCustom<TModel> CustomLabel(params IHtmlString[] label)
        {
            string controlsString = string.Empty;
            label.ToList().ForEach(x => this.model.labelString += x.ToHtmlString());
            return this;
        }

        public IBootstrapLabel LabelFor<TValue>(Expression<Func<TModel, TValue>> expression)
        {
            model.htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            model.metadata = ModelMetadata.FromStringExpression(model.htmlFieldName, html.ViewData);
            IBootstrapLabel l = new BootstrapControlGroupLabeled(html, model, BootstrapInputType.Custom);
            return l;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual string ToHtmlString()
        {
            TagBuilder span = new TagBuilder("span");
            span.AddCssClass("control-label");
            span.InnerHtml = model.labelString;

            bool fieldIsValid = true;
            if (model != null && model.htmlFieldName != null) fieldIsValid = html.ViewData.ModelState.IsValidField(model.htmlFieldName);
            return new BootstrapControlGroup(model.input, span.ToString(TagRenderMode.Normal), ControlGroupType.textboxLike, fieldIsValid).ToHtmlString();
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
