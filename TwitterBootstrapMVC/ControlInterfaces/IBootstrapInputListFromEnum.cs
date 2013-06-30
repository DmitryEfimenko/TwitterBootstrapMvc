using System;
using System.ComponentModel;
using System.Web;

namespace TwitterBootstrapMVC.ControlInterfaces
{
    public interface IBootstrapInputListFromEnum : IHtmlString
    {
        IBootstrapInputListFromEnum DisplayInColumns(int numberOfColumns, int columnPixelWidth);
        IBootstrapInputListFromEnum DisplayInColumns(int numberOfColumns, int columnPixelWidth, bool condition);
        IBootstrapInputListFromEnum DisplayInlineBlock(int marginRightPx = 0);
        IBootstrapInputListFromEnum ShowValidationMessage(bool displayValidationMessage);
        IBootstrapInputListFromEnum ShowValidationMessage(bool displayValidationMessage, HelpTextStyle validationMessageStyle);
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
