using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using TwitterBootstrapMVC.Infrastructure;

namespace TwitterBootstrapMVC
{
    public class Carousel : HtmlElement
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string _id { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint _interval { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool _pause { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool _withJs { get; set; }

        public Carousel(string id)
            : base("div")
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException("id");

            this._id = HtmlHelper.GenerateIdFromName(id);
            this._interval = 3500;
            EnsureClass("carousel slide");
            EnsureHtmlAttribute("id", this._id);
        }

        public Carousel DontSlide()
        {
            EnsureClassRemoval("slide");
            return this;
        }

        public Carousel Pause()
        {
            this._pause = true;
            EnsureHtmlAttribute("data-pause", "hover");
            return this;
        }

        public Carousel Interval(uint interval)
        {
            this._interval = interval;
            EnsureHtmlAttribute("data-interval", interval.ToString());
            return this;
        }

        public Carousel WithJs()
        {
            this._withJs = true;
            return this;
        }

        public Carousel HtmlAttributes(IDictionary<string, object> htmlAttributes)
        {
            SetHtmlAttributes(htmlAttributes);
            return this;
        }

        public Carousel HtmlAttributes(object htmlAttributes)
        {
            SetHtmlAttributes(htmlAttributes);
            return this;
        }
    }
}
