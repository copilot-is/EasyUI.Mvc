using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI;
using EasyUI.Mvc.Infrastructure;

namespace EasyUI.Mvc.UI
{
    public class DataGrid : ViewComponentBase
    {
        public IList<IDictionary<string, object>> Columns
        {
            get;
            private set;
        }

        public IList<IDictionary<string, object>> FrozenColumns
        {
            get;
            private set;
        }

        public IList<IDictionary<string, object>> ToolBar
        {
            get;
            private set;
        }

        public DataGrid(ViewContext viewContext) 
            : base(viewContext)
        {
            Columns = new List<IDictionary<string, object>>();
            FrozenColumns = new List<IDictionary<string, object>>();
            ToolBar = new List<IDictionary<string, object>>();
        }

        protected override void WriteHtml(HtmlTextWriter writer)
        {
            new DataGridHtmlBuilder(this).Build().WriteTo(writer);

            base.WriteHtml(writer);
        }
    }
}