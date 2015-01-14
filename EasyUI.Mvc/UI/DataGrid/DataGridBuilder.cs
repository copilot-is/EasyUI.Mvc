using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Collections;
using EasyUI.Mvc.Extensions;

namespace EasyUI.Mvc.UI
{
    public class DataGridBuilder : ViewComponentBuilderBase<DataGrid, DataGridBuilder>
    {
        public DataGridBuilder(DataGrid component) 
            : base(component)
        {

        }

        /// <summary>
        /// Configures the columns.
        /// </summary>
        /// <param name="configurator">The column action.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.EasyUI().DataGrid()
        ///             .Name("datagrid")
        ///             .Columns(columns =>
        ///             {
        ///                 columns.Add(new { field = "code", title = "Code", width = 100 });
        ///                 columns.Add(new { field = "name", title = "Name", width = 100 });
        ///             })
        /// %&gt;
        /// </code>
        /// </example>
        public DataGridBuilder Columns(Action<DataGridColumnFactory<object>> configurator)
        {
            DataGridColumnFactory<object> obj = new DataGridColumnFactory<object>(base.Component);
            configurator(obj);
            return this;
        }

        /// <summary>
        /// Configures the frozen column.
        /// </summary>
        /// <param name="configurator">The frozen column action.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.EasyUI().DataGrid()
        ///             .Name("datagrid")
        ///             .FrozenColumns(columns =>
        ///             {
        ///                 columns.Add(new { field = "code", title = "Code", width = 100 });
        ///             })
        /// %&gt;
        /// </code>
        /// </example>
        public DataGridBuilder FrozenColumns(Action<DataGridFrozenColumnFactory<object>> configurator)
        {
            DataGridFrozenColumnFactory<object> obj = new DataGridFrozenColumnFactory<object>(base.Component);
            configurator(obj);
            return this;
        }

        /// <summary>
        /// Configures the toolbar.
        /// </summary>
        /// <param name="configurator">The toolbar action.</param>
        /// <example>
        /// <code lang="CS">
        ///  &lt;%= Html.EasyUI().DataGrid()
        ///             .Name("datagrid")
        ///             .ToolBar(toolbar =>
        ///             {
        ///                 toolbar.Add(new { text = "Help", iconCls = "icon-help", handler = "function () { alert('help'); }" });
        ///             })
        /// %&gt;
        /// </code>
        /// </example>
        public DataGridBuilder ToolBar(Action<DataGridToolBarFactory<object>> configurator)
        {
            DataGridToolBarFactory<object> obj = new DataGridToolBarFactory<object>(base.Component);
            configurator(obj);
            return this;
        }
    }

    public class DataGridColumnFactory<T>
    {
        public DataGrid Container { get; private set; }

        public DataGridColumnFactory(DataGrid container)
		{
			this.Container = container;
		}

        public void Add(object columns)
        {
            this.Container.Columns.Add(columns.ToDictionary());
        }
    }

    public class DataGridFrozenColumnFactory<T>
    {
        public DataGrid Container { get; private set; }

        public DataGridFrozenColumnFactory(DataGrid container)
        {
            this.Container = container;
        }

        public void Add(object columns)
        {
            this.Container.FrozenColumns.Add(columns.ToDictionary());
        }
    }

    public class DataGridToolBarFactory<T>
    {
        public DataGrid Container { get; private set; }

        public DataGridToolBarFactory(DataGrid container)
        {
            this.Container = container;
        }

        public void Add(object toolbar)
        {
            this.Container.ToolBar.Add(toolbar.ToDictionary());
        }

        public void Add(string separator)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("separator", separator);
            this.Container.ToolBar.Add(dict);
        }

        public void Template(string template)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("template", template);
            this.Container.ToolBar.Clear();
            this.Container.ToolBar.Add(dict);
        }
    }
}
