using System.Collections.Generic;
using System.Web.Mvc;

namespace TwitterBootstrapMVC.ControlModels
{
    public class BootstrapCheckBoxModel
    {
        public BootstrapCheckBoxModel()
        {
            htmlAttributes = new Dictionary<string, object>();
        }

        // properties for regular mvc checkbox
        public string id;
        public string htmlFieldName;
        public bool isChecked;
        public bool isDisabled;
        public IDictionary<string, object> htmlAttributes;
        public bool displayValidationMessage;
        public HelpTextStyle validationMessageStyle;
        public ModelMetadata metadata;
        public TooltipConfiguration tooltipConfiguration;
        public Tooltip tooltip;

        //properties for a custom checkbox
        public object value;
        public bool isSingleInput;
    }
}
