using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using TwitterBootstrapMVC.Controls;

namespace TwitterBootstrapMVC.ControlModels
{
    public class BootstrapFileModel
    {
        public BootstrapFileModel()
        {
            htmlAttributes = new Dictionary<string, object>();
        }

        public string id;
        public string htmlFieldName;
        public IDictionary<string, object> htmlAttributes;
        public BootstrapHelpText helpText;
        public bool displayValidationMessage;
        public HelpTextStyle validationMessageStyle;
        public ModelMetadata metadata;
        public TooltipConfiguration tooltipConfiguration;
    }
}
