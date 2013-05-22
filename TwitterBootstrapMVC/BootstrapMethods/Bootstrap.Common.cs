using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using TwitterBootstrapMVC.Controls;
using TwitterBootstrapMVC.Infrastructure.Enums;

namespace TwitterBootstrapMVC.BootstrapMethods
{
    public partial class Bootstrap<TModel>
    {
        public BootstrapLabel Label(string htmlFieldName)
        {
            return new BootstrapLabel(Html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, Html.ViewData));
        }

        public BootstrapLabel LabelFor<TValue>(Expression<Func<TModel, TValue>> expression)
        {
            return new BootstrapLabel(Html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression(expression, Html.ViewData));
        }

        public BootstrapTextBox TextBox(string htmlFieldName)
        {
            return new BootstrapTextBox(Html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, Html.ViewData));
        }

        public BootstrapTextBox TextBoxFor<TValue>(Expression<Func<TModel, TValue>> expression)
        {
            return new BootstrapTextBox(Html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression(expression, Html.ViewData));
        }

        public BootstrapPassword Password(string htmlFieldName)
        {
            return new BootstrapPassword(Html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, Html.ViewData));
        }

        public BootstrapPassword PasswordFor<TValue>(Expression<Func<TModel, TValue>> expression)
        {
            return new BootstrapPassword(Html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression(expression, Html.ViewData));
        }

        public BootstrapCheckBox CheckBox(string htmlFieldName)
        {
            return new BootstrapCheckBox(Html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, Html.ViewData));
        }

        public BootstrapCheckBox CheckBoxFor<TValue>(Expression<Func<TModel, TValue>> expression)
        {
            return new BootstrapCheckBox(Html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression(expression, Html.ViewData));
        }

        public BootstrapCheckBox CheckBoxSingleInput(string htmlFieldName, object value)
        {
            return new BootstrapCheckBox(Html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, Html.ViewData), value, true);
        }

        public BootstrapRadioButton RadioButton(string htmlFieldName, object value)
        {
            return new BootstrapRadioButton(Html, htmlFieldName, value, ModelMetadata.FromStringExpression(htmlFieldName, Html.ViewData));
        }

        public BootstrapRadioButton RadioButtonFor<TValue>(Expression<Func<TModel, TValue>> expression, object value)
        {
            return new BootstrapRadioButton(Html, ExpressionHelper.GetExpressionText(expression), value, ModelMetadata.FromLambdaExpression(expression, Html.ViewData));
        }

        public BootstrapDropDownList DropDownList(string htmlFieldName, IEnumerable<SelectListItem> selectList)
        {
            return new BootstrapDropDownList(Html, htmlFieldName, selectList, ModelMetadata.FromStringExpression(htmlFieldName, Html.ViewData));
        }

        public BootstrapDropDownList DropDownListFor<TValue>(Expression<Func<TModel, TValue>> expression, IEnumerable<SelectListItem> selectList)
        {
            return new BootstrapDropDownList(Html, ExpressionHelper.GetExpressionText(expression), selectList, ModelMetadata.FromLambdaExpression(expression, Html.ViewData));
        }

        public BootstrapTextArea TextArea(string htmlFieldName)
        {
            return new BootstrapTextArea(Html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, Html.ViewData));
        }

        public BootstrapTextArea TextAreaFor<TValue>(Expression<Func<TModel, TValue>> expression)
        {
            return new BootstrapTextArea(Html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression(expression, Html.ViewData));
        }

        public BootstrapFile File(string htmlFieldName)
        {
            return new BootstrapFile(Html, htmlFieldName, ModelMetadata.FromStringExpression(htmlFieldName, Html.ViewData));
        }

        public BootstrapFile FileFor<TValue>(Expression<Func<TModel, TValue>> expression)
        {
            return new BootstrapFile(Html, ExpressionHelper.GetExpressionText(expression), ModelMetadata.FromLambdaExpression(expression, Html.ViewData));
        }

        public BootstrapButton SubmitButton()
        {
            return new BootstrapButton("submit");
        }

        public BootstrapButton Button()
        {
            return new BootstrapButton("button");
        }

        public BootstrapInputList<TModel, TSource, SValue, SText> CheckBoxList<TSource, SValue, SText>(
            string htmlFieldName,
            Expression<Func<TModel, IEnumerable<TSource>>> sourceDataExpression,
            Expression<Func<TSource, SValue>> valueExpression,
            Expression<Func<TSource, SText>> textExpression)
        {
            return new BootstrapInputList<TModel, TSource, SValue, SText>(
                Html,
                htmlFieldName,
                ModelMetadata.FromStringExpression(htmlFieldName, Html.ViewData),
                sourceDataExpression,
                valueExpression,
                textExpression,
                BootstrapInputType.CheckBoxList);
        }

        public BootstrapInputList<TModel, TSource, SValue, SText> CheckBoxListFor<TValue, TSource, SValue, SText>(
            Expression<Func<TModel, TValue>> expression,
            Expression<Func<TModel, IEnumerable<TSource>>> sourceDataExpression,
            Expression<Func<TSource, SValue>> valueExpression,
            Expression<Func<TSource, SText>> textExpression)
        {
            return new BootstrapInputList<TModel, TSource, SValue, SText>(
                Html,
                ExpressionHelper.GetExpressionText(expression),
                ModelMetadata.FromLambdaExpression(expression, Html.ViewData),
                sourceDataExpression,
                valueExpression,
                textExpression,
                BootstrapInputType.CheckBoxList);
        }

        public BootstrapInputList<TModel, TSource, SValue, SText> RadioButtonList<TSource, SValue, SText>(
            string htmlFieldName,
            Expression<Func<TModel, IEnumerable<TSource>>> sourceDataExpression,
            Expression<Func<TSource, SValue>> valueExpression,
            Expression<Func<TSource, SText>> textExpression)
        {
            return new BootstrapInputList<TModel, TSource, SValue, SText>(
                Html,
                htmlFieldName,
                ModelMetadata.FromStringExpression(htmlFieldName, Html.ViewData),
                sourceDataExpression,
                valueExpression,
                textExpression,
                BootstrapInputType.RadioList);
        }

        public BootstrapInputList<TModel, TSource, SValue, SText> RadioButtonListFor<TValue, TSource, SValue, SText>(
            Expression<Func<TModel, TValue>> expression,
            Expression<Func<TModel, IEnumerable<TSource>>> sourceDataExpression,
            Expression<Func<TSource, SValue>> valueExpression,
            Expression<Func<TSource, SText>> textExpression)
        {
            return new BootstrapInputList<TModel, TSource, SValue, SText>(
                Html,
                ExpressionHelper.GetExpressionText(expression),
                ModelMetadata.FromLambdaExpression(expression, Html.ViewData),
                sourceDataExpression,
                valueExpression,
                textExpression,
                BootstrapInputType.RadioList);
        }

        public BootstrapInputListFromEnum RadioButtonsFromEnum(string htmlFieldName)
        {
            return new BootstrapInputListFromEnum(
                Html,
                htmlFieldName,
                ModelMetadata.FromStringExpression(htmlFieldName, Html.ViewData),
                BootstrapInputType.RadioList);
        }

        public BootstrapInputListFromEnum RadioButtonsFromEnumFor<TValue>(Expression<Func<TModel, TValue>> expression)
        {

            return new BootstrapInputListFromEnum(
                Html,
                ExpressionHelper.GetExpressionText(expression),
                ModelMetadata.FromLambdaExpression(expression, Html.ViewData),
                BootstrapInputType.RadioList);
        }

        public BootstrapInputListFromEnum CheckBoxesFromEnum(string htmlFieldName)
        {
            return new BootstrapInputListFromEnum(
                Html,
                htmlFieldName,
                ModelMetadata.FromStringExpression(htmlFieldName, Html.ViewData),
                BootstrapInputType.CheckBoxList);
        }

        public BootstrapInputListFromEnum CheckBoxesFromEnumFor<TValue>(Expression<Func<TModel, TValue>> expression)
        {
            return new BootstrapInputListFromEnum(
                Html,
                ExpressionHelper.GetExpressionText(expression),
                ModelMetadata.FromLambdaExpression(expression, Html.ViewData),
                BootstrapInputType.CheckBoxList);
        }

        public BootstrapRadioButtonTrueFalse RadioButtonTrueFalse(string htmlFieldName)
        {
            return new BootstrapRadioButtonTrueFalse(
                Html,
                htmlFieldName,
                ModelMetadata.FromStringExpression(htmlFieldName, Html.ViewData)
                );
        }

        public BootstrapRadioButtonTrueFalse RadioButtonTrueFalseFor<TValue>(
            Expression<Func<TModel, TValue>> expression)
        {
            return new BootstrapRadioButtonTrueFalse(
                Html,
                ExpressionHelper.GetExpressionText(expression),
                ModelMetadata.FromLambdaExpression(expression, Html.ViewData)
                );
        }
    }
}
