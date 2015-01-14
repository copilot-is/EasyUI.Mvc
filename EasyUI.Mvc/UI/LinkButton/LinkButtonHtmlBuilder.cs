using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EasyUI.Mvc.Extensions;

namespace EasyUI.Mvc.UI
{
    public class LinkButtonHtmlBuilder
    {
        public LinkButtonHtmlBuilder(LinkButton component)
        {
            this.Component = component;
        }

        public LinkButton Component
        {
            get;
            private set;
        }

        public IHtmlNode Build()
        {
            IHtmlNode textbox = new HtmlElement("a")
                .Attribute("id", Component.Id)
                .Attribute("onclick", Component.OnClick)
                .Attribute("data-options", Component.Options.ToDataOptionsString())
                .AddClass(new string[] { "easyui-linkbutton" })
                .Attributes(Component.HtmlAttributes)
                .Text(Component.Text);

            return textbox;
        }
    }
}
