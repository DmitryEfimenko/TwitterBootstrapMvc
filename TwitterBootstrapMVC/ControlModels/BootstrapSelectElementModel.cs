using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TwitterBootstrapMVC.Controls;

namespace TwitterBootstrapMVC.ControlModels
{
    public class BootstrapSelectElementModel
    {
        public BootstrapSelectElementModel()
        {
            htmlAttributes = new Dictionary<string, object>();
            size = InputSize._NotSet;
            appendButtons = new List<BootstrapButton>();
            prependButtons = new List<BootstrapButton>();
        }

        public string id;
        public string htmlFieldName;
        public object selectedValue;
        public IEnumerable<SelectListItem> selectList;
        public string optionLabel;
        public IDictionary<string, object> htmlAttributes;
        public string prependString;
        public string appendString;
        public InputSize size;
        public List<BootstrapButton> prependButtons;
        public List<BootstrapButton> appendButtons;
        public BootstrapHelpText helpText;
        public bool displayValidationMessage;
        public HelpTextStyle validationMessageStyle;
        public ModelMetadata metadata;
        public TooltipConfiguration tooltipConfiguration;
    }
}
