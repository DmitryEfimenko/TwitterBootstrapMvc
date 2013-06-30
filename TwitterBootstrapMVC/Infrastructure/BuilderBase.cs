using System;
using System.ComponentModel;
using System.IO;
using System.Web.Mvc;

namespace TwitterBootstrapMVC.Infrastructure
{
    public abstract class BuilderBase<TModel, T> : IDisposable where T : HtmlElement
    {
        // Fields
        protected readonly T element;

        protected readonly TextWriter textWriter;
        protected readonly HtmlHelper<TModel> htmlHelper;
        protected readonly AjaxHelper<TModel> ajaxHelper;

        // Methods
        internal BuilderBase(HtmlHelper<TModel> htmlHelper, T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            this.element = element;
            this.htmlHelper = htmlHelper;
            this.textWriter = htmlHelper.ViewContext.Writer;
            this.textWriter.Write(this.element.StartTag);
        }

        internal BuilderBase(AjaxHelper<TModel> ajaxHelper, T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            this.element = element;
            this.ajaxHelper = ajaxHelper;
            this.textWriter = ajaxHelper.ViewContext.Writer;
            this.textWriter.Write(this.element.StartTag);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void Dispose()
        {
            this.textWriter.Write(this.element.EndTag);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() { return base.ToString(); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) { return base.Equals(obj); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() { return base.GetHashCode(); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Type GetType() { return base.GetType(); }
    }
}
