using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwitterBootstrapMVC.Controls;

namespace TwitterBootstrapMVC.BootstrapMethods
{
    public partial class Bootstrap<TModel>
    {
        public ModalBuilder<TModel> Begin(Modal modal)
        {
            return new ModalBuilder<TModel>(Html, modal);
        }

        public AccordionBuilder<TModel> Begin(Accordion modal)
        {
            return new AccordionBuilder<TModel>(Html, modal);
        }

        public CarouselBuilder<TModel> Begin(Carousel modal)
        {
            return new CarouselBuilder<TModel>(Html, modal);
        }

        public NavBuilder<TModel> Begin(Nav nav)
        {
            return new NavBuilder<TModel>(Html, nav);
        }

        public TabsBuilder<TModel> Begin(Tabs nav)
        {
            return new TabsBuilder<TModel>(Html, nav);
        }

        public FormBuilder<TModel> Begin(Form form)
        {
            return new FormBuilder<TModel>(Html, form);
        }

        public ButtonGroupBuilder<TModel> Begin(ButtonGroup buttonGroup)
        {
            return new ButtonGroupBuilder<TModel>(Html, buttonGroup);
        }

        public DropDownBuilder<TModel> Begin(DropDown dropDown)
        {
            return new DropDownBuilder<TModel>(Html, dropDown, "div", new { @class = "dropdown" });
        }

        public ToolBarBuilder<TModel> Begin(ToolBar toolBar)
        {
            return new ToolBarBuilder<TModel>(Html, toolBar);
        }

        public FormActionsBuilder<TModel> Begin(FormActions formActions)
        {
            return new FormActionsBuilder<TModel>(Html, formActions);
        }

        public AlertBuilder<TModel> Begin(Alert alert)
        {
            return new AlertBuilder<TModel>(Html, alert);
        }
    }
}