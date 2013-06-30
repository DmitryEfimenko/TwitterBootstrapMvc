using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;

namespace TwitterBootstrapMVC.ControlInterfaces
{
    public interface IBootstrapListBox : IHtmlString
    {
        IBootstrapListBox Id(string id);
        IBootstrapListBox HtmlAttributes(IDictionary<string, object> htmlAttributes);
        IBootstrapListBox HtmlAttributes(object htmlAttributes);
        IBootstrapListBox HelpText();
        IBootstrapListBox HelpText(string text);
        IBootstrapListBox HelpText(string text, HelpTextStyle style);
        IBootstrapListBox Size(InputSize size);
        IBootstrapListBox Tooltip(TooltipConfiguration configuration);
        IBootstrapListBox Tooltip(Tooltip tooltip);
        IBootstrapListBox Tooltip(string text);
        IBootstrapListBox ShowValidationMessage(bool displayValidationMessage);
        IBootstrapListBox ShowValidationMessage(bool displayValidationMessage, HelpTextStyle validationMessageStyle);
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
