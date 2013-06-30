using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Web;

namespace TwitterBootstrapMVC.ControlInterfaces
{
    public interface IBootstrapInputList<TModel, TSource, SValue, SText> : IHtmlString
    {
        IBootstrapInputList<TModel, TSource, SValue, SText> InputHtmlAttributes(Expression<Func<TSource, object>> htmlAttributesExpression);
        IBootstrapInputList<TModel, TSource, SValue, SText> LabelHtmlAttributes(Expression<Func<TSource, object>> htmlAttributesExpression);
        IBootstrapInputList<TModel, TSource, SValue, SText> SelectedValues(Expression<Func<TSource, bool>> selectedValueExpression);
        IBootstrapInputList<TModel, TSource, SValue, SText> DisabledValues(Expression<Func<TSource, bool>> disabledValueExpression);
        IBootstrapInputList<TModel, TSource, SValue, SText> DisplayInColumns(int numberOfColumns, int columnPixelWidth);
        IBootstrapInputList<TModel, TSource, SValue, SText> DisplayInColumns(int numberOfColumns, int columnPixelWidth, bool condition);
        IBootstrapInputList<TModel, TSource, SValue, SText> ShowValidationMessage(bool displayValidationMessage);
        IBootstrapInputList<TModel, TSource, SValue, SText> ShowValidationMessage(bool displayValidationMessage, HelpTextStyle validationMessageStyle);
        IBootstrapLabel Label();

        [EditorBrowsable(EditorBrowsableState.Never)]
        Type GetType();

        [EditorBrowsable(EditorBrowsableState.Never)]
        int GetHashCode();

        [EditorBrowsable(EditorBrowsableState.Never)]
        string ToString();

        [EditorBrowsable(EditorBrowsableState.Never)]
        new string ToHtmlString();

        [EditorBrowsable(EditorBrowsableState.Never)]
        bool Equals(object obj);
    }
}
