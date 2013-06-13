using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TwitterBootstrapMVC.Controls;

namespace TwitterBootstrapMVC.ControlModels
{
    public class BootstrapTextBoxModel
    {
        public BootstrapTextBoxModel()
        {
            htmlAttributes = new Dictionary<string, object>();
            size = InputSize._NotSet;
            appendButtons = new List<BootstrapButton>();
            prependButtons = new List<BootstrapButton>();
        }

        public string htmlFieldName;
        public string id;
        public object value;
        public string format;
        public IDictionary<string, object> htmlAttributes;
        public string placeholder;
        public string prependString;
        public string appendString;
        public InputSize size;
        public List<BootstrapButton> prependButtons;
        public List<BootstrapButton> appendButtons;
        public Icons iconPrepend;
        public Icons iconAppend;
        public bool iconPrependIsWhite;
        public bool iconAppendIsWhite;
        public string iconPrependCustomClass;
        public string iconAppendCustomClass;
        public BootstrapHelpText helpText;
        public bool displayValidationMessage;
        public HelpTextStyle validationMessageStyle;
        public ModelMetadata metadata;
        public TooltipConfiguration tooltipConfiguration;
    }
}
