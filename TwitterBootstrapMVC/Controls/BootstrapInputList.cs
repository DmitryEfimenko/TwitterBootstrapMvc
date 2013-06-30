using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Web.Mvc;
using TwitterBootstrapMVC.ControlInterfaces;
using TwitterBootstrapMVC.ControlModels;
using TwitterBootstrapMVC.Infrastructure.Enums;
using TwitterBootstrapMVC.Renderers;

namespace TwitterBootstrapMVC.Controls
{
    public class BootstrapInputList<TModel, TSource, SValue, SText> : IBootstrapInputList<TModel, TSource, SValue, SText>
    {
        protected HtmlHelper html;
        protected BootstrapInputListModel<TModel, TSource, SValue, SText> _model = new BootstrapInputListModel<TModel, TSource, SValue, SText>();

        public BootstrapInputList(
            HtmlHelper html,
            string htmlFieldName,
            ModelMetadata metadata,
            Expression<Func<TModel, IEnumerable<TSource>>> sourceDataExpression,
            Expression<Func<TSource, SValue>> valueExpression,
            Expression<Func<TSource, SText>> textExpression,
            BootstrapInputType inputType)
        {
            this.html = html;
            this._model.htmlFieldName = htmlFieldName;
            this._model.metadata = metadata;
            this._model.sourceDataExpression = sourceDataExpression;
            this._model.valueExpression = valueExpression;
            this._model.textExpression = textExpression;
            this._model.inputType = inputType;
        }

        public IBootstrapInputList<TModel, TSource, SValue, SText> InputHtmlAttributes(Expression<Func<TSource, object>> htmlAttributesExpression)
        {
            this._model.inputHtmlAttributesExpression = htmlAttributesExpression;
            return this;
        }

        public IBootstrapInputList<TModel, TSource, SValue, SText> LabelHtmlAttributes(Expression<Func<TSource, object>> htmlAttributesExpression)
        {
            this._model.labelHtmlAttributesExpression = htmlAttributesExpression;
            return this;
        }

        public IBootstrapInputList<TModel, TSource, SValue, SText> SelectedValues(Expression<Func<TSource, bool>> selectedValueExpression)
        {
            this._model.checkedValueExpression = selectedValueExpression;
            return this;
        }

        public IBootstrapInputList<TModel, TSource, SValue, SText> DisabledValues(Expression<Func<TSource, bool>> disabledValueExpression)
        {
            this._model.disabledValueExpression = disabledValueExpression;
            return this;
        }

        public IBootstrapInputList<TModel, TSource, SValue, SText> DisplayInColumns(int numberOfColumns, int columnPixelWidth)
        {
            this._model.numberOfColumns = numberOfColumns;
            this._model.columnPixelWidth = columnPixelWidth;
            return this;
        }

        public IBootstrapInputList<TModel, TSource, SValue, SText> DisplayInColumns(int numberOfColumns, int columnPixelWidth, bool condition)
        {
            this._model.numberOfColumns = numberOfColumns;
            this._model.columnPixelWidth = columnPixelWidth;
            this._model.displayInColumnsCondition = condition;
            return this;
        }

        public IBootstrapInputList<TModel, TSource, SValue, SText> DisplayInlineBlock(int marginRightPx = 0)
        {
            this._model.displayInlineBlock = true;
            this._model.marginRightPx = marginRightPx;
            return this;
        }

        public IBootstrapInputList<TModel, TSource, SValue, SText> ShowValidationMessage(bool displayValidationMessage)
        {
            _model.displayValidationMessage = displayValidationMessage;
            if (displayValidationMessage) _model.validationMessageStyle = HelpTextStyle.Inline;
            return this;
        }

        public IBootstrapInputList<TModel, TSource, SValue, SText> ShowValidationMessage(bool displayValidationMessage, HelpTextStyle validationMessageStyle)
        {
            _model.displayValidationMessage = displayValidationMessage;
            _model.validationMessageStyle = validationMessageStyle;
            return this;
        }
        
        public virtual IBootstrapLabel Label()
        {
            IBootstrapLabel l = new BootstrapInputListLabeled<TModel, TSource, SValue, SText>(html, _model, BootstrapInputType.CheckBoxList);
            return l;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual string ToHtmlString()
        {
            return RendererList<TModel, TSource, SValue, SText>.RenderInputList(html, _model);
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
