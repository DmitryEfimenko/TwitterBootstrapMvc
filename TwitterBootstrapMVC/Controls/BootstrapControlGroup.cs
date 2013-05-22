using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace TwitterBootstrapMVC.Controls
{
    public class BootstrapControlGroup : IHtmlString
    {
        private string _input;
        private string _label;
        private ControlGroupType _type;
        private bool _fieldIsValid;

        public BootstrapControlGroup(string input, string label, ControlGroupType type, bool fieldIsValid = true)
        {
            this._input = input;
            this._label = label;
            this._type = type;
            this._fieldIsValid = fieldIsValid;
        }

        public string ToHtmlString()
        {
            TagBuilder controlGroup = new TagBuilder("div");
            controlGroup.AddCssClass("control-group");
            if (!_fieldIsValid) controlGroup.AddCssClass("error");

            TagBuilder controls = new TagBuilder("div");
            controls.AddCssClass("controls");

            switch (_type)
            {
                case ControlGroupType.textboxLike:
                    controls.InnerHtml = _input;
                    controlGroup.InnerHtml = _label + controls.ToString();
                    break;
                case ControlGroupType.checkboxLike:
                    controls.InnerHtml = _label;
                    controlGroup.InnerHtml = controls.ToString();
                    break;
                default:
                    break;
            }

            return controlGroup.ToString();
        }
    }

    public enum ControlGroupType
    {
        textboxLike,
        checkboxLike
    }
}
