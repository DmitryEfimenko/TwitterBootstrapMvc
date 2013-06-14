using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TwitterBootstrapMVC.ControlInterfaces
{
    public interface IBootstrapTextArea : IHtmlString
    {
        IBootstrapTextArea Id(string id);
        IBootstrapTextArea Value(string value);
        IBootstrapTextArea Rows(int rows);
        IBootstrapTextArea Columns(int columns);
        IBootstrapTextArea HtmlAttributes(IDictionary<string, object> htmlAttributes);
        IBootstrapTextArea HtmlAttributes(object htmlAttributes);
        IBootstrapTextArea Tooltip(TooltipConfiguration configuration);
        IBootstrapTextArea Tooltip(string text);
        IBootstrapTextArea ShowValidationMessage(bool displayValidationMessage);
        IBootstrapTextArea ShowValidationMessage(bool displayValidationMessage, HelpTextStyle validationMessageStyle);
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
