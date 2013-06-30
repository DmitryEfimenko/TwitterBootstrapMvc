using System.Collections.Generic;
using System.Web.Mvc;

namespace TwitterBootstrapMVC.ControlModels
{
    public class BootstrapRadioButtonModel
    {
        public BootstrapRadioButtonModel()
        {
            htmlAttributes = new Dictionary<string, object>();
        }

        // properties for regular mvc radio button
        public string id;
        public string htmlFieldName;
        public object value;
        public bool isChecked;
        public bool isDisabled;
        public IDictionary<string, object> htmlAttributes;
        public bool displayValidationMessage;
        public HelpTextStyle validationMessageStyle;
        public ModelMetadata metadata;
        public TooltipConfiguration tooltipConfiguration;
        public Tooltip tooltip;
    }
}
