using System.Web.Mvc;
using TwitterBootstrapMVC.Infrastructure;

namespace TwitterBootstrapMVC.Controls
{
    public class ToolBarBuilder<TModel> : BuilderBase<TModel, ToolBar>
    {
        internal ToolBarBuilder(HtmlHelper<TModel> htmlHelper, ToolBar toolbar)
            : base(htmlHelper, toolbar)
        {
        }

        public ButtonGroupBuilder<TModel> BeginButtonGroup(ButtonGroup buttonGroup)
        {
            return new ButtonGroupBuilder<TModel>(base.htmlHelper, buttonGroup);
        }
    }
}
