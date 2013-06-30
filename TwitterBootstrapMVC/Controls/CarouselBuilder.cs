using System.ComponentModel;
using System.Web.Mvc;
using TwitterBootstrapMVC.Infrastructure;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Controls
{
    public class CarouselBuilder<TModel> : BuilderBase<TModel, Carousel>
    {
        private readonly UrlHelper urlHelper;
        private bool _isFirstItem = true;

        internal CarouselBuilder(HtmlHelper<TModel> htmlHelper, Carousel carousel)
            : base(htmlHelper, carousel)
        {
            this.urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            base.textWriter.Write(@"<div class=""carousel-inner"">");
        }

        public void Image(string url, string altText, object htmlAttributes = null)
        {
            RendererImage(url, altText, htmlAttributes);
        }

        public CarouselCaptionPanel ImageWithCaption(string url, string altText, object htmlAttributes = null)
        {
            RendererImage(url, altText, htmlAttributes);
            return new CarouselCaptionPanel(base.textWriter);
        }

        public CarouselCustomItem CustomItem()
        {
            bool isFirst = _isFirstItem;

            if (_isFirstItem)
                _isFirstItem = false;

            return new CarouselCustomItem(base.textWriter, this.urlHelper, isFirst);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Dispose()
        {
            base.textWriter.Write("</div>");

            base.textWriter.Write(string.Format(@"<a class=""left carousel-control"" data-slide=""prev"" href=""#{0}"">‹</a>", base.element._id));
            base.textWriter.Write(string.Format(@"<a class=""right carousel-control"" data-slide=""next"" href=""#{0}"">›</a>", base.element._id));

            base.textWriter.Write(base.element.EndTag);

            if (base.element._withJs)
            {
                base.textWriter.Write(string.Format(
@"<script type=""text/javascript"">
    $(document).ready(function(){{
        $('#{0}').carousel({{
            interval: {1}
        }})
    }});
</script>", base.element._id, base.element._interval));
            }
        }

        private void RendererImage(string url, string altText, object htmlAttributes = null)
        {
            if (_isFirstItem)
            {
                base.textWriter.Write(@"<div class=""item active"">");
                _isFirstItem = false;
            }
            else
            {
                base.textWriter.Write(@"<div class=""item"">");
            }
            var imgBuilder = new TagBuilder("img");
            imgBuilder.MergeAttributes(htmlAttributes.ObjectToHtmlAttributesDictionary());
            imgBuilder.MergeAttribute("src", urlHelper.Content(url));
            imgBuilder.MergeAttribute("alt", altText);
            base.textWriter.Write(imgBuilder.ToString(TagRenderMode.SelfClosing));
            base.textWriter.Write("</div>");
        }
    }
}
