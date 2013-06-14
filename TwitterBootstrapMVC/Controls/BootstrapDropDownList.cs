using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using TwitterBootstrapMVC.ControlInterfaces;
using TwitterBootstrapMVC.ControlModels;
using TwitterBootstrapMVC.Infrastructure;
using TwitterBootstrapMVC.Infrastructure.Enums;
using TwitterBootstrapMVC.Renderers;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Controls
{
    public class BootstrapDropDownList : IBootstrapDropDownList
    {
        protected HtmlHelper html;
        protected BootstrapSelectElementModel _model = new BootstrapSelectElementModel();

        public BootstrapDropDownList(HtmlHelper html, string htmlFieldName, IEnumerable<SelectListItem> selectList, ModelMetadata metadata)
        {
            this.html = html;
            this._model.htmlFieldName = htmlFieldName;
            this._model.selectList = selectList;
            this._model.metadata = metadata;
            this._model.selectedValue = metadata.Model;
        }

        public IBootstrapDropDownList Id(string id)
        {
            this._model.id = id;
            return this;
        }

        public IBootstrapDropDownList OptionLabel(string optionLabel)
        {
            this._model.optionLabel = optionLabel;
            return this;
        }

        public IBootstrapDropDownList HtmlAttributes(IDictionary<string, object> htmlAttributes)
        {
            this._model.htmlAttributes = htmlAttributes;
            return this;
        }

        public IBootstrapDropDownList HtmlAttributes(object htmlAttributes)
        {
            this._model.htmlAttributes = htmlAttributes.ToDictionary();
            return this;
        }

        public IBootstrapDropDownList Prepend(string prependString)
        {
            this._model.prependString = prependString;
            return this;
        }

        public IBootstrapDropDownList Prepend(BootstrapButton button)
        {
            this._model.prependButtons.Add(button);
            return this;
        }

        public IBootstrapDropDownList Append(string appendString)
        {
            this._model.appendString = appendString;
            return this;
        }

        public IBootstrapDropDownList Append(BootstrapButton button)
        {
            this._model.appendButtons.Add(button);
            return this;
        }

        public IBootstrapDropDownList HelpText()
        {
            this._model.helpText = new BootstrapHelpText(BootstrapHelper.GetHelpTextFromMetadata(_model.metadata), HelpTextStyle.Inline);
            return this;
        }

        public IBootstrapDropDownList HelpText(string text)
        {
            this._model.helpText = new BootstrapHelpText(text, HelpTextStyle.Inline);
            return this;
        }

        public IBootstrapDropDownList HelpText(string text, HelpTextStyle style)
        {
            this._model.helpText = new BootstrapHelpText(text, style);
            return this;
        }

        public IBootstrapDropDownList Size(InputSize size)
        {
            this._model.size = size;
            return this;
        }

        public IBootstrapDropDownList Tooltip(TooltipConfiguration configuration)
        {
            this._model.tooltipConfiguration = configuration;
            return this;
        }

        public IBootstrapDropDownList Tooltip(string title)
        {
            this._model.tooltipConfiguration = new TooltipConfiguration(title);
            return this;
        }

        public IBootstrapDropDownList SelectedValue(object value)
        {
            this._model.selectedValue = value;
            return this;
        }

        public IBootstrapDropDownList ShowValidationMessage(bool displayValidationMessage)
        {
            this._model.displayValidationMessage = displayValidationMessage;
            if (displayValidationMessage) this._model.validationMessageStyle = HelpTextStyle.Inline;
            return this;
        }

        public IBootstrapDropDownList ShowValidationMessage(bool displayValidationMessage, HelpTextStyle validationMessageStyle)
        {
            this._model.displayValidationMessage = displayValidationMessage;
            this._model.validationMessageStyle = validationMessageStyle;
            return this;
        }

        public virtual IBootstrapLabel Label()
        {
            IBootstrapLabel l = new BootstrapInputLabeled(html, _model, BootstrapInputType.DropDownList);
            return l;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual string ToHtmlString()
        {
            return Renderer.RenderSelectElement(html, _model, BootstrapInputType.DropDownList);
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
