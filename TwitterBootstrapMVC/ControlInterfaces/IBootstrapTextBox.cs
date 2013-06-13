using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TwitterBootstrapMVC.Controls;
using TwitterBootstrapMVC;

namespace TwitterBootstrapMVC.ControlInterfaces
{
    public interface IBootstrapTextBox<T> : IHtmlString
    {
        T Id(string id);
        T Value(object value);
        T HtmlAttributes(object htmlAttributes);
        T Format(string format);
        T Placeholder();
        T Placeholder(string placeholder);
        T Prepend(string prependString);
        T Prepend(BootstrapButton button);
        T PrependIcon(Icons icon);
        T PrependIcon(Icons icon, bool isWhite);
        T PrependIcon(string customCssClass);
        T Append(string appendString);
        T Append(BootstrapButton button);
        T AppendIcon(Icons icon);
        T AppendIcon(Icons icon, bool isWhite);
        T AppendIcon(string customCssClass);
        T HelpText();
        T HelpText(string text);
        T HelpText(string text, HelpTextStyle style);
        T Size(InputSize size);
        T Tooltip(TooltipConfiguration configuration);
        T Tooltip(string text);
        T ShowValidationMessage(bool displayValidationMessage);
        T ShowValidationMessage(bool displayValidationMessage, HelpTextStyle validationMessageStyle);
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
