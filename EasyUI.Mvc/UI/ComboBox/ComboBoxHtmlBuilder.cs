using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using EasyUI.Mvc.Extensions;

namespace EasyUI.Mvc.UI
{
    public class ComboBoxHtmlBuilder
    {
        public ComboBoxHtmlBuilder(ComboBox component)
        {
            this.Component = component;
        }

        public ComboBox Component
        {
            get;
            private set;
        }

        public IHtmlNode Build()
        {
            IHtmlNode textbox = new HtmlElement("input")
                .Attribute("id", Component.Id)
                .Attribute("name", Component.Name)
                .Attribute("data-options", Component.Options.ToDataOptionsString())
                .AddClass(new string[] { "easyui-combobox" })
                .Attributes(Component.HtmlAttributes);

            return textbox;
        }
    }
}
