using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TwitterBootstrapMVC.ControlInterfaces;
using TwitterBootstrapMVC.ControlModels;
using TwitterBootstrapMVC.Infrastructure.Enums;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Renderers
{
    internal static partial class Renderer
    {
        public static string RenderLabel(HtmlHelper html, BootstrapLabelModel model)
        {
            if (string.IsNullOrEmpty(model.htmlFieldName)) return null;

            string fullHtmlFieldName = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(model.htmlFieldName);

            if (string.IsNullOrEmpty(model.labelText))
                model.labelText = model.metadata.DisplayName
                    ?? (model.metadata.PropertyName != null ? model.metadata.PropertyName.SplitByUpperCase() : null)
                    ?? fullHtmlFieldName.Split('.').Last().SplitByUpperCase();

            TagBuilder label = new TagBuilder("label");
            label.Attributes.Add("for", fullHtmlFieldName.FormatForMvcInputId() + (model.index.HasValue ? "_" + model.index.Value.ToString() : string.Empty));
            label.MergeAttributes(model.htmlAttributes.FormatHtmlAttributes());

            TagBuilder requiredSpan = new TagBuilder("span");
            requiredSpan.AddCssClass("required");
            requiredSpan.SetInnerText("*");
            if ((model.showRequiredStar.HasValue && !model.showRequiredStar.Value) || (!model.showRequiredStar.HasValue && !model.metadata.IsRequired))
                requiredSpan.AddCssStyle("visibility", "hidden");

            if(model.innerInputType != BootstrapInputType._NotSet)
            {
                if(model.innerInputType == BootstrapInputType.CheckBox)
                {
                    label.AddOrMergeCssClass("checkbox");
                    BootstrapCheckBoxModel inputModel = (BootstrapCheckBoxModel)model.innerInputModel;
                    inputModel.displayValidationMessage = false;
                    model.innerInput = MvcHtmlString.Create(inputModel.isSingleInput
                        ? Renderer.RenderCheckBoxCustom(html, inputModel)
                        : Renderer.RenderCheckBox(html, inputModel));
                    if(inputModel.htmlAttributes.Keys.Select(x => x.ToLower()).Contains("id"))
                        label.Attributes["for"] = inputModel.htmlAttributes["id"].ToString();
                }
                if(model.innerInputType == BootstrapInputType.Radio)
                {
                    label.AddOrMergeCssClass("radio");
                    BootstrapRadioButtonModel inputModel = (BootstrapRadioButtonModel)model.innerInputModel;
                    model.innerInput = MvcHtmlString.Create(Renderer.RenderRadioButton(html, inputModel));
                    if (inputModel.htmlAttributes.Keys.Select(x => x.ToLower()).Contains("id"))
                        label.Attributes["for"] = inputModel.htmlAttributes["id"].ToString();
                }
            }

            string innerinput = "";
            if (model.innerInput != null) innerinput = model.innerInput.ToHtmlString();

            label.InnerHtml = innerinput + model.labelText + requiredSpan.ToString() + model.innerValidationMessage;

            return label.ToString(TagRenderMode.Normal);
        }
    }
}
