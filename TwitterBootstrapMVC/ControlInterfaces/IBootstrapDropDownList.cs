using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using TwitterBootstrapMVC.Controls;

namespace TwitterBootstrapMVC.ControlInterfaces
{
    public interface IBootstrapDropDownList : IHtmlString
    {
        IBootstrapDropDownList Id(string id);
        IBootstrapDropDownList OptionLabel(string optionLabel);
        IBootstrapDropDownList HtmlAttributes(IDictionary<string, object> htmlAttributes);
        IBootstrapDropDownList HtmlAttributes(object htmlAttributes);
        IBootstrapDropDownList SelectedValue(object value);
        IBootstrapDropDownList Prepend(string prependString);
        IBootstrapDropDownList Prepend(BootstrapButton button);
        IBootstrapDropDownList Append(string appendString);
        IBootstrapDropDownList Append(BootstrapButton button);
        IBootstrapDropDownList HelpText();
        IBootstrapDropDownList HelpText(string text);
        IBootstrapDropDownList HelpText(string text, HelpTextStyle style);
        IBootstrapDropDownList Size(InputSize size);
        IBootstrapDropDownList Tooltip(TooltipConfiguration configuration);
        IBootstrapDropDownList Tooltip(Tooltip tooltip);
        IBootstrapDropDownList Tooltip(string text);
        IBootstrapDropDownList ShowValidationMessage(bool displayValidationMessage);
        IBootstrapDropDownList ShowValidationMessage(bool displayValidationMessage, HelpTextStyle validationMessageStyle);
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
