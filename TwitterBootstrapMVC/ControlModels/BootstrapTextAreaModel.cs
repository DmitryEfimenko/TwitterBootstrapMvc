using System.Collections.Generic;
using System.Web.Mvc;

namespace TwitterBootstrapMVC.ControlModels
{
    public class BootstrapTextAreaModel
    {
        public BootstrapTextAreaModel()
        {
            htmlAttributes = new Dictionary<string, object>();
        }

        public string id;
        public string htmlFieldName;
        public string value;
        public int rows;
        public int columns;
        public IDictionary<string, object> htmlAttributes;
        public bool displayValidationMessage;
        public HelpTextStyle validationMessageStyle;
        public ModelMetadata metadata;
        public TooltipConfiguration tooltipConfiguration;
        public Tooltip tooltip;
    }
}
