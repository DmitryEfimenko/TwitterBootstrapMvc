using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using TwitterBootstrapMVC.Infrastructure.Enums;

namespace TwitterBootstrapMVC.ControlModels
{
    public class BootstrapInputListModel<TModel, TSource, SValue, SText>
    {
        public BootstrapInputListModel()
        {
            displayInColumnsCondition = true;
        }

        public string htmlFieldName;
        public ModelMetadata metadata;
        public Expression<Func<TModel, IEnumerable<TSource>>> sourceDataExpression;
        public Expression<Func<TSource, SValue>> valueExpression;
        public Expression<Func<TSource, SText>> textExpression;
        public Expression<Func<TSource, object>> inputHtmlAttributesExpression;
        public Expression<Func<TSource, object>> labelHtmlAttributesExpression;
        public Expression<Func<TSource, bool>> checkedValueExpression;
        public Expression<Func<TSource, bool>> disabledValueExpression;
        public BootstrapInputType inputType;
        public int? numberOfColumns;
        public int columnPixelWidth;
        public bool displayInColumnsCondition;
        public bool displayInlineBlock;
        public int marginRightPx;

        public bool displayValidationMessage;
        public HelpTextStyle validationMessageStyle;
    }
}
