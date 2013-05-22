using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using TwitterBootstrapMVC.TypeExtensions;
using TwitterBootstrapMVC.Infrastructure.Enums;
using System.Linq.Expressions;
using TwitterBootstrapMVC.ControlInterfaces;
using TwitterBootstrapMVC.Renderers;
using TwitterBootstrapMVC.Controls;

namespace TwitterBootstrapMVC.BootstrapMethods
{
    public class BootstrapControlGroup<TModel>
    {
        private HtmlHelper<TModel> html;

        public BootstrapControlGroup(HtmlHelper<TModel> html)
        {
            this.html = html;
        }

        public BootstrapControlGroupDisplayText DisplayText(string htmlFieldName)
        {
            return new BootstrapControlGroupDisplayText(html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData));
        }

        public BootstrapControlGroupDisplayText DisplayTextFor<TValue>(Expression<Func<TModel, TValue>> expression)
        {
            return new BootstrapControlGroupDisplayText(html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression(expression, html.ViewData));
        }

        public BootstrapControlGroupTextBox TextBox(string htmlFieldName)
        {
            return new BootstrapControlGroupTextBox(html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData));
        }

        public BootstrapControlGroupTextBox TextBoxFor<TValue>(Expression<Func<TModel, TValue>> expression)
        {
            return new BootstrapControlGroupTextBox(html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression(expression, html.ViewData));
        }

        public BootstrapControlGroupPassword Password(string htmlFieldName)
        {
            return new BootstrapControlGroupPassword(html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData));
        }

        public BootstrapControlGroupPassword PasswordFor<TValue>(Expression<Func<TModel, TValue>> expression)
        {
            return new BootstrapControlGroupPassword(html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression(expression, html.ViewData));
        }

        public BootstrapControlGroupFile File(string htmlFieldName)
        {
            return new BootstrapControlGroupFile(html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData));
        }

        public BootstrapControlGroupFile FileFor<TValue>(Expression<Func<TModel, TValue>> expression)
        {
            return new BootstrapControlGroupFile(html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression(expression, html.ViewData));
        }

        public BootstrapControlGroupCheckBox CheckBox(string htmlFieldName)
        {
            return new BootstrapControlGroupCheckBox(html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData));
        }

        public BootstrapControlGroupCheckBox CheckBoxFor<TValue>(Expression<Func<TModel, TValue>> expression)
        {
            return new BootstrapControlGroupCheckBox(html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression(expression, html.ViewData));
        }

        public BootstrapControlGroupRadioButton RadioButton(string htmlFieldName, object value)
        {
            return new BootstrapControlGroupRadioButton(html, htmlFieldName, value, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData));
        }

        public BootstrapControlGroupRadioButton RadioButtonFor<TValue>(Expression<Func<TModel, TValue>> expression, object value)
        {
            return new BootstrapControlGroupRadioButton(html, ExpressionHelper.GetExpressionText(expression), value, ModelMetadata.FromLambdaExpression(expression, html.ViewData));
        }

        public BootstrapControlGroupDropDownList DropDownList(string htmlFieldName, IEnumerable<SelectListItem> selectList)
        {
            return new BootstrapControlGroupDropDownList(html, htmlFieldName, selectList, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData));
        }

        public BootstrapControlGroupDropDownList DropDownListFor<TValue>(Expression<Func<TModel, TValue>> expression, IEnumerable<SelectListItem> selectList)
        {
            return new BootstrapControlGroupDropDownList(html, ExpressionHelper.GetExpressionText(expression), selectList, ModelMetadata.FromLambdaExpression(expression, html.ViewData));
        }

        public BootstrapControlGroupListBox ListBox(string htmlFieldName, IEnumerable<SelectListItem> selectList)
        {
            return new BootstrapControlGroupListBox(html, htmlFieldName, selectList, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData));
        }

        public BootstrapControlGroupListBox ListBoxFor<TValue>(Expression<Func<TModel, TValue>> expression, IEnumerable<SelectListItem> selectList)
        {
            return new BootstrapControlGroupListBox(html, ExpressionHelper.GetExpressionText(expression), selectList, ModelMetadata.FromLambdaExpression(expression, html.ViewData));
        }

        public BootstrapControlGroupTextArea TextArea(string htmlFieldName)
        {
            return new BootstrapControlGroupTextArea(html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData));
        }

        public BootstrapControlGroupTextArea TextAreaFor<TValue>(Expression<Func<TModel, TValue>> expression)
        {
            return new BootstrapControlGroupTextArea(html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression(expression, html.ViewData));
        }

        public BootstrapControlGroupInputList<TModel, TSource, SValue, SText> CheckBoxList<TSource, SValue, SText>(
            string htmlFieldName,
            Expression<Func<TModel, IEnumerable<TSource>>> sourceDataExpression,
            Expression<Func<TSource, SValue>> valueExpression,
            Expression<Func<TSource, SText>> textExpression)
        {
            return new BootstrapControlGroupInputList<TModel, TSource, SValue, SText>(
                html,
                htmlFieldName,
                ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData),
                sourceDataExpression,
                valueExpression,
                textExpression,
                BootstrapInputType.CheckBoxList);
        }

        public BootstrapControlGroupInputList<TModel, TSource, SValue, SText> CheckBoxListFor<TValue, TSource, SValue, SText>(
            Expression<Func<TModel, TValue>> expression,
            Expression<Func<TModel, IEnumerable<TSource>>> sourceDataExpression,
            Expression<Func<TSource, SValue>> valueExpression,
            Expression<Func<TSource, SText>> textExpression)
        {
            return new BootstrapControlGroupInputList<TModel, TSource, SValue, SText>(
                html,
                ExpressionHelper.GetExpressionText(expression),
                ModelMetadata.FromLambdaExpression(expression, html.ViewData),
                sourceDataExpression,
                valueExpression,
                textExpression,
                BootstrapInputType.CheckBoxList);
        }

        public BootstrapControlGroupInputList<TModel, TSource, SValue, SText> RadioButtonList<TSource, SValue, SText>(
            string htmlFieldName,
            Expression<Func<TModel, IEnumerable<TSource>>> sourceDataExpression,
            Expression<Func<TSource, SValue>> valueExpression,
            Expression<Func<TSource, SText>> textExpression)
        {
            return new BootstrapControlGroupInputList<TModel, TSource, SValue, SText>(
                html,
                htmlFieldName,
                ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData),
                sourceDataExpression,
                valueExpression,
                textExpression,
                BootstrapInputType.RadioList);
        }

        public BootstrapControlGroupInputList<TModel, TSource, SValue, SText> RadioButtonListFor<TValue, TSource, SValue, SText>(
            Expression<Func<TModel, TValue>> expression,
            Expression<Func<TModel, IEnumerable<TSource>>> sourceDataExpression,
            Expression<Func<TSource, SValue>> valueExpression,
            Expression<Func<TSource, SText>> textExpression)
        {
            return new BootstrapControlGroupInputList<TModel, TSource, SValue, SText>(
                html,
                ExpressionHelper.GetExpressionText(expression),
                ModelMetadata.FromLambdaExpression(expression, html.ViewData),
                sourceDataExpression,
                valueExpression,
                textExpression,
                BootstrapInputType.RadioList);
        }

        public BootstrapControlGroupInputListFromEnum RadioButtonsFromEnum(string htmlFieldName)
        {
            return new BootstrapControlGroupInputListFromEnum(
                html,
                htmlFieldName,
                ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData),
                BootstrapInputType.RadioList);
        }

        public BootstrapControlGroupInputListFromEnum RadioButtonsFromEnumFor<TValue>(Expression<Func<TModel, TValue>> expression)
        {

            return new BootstrapControlGroupInputListFromEnum(
                html,
                ExpressionHelper.GetExpressionText(expression),
                ModelMetadata.FromLambdaExpression(expression, html.ViewData),
                BootstrapInputType.RadioList);
        }

        public BootstrapControlGroupInputListFromEnum CheckBoxesFromEnum(string htmlFieldName)
        {
            return new BootstrapControlGroupInputListFromEnum(
                html,
                htmlFieldName,
                ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData),
                BootstrapInputType.CheckBoxList);
        }

        public BootstrapControlGroupInputListFromEnum CheckBoxesFromEnumFor<TValue>(Expression<Func<TModel, TValue>> expression)
        {
            return new BootstrapControlGroupInputListFromEnum(
                html,
                ExpressionHelper.GetExpressionText(expression),
                ModelMetadata.FromLambdaExpression(expression, html.ViewData),
                BootstrapInputType.CheckBoxList);
        }

        public BootstrapControlGroupRadioButtonTrueFalse RadioButtonTrueFalse(string htmlFieldName)
        {
            return new BootstrapControlGroupRadioButtonTrueFalse(
                html,
                htmlFieldName,
                ModelMetadata.FromStringExpression(htmlFieldName, html.ViewData)
                );
        }

        public BootstrapControlGroupRadioButtonTrueFalse RadioButtonTrueFalseFor<TValue>(
            Expression<Func<TModel, TValue>> expression)
        {
            return new BootstrapControlGroupRadioButtonTrueFalse(
                html,
                ExpressionHelper.GetExpressionText(expression),
                ModelMetadata.FromLambdaExpression(expression, html.ViewData)
                );
        }

        public BootstrapControlGroupCustom<TModel> CustomControls(string controls)
        {
            return new BootstrapControlGroupCustom<TModel>(html, controls);
        }

        public BootstrapControlGroupCustom<TModel> CustomControls(params IHtmlString[] controls)
        {
            string controlsString = string.Empty;
            controls.ToList().ForEach(x => controlsString += x.ToHtmlString());
            return new BootstrapControlGroupCustom<TModel>(html, controlsString);
        }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() { return base.ToString(); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) { return base.Equals(obj); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() { return base.GetHashCode(); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Type GetType() { return base.GetType(); }
    }
}
