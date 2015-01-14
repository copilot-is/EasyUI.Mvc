using EasyUI.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI;

namespace EasyUI.Mvc.UI
{
    /// <summary>
    /// View component base class.
    /// </summary>
    public abstract class ViewComponentBase
    {
        private string name;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewComponentBase"/> class.
        /// </summary>
        /// <param name="viewContext">The view context.</param>
        protected ViewComponentBase(ViewContext viewContext)
        {
            Guard.IsNotNull(viewContext, "viewContext");

            ViewContext = viewContext;
            HtmlAttributes = new RouteValueDictionary();
            Options = new RouteValueDictionary();
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                Guard.IsNotNullOrEmpty(value, "value");
                name = value;
            }
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        /// <value>The id.</value>
        public string Id
        {
            get
            {
                // Return from htmlattributes if user has specified
                // otherwise build it from name
                return HtmlAttributes.ContainsKey("id") ?
                       (string)HtmlAttributes["id"] :
                       (!string.IsNullOrEmpty(Name) ? Name.Replace(".", HtmlHelper.IdAttributeDotReplacement) : null);
            }
        }

        /// <summary>
        /// Gets the HTML attributes.
        /// </summary>
        /// <value>The HTML attributes.</value>
        public IDictionary<string, object> HtmlAttributes
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the Options.
        /// </summary>
        /// <value>The Options.</value>
        public IDictionary<string, object> Options
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the view context to rendering a view.
        /// </summary>
        /// <value>The view context.</value>
        public ViewContext ViewContext
        {
            get;
            private set;
        }

        /// <summary>
        /// Renders the component.
        /// </summary>
        public void Render()
        {
            var baseWriter = ViewContext.Writer;
            using (HtmlTextWriter textWriter = new HtmlTextWriter(baseWriter))
            {
                WriteHtml(textWriter);
            }
        }

        public virtual void VerifySettings()
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new InvalidOperationException("Name cannot be blank.");
            }

            if (!Name.Contains("<#=") && Name.IndexOf(" ") != -1)
            {
                throw new InvalidOperationException("Name cannot contain spaces.");
            }
        }

        public string ToHtmlString()
        {
            using (var output = new StringWriter())
            {
                WriteHtml(new HtmlTextWriter(output));
                var html = output.ToString();
                html = html.Replace("&#39;", "'");
                return html;
            }
        }

        /// <summary>
        /// Writes the HTML.
        /// </summary>
        protected virtual void WriteHtml(HtmlTextWriter writer)
        {
            VerifySettings();
        }
    }
}