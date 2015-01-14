using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using EasyUI.Mvc.Extensions;
using System.Web;

namespace EasyUI.Mvc.UI
{
    public class DataGridHtmlBuilder
    {
        public DataGridHtmlBuilder(DataGrid component)
        {
            this.Component = component;
        }

        public DataGrid Component
        {
            get;
            private set;
        }

        public IHtmlNode Build()
        {
            IHtmlNode datagrid = null;
            IHtmlNode div = new HtmlElement("div")
                .Attribute("id", Component.Id)
                .Attributes(Component.HtmlAttributes);
            IHtmlNode script = new HtmlElement("script");

            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("$('#{0}').datagrid(", Component.Id);

            if (Component.Options.Count > 0 ||
                Component.FrozenColumns.Count > 0 ||
                Component.Columns.Count > 0 ||
                Component.ToolBar.Count > 0)
            {
                builder.Append("{ ");
                builder.Append(string.Format("{0}, {1}{2}{3}",
                    Component.Options.ToDataOptionsString(),
                    ConvertColumnsString(Component.FrozenColumns, "frozenColumns"),
                    ConvertColumnsString(Component.Columns, "columns"),
                    ConvertToolbarString(Component.ToolBar)).TrimStart(',').Trim().TrimEnd(','));
                builder.Append(" }");
            }
            builder.Append(");");

            script.Html(builder.ToString());

            datagrid = new LiteralNode(string.Format("{0}\r\n{1}", div.ToString(), script.ToString()));
            return datagrid;
        }

        private static string ConvertToolbarString(IList<IDictionary<string, object>> list)
        {
            StringBuilder builder = new StringBuilder();
            if (list.Count > 0)
            {
                builder.Append("toolbar: [");
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].ContainsKey("separator"))
                    {
                        builder.AppendFormat("'{0}'", list[i]["separator"]);
                    }
                    else if (list[i].ContainsKey("template"))
                    {
                        builder.AppendFormat("'{0}'", list[i]["template"]);
                    }
                    else
                    {
                        builder.AppendFormat("{{ {0} }}", list[i].ToDataOptionsString());
                    }
                    if (i < list.Count - 1)
                    {
                        builder.Append(", ");
                    }
                }
                builder.Append("], ");
            }
            return builder.ToString();
        }

        private static string ConvertColumnsString(IList<IDictionary<string, object>> list, string key)
        {
            StringBuilder builder = new StringBuilder();
            if (list.Count > 0)
            {
                builder.AppendFormat("{0}: [[", key);
                for (int i = 0; i < list.Count; i++)
                {
                    builder.AppendFormat("{{ {0} }}", list[i].ToDataOptionsString());

                    if (i < list.Count - 1)
                    {
                        builder.Append(", ");
                    }
                }
                builder.Append("]], ");
            }
            return builder.ToString();
        }
    }
}
