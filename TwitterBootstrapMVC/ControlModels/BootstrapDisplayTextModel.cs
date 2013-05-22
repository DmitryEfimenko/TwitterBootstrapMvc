using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace TwitterBootstrapMVC.ControlModels
{
    public class BootstrapDisplayTextModel
    {
        public BootstrapDisplayTextModel()
        {
            htmlAttributes = new Dictionary<string, object>();
        }

        public string htmlFieldName;
        public string text;
        public IDictionary<string, object> htmlAttributes;
        public ModelMetadata metadata;
    }
}
