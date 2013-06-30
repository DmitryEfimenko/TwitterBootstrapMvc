using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;

namespace TwitterBootstrapMVC.ControlInterfaces
{
    public interface IBootstrapFile : IHtmlString
    {
        IBootstrapFile Id(string id);
        IBootstrapFile HtmlAttributes(IDictionary<string, object> htmlAttributes);
        IBootstrapFile HtmlAttributes(object htmlAttributes);
        IBootstrapFile HelpText();
        IBootstrapFile HelpText(string text);
        IBootstrapFile HelpText(string text, HelpTextStyle style);
        IBootstrapFile Tooltip(TooltipConfiguration configuration);
        IBootstrapFile Tooltip(Tooltip tooltip);
        IBootstrapFile Tooltip(string text);
        IBootstrapFile ShowValidationMessage(bool displayValidationMessage);
        IBootstrapFile ShowValidationMessage(bool displayValidationMessage, HelpTextStyle validationMessageStyle);
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
