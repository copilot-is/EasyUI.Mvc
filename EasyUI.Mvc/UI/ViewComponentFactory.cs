using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using EasyUI.Mvc.Infrastructure;

namespace EasyUI.Mvc.UI
{
    /// <summary>
    /// Provides the factory methods for creating EasyUI View Components.
    /// </summary>
    public class ViewComponentFactory
    {
        public ViewComponentFactory(HtmlHelper htmlHelper)
        {
            Guard.IsNotNull(htmlHelper, "htmlHelper");

            HtmlHelper = htmlHelper;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HtmlHelper HtmlHelper
        {
            get;
            set;
        }

        private ViewContext ViewContext
        {
            get
            {
                return HtmlHelper.ViewContext;
            }
        }

        /// <summary>
        /// Creates a <see cref="DataGrid"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        /// &lt;%= Html.EasyUI().DataGrid()
        ///              .Name("datagrid");
        /// %&gt;
        /// </code>
        /// </example>
        public virtual DataGridBuilder DataGrid()
        {
            return DataGridBuilder.Create(Register(() => new DataGrid(ViewContext)));
        }

        /// <summary>
        /// Creates a <see cref="TextBox"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        /// &lt;%= Html.EasyUI().TextBox()
        ///              .Name("textbox");
        /// %&gt;
        /// </code>
        /// </example>
        public virtual TextBoxBuilder TextBox()
        {
            return TextBoxBuilder.Create(Register(() => new TextBox(ViewContext)));
        }

        /// <summary>
        /// Creates a <see cref="ComboBox"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        /// &lt;%= Html.EasyUI().ComboBox()
        ///              .Name("combobox");
        /// %&gt;
        /// </code>
        /// </example>
        public virtual ComboBoxBuilder ComboBox()
        {
            return ComboBoxBuilder.Create(Register(() => new ComboBox(ViewContext)));
        }

        /// <summary>
        /// Creates a <see cref="LinkButton"/>
        /// </summary>
        /// <example>
        /// <code lang="CS">
        /// &lt;%= Html.EasyUI().LinkButton()
        ///              .Name("linkbutton");
        /// %&gt;
        /// </code>
        /// </example>
        public virtual LinkButtonBuilder LinkButton()
        {
            return LinkButtonBuilder.Create(Register(() => new LinkButton(ViewContext)));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public TViewComponent Register<TViewComponent>(Func<TViewComponent> factory) where TViewComponent : ViewComponentBase
        {
            var component = factory();

            return component;
        }
    }
}
