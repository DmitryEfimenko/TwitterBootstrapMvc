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
        public string id { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint interval { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool pause { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool withJs { get; set; }

        public Carousel(string id)
            : base("div")
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException("id");

            this.id = HtmlHelper.GenerateIdFromName(id);
            this.interval = 3500;
            EnsureClass("carousel slide");
            EnsureHtmlAttribute("id", this.id);
        }

        public Carousel DontSlide()
        {
            EnsureClassRemoval("slide");
            return this;
        }

        public Carousel Pause()
        {
            this.pause = true;
            EnsureHtmlAttribute("data-pause", "hover");
            return this;
        }

        public Carousel Interval(uint interval)
        {
            this.interval = interval;
            EnsureHtmlAttribute("data-interval", interval.ToString());
            return this;
        }

        public Carousel WithJs()
        {
            this.withJs = true;
            return this;
        }

        public Carousel HtmlAttributes(object htmlAttributes)
        {
            SetHtmlAttributes(htmlAttributes);
            return this;
        }
    }
}
