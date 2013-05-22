using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;

namespace TwitterBootstrapMVC.ControlInterfaces
{
    public interface IBootstrapButton<T> : IHtmlString
    {
        T Id(string id);
        T Text(string text);
        T Name(string name);
        T Value(string value);
        T HtmlAttributes(object htmlAttributes);
        T Size(ButtonSize size);
        T Style(ButtonStyle style);
        T ButtonBlock();
        T IconPrepend(Icons icon);
        T IconPrepend(Icons icon, bool isWhite);
        T IconPrepend(string customCssClass);
        T IconAppend(Icons icon);
        T IconAppend(Icons icon, bool isWhite);
        T IconAppend(string customCssClass);
        T Disabled();

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
