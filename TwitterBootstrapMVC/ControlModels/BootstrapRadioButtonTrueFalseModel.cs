using System.Collections.Generic;
using System.Web.Mvc;
using TwitterBootstrapMVC.Controls;

namespace TwitterBootstrapMVC.ControlModels
{
    public class BootstrapRadioButtonTrueFalseModel
    {
        public BootstrapRadioButtonTrueFalseModel()
        {
            inputTrueValue = true;
            inputFalseValue = false;
            labelTrueText = "Yes";
            labelFalseText = "No";
            htmlAttributesInputTrue = new Dictionary<string, object>();
            htmlAttributesInputFalse = new Dictionary<string, object>();
            htmlAttributesLabelTrue = new Dictionary<string, object>();
            htmlAttributesLabelFalse = new Dictionary<string, object>();
        }

        public string htmlFieldName;
        public object inputTrueValue;
        public object inputFalseValue;
        public string labelTrueText;
        public string labelFalseText;
        public bool? selectedValue;
        public IDictionary<string, object> htmlAttributesInputTrue;
        public IDictionary<string, object> htmlAttributesInputFalse;
        public IDictionary<string, object> htmlAttributesLabelTrue;
        public IDictionary<string, object> htmlAttributesLabelFalse;
        public bool displayValidationMessage;
        public HelpTextStyle validationMessageStyle;
        public ModelMetadata metadata;
        public TooltipConfiguration tooltipConfiguration;
        public Tooltip tooltip;
        public BootstrapHelpText helpText;
    }
}
