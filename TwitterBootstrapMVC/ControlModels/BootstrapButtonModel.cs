using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwitterBootstrapMVC.ControlModels
{
    public class BootstrapButtonModel
    {
        public BootstrapButtonModel()
        {
            htmlAttributes = new Dictionary<string, object>();
        }

        public string type;
        public string text;
        public string id;
        public string value;
        public string name;
        public IDictionary<string, object> htmlAttributes;
        public bool disabled;
        public bool buttonBlock;
        public ButtonSize size;
        public ButtonStyle style;
        public Icons iconPrepend;
        public Icons iconAppend;
        public bool iconPrependIsWhite;
        public bool iconAppendIsWhite;
        public string iconPrependCustomClass;
        public string iconAppendCustomClass;
        public bool isDropDownToggle;
    }
}
