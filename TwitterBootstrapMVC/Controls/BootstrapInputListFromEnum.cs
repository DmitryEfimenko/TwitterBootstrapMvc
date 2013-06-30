using System;
using System.ComponentModel;
using System.Web.Mvc;
using TwitterBootstrapMVC.ControlInterfaces;
using TwitterBootstrapMVC.ControlModels;
using TwitterBootstrapMVC.Infrastructure.Enums;
using TwitterBootstrapMVC.Renderers;

namespace TwitterBootstrapMVC.Controls
{
    public class BootstrapInputListFromEnum : IBootstrapInputListFromEnum
    {
        protected HtmlHelper html;
        protected BootstrapInputListFromEnumModel _model = new BootstrapInputListFromEnumModel();

        public BootstrapInputListFromEnum(HtmlHelper html, string htmlFieldName, ModelMetadata metadata, BootstrapInputType inputType)
        {
            this.html = html;
            this._model.htmlFieldName = htmlFieldName;
            this._model.metadata = metadata;
            this._model.inputType = inputType;
        }

        public IBootstrapInputListFromEnum DisplayInColumns(int numberOfColumns, int columnPixelWidth)
        {
            this._model.numberOfColumns = numberOfColumns;
            this._model.columnPixelWidth = columnPixelWidth;
            return this;
        }

        public IBootstrapInputListFromEnum DisplayInColumns(int numberOfColumns, int columnPixelWidth, bool condition)
        {
            this._model.numberOfColumns = numberOfColumns;
            this._model.columnPixelWidth = columnPixelWidth;
            this._model.displayInColumnsCondition = condition;
            return this;
        }

        public IBootstrapInputListFromEnum DisplayInlineBlock(int marginRightPx = 0)
        {
            this._model.displayInlineBlock = true;
            this._model.marginRightPx = marginRightPx;
            return this;
        }

        public IBootstrapInputListFromEnum ShowValidationMessage(bool displayValidationMessage)
        {
            _model.displayValidationMessage = displayValidationMessage;
            if (displayValidationMessage) _model.validationMessageStyle = HelpTextStyle.Inline;
            return this;
        }

        public IBootstrapInputListFromEnum ShowValidationMessage(bool displayValidationMessage, HelpTextStyle validationMessageStyle)
        {
            _model.displayValidationMessage = displayValidationMessage;
            _model.validationMessageStyle = validationMessageStyle;
            return this;
        }

        public virtual IBootstrapLabel Label()
        {
            IBootstrapLabel l = new BootstrapInputListFromEnumLabeled(html, _model);
            return l;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual string ToHtmlString()
        {
            return Renderer.RenderInputListFromEnum(html, _model);
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
