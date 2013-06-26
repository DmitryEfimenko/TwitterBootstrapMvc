using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TwitterBootstrapMVC.ControlModels;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Renderers
{
	internal static partial class Renderer
	{
		public static string RenderInputListFromEnum(HtmlHelper html, BootstrapInputListFromEnumModel model)
		{
			Type t = model.metadata.ModelType;
			List<SelectListItem> listItems = new List<SelectListItem>();
			foreach (var e in Enum.GetValues(t).OfType<Enum>())
			{
				listItems.Add(new SelectListItem()
				{
					Text =  e.GetEnumDescription(),
					Value = Enum.Parse(t, e.ToString()).ToString(),
					Selected = e.Equals(model.metadata.Model)
				});
			}

			List<string> inputs = new List<string>();

			int index = 0;
			foreach (var item in listItems)
			{
				inputs.Add(Renderer.RenderInputListItem(
					html,
					model.inputType,
					model.htmlFieldName,
					model.metadata,
					index,
					item.Value,
					item.Text,
					null,
					null,
					item.Selected,
					false));
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
