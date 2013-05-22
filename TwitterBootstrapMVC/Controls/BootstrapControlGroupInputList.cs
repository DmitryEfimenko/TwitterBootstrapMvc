using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TwitterBootstrapMVC.ControlInterfaces;
using TwitterBootstrapMVC.ControlModels;
using TwitterBootstrapMVC.Infrastructure.Enums;
using TwitterBootstrapMVC.Renderers;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Controls
{
    public class BootstrapControlGroupInputList<TModel, TSource, SValue, SText> : BootstrapInputList<TModel, TSource, SValue, SText>
    {
        public BootstrapControlGroupInputList(
            HtmlHelper html,
            string htmlFieldName,
            ModelMetadata metadata,
            Expression<Func<TModel, IEnumerable<TSource>>> sourceDataExpression,
            Expression<Func<TSource, SValue>> valueExpression,
            Expression<Func<TSource, SText>> textExpression,
            BootstrapInputType inputType)
            : base(html, htmlFieldName, metadata, sourceDataExpression, valueExpression, textExpression, inputType)
        {
            this._model.displayValidationMessage = true;
        }

        public override IBootstrapLabel Label()
        {
            IBootstrapLabel l = new BootstrapControlGroupInputListLabeled<TModel, TSource, SValue, SText>(html, _model, BootstrapInputType.CheckBoxList);
            return l;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToHtmlString()
        {
            return RendererList<TModel, TSource, SValue, SText>.RenderControlGroupInputList(html, _model);
        }
    }
}
