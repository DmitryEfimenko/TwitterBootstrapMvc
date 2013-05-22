using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        //properties for a custom checkbox
        public object value;
        public bool isSingleInput;
    }
}
