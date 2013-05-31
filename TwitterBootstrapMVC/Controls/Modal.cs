using TwitterBootstrapMVC.Infrastructure;

namespace TwitterBootstrapMVC
{
    public class Modal : HtmlElement
    {
        public Modal()
            : base("div")
        {
            EnsureClass("modal hide");
        }

        public Modal Id(string id)
        {
            MergeHtmlAttribute("id", id);
            return this;
        }

        public Modal HtmlAttributes(object htmlAttributes)
        {
            SetHtmlAttributes(htmlAttributes);
            return this;
        }

        public Modal Fade()
        {
            EnsureClass("fade");
            return this;
        }
    }
}
