using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TwitterBootstrapMVC.ControlModels;

namespace TwitterBootstrapMVC.Renderers
{
	internal static partial class RendererList<TModel, TSource, SValue, SText>
	{
		public static string RenderInputList(HtmlHelper html, BootstrapInputListModel<TModel, TSource, SValue, SText> model)
		{
			if (model.sourceDataExpression == null) return null;
			if (html.ViewData.Model == null) return null;
			if (string.IsNullOrEmpty(model.htmlFieldName)) throw new ArgumentException("You must provide html field expression or name");

			List<TSource> _dataSource = new List<TSource>();
			try
			{
				_dataSource = model.sourceDataExpression.Compile()((TModel)html.ViewData.Model).ToList();
			}
			catch (ArgumentNullException)
			{
				throw new ArgumentException("The data source cannot be null");
			}
			
			Func<TSource, SValue> _inputValueFunc = model.valueExpression.Compile();
			Func<TSource, SText> _inputTextFunc = model.textExpression.Compile();
			Func<TSource, object> _inputHtmlAttributes = (model.inputHtmlAttributesExpression != null) ? model.inputHtmlAttributesExpression.Compile() : null;
			Func<TSource, object> _labelHtmlAttributes = (model.labelHtmlAttributesExpression != null) ? model.labelHtmlAttributesExpression.Compile() : null;
			Func<TSource, bool> _checkedValue = (model.checkedValueExpression != null) ? model.checkedValueExpression.Compile() : null;
			Func<TSource, bool> _disabledValue = (model.disabledValueExpression != null) ? model.disabledValueExpression.Compile() : null;

			List<string> inputs = new List<string>();

			int index = 0;
			foreach (var item in _dataSource)
			{
				string inputValue = _inputValueFunc(item).ToString();
				string inputText = _inputTextFunc(item).ToString();
				object inputHtmlAttributes = (_inputHtmlAttributes != null) ? _inputHtmlAttributes(item) : null;
				object labelHtmlAttributes = (_labelHtmlAttributes != null) ? _labelHtmlAttributes(item) : null;
				bool inputIsChecked = (_checkedValue != null) ? _checkedValue(item) : false;
				bool inputIsDisabled = (_disabledValue != null) ? _disabledValue(item) : false;

				inputs.Add(Renderer.RenderInputListItem(
					html,
					model.inputType,
					model.htmlFieldName,
					model.metadata,
					index,
					inputValue,
					inputText,
					inputHtmlAttributes,
					labelHtmlAttributes,
					inputIsChecked,
					inputIsDisabled));
				index++;
			}
			
			return Renderer.RenderInputListContainer(
				html,
				model.htmlFieldName,
				inputs,
				model.numberOfColumns,
				model.displayInColumnsCondition,
				model.columnPixelWidth,
				model.displayInlineBlock,
				model.marginRightPx,
				model.displayValidationMessage,
				model.validationMessageStyle);
		}
	}
}
