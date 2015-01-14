using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyUI.Mvc.UI
{
    public class LinkButtonBuilder : ViewComponentBuilderBase<LinkButton, LinkButtonBuilder>
    {
        public LinkButtonBuilder(LinkButton component)
            : base(component)
        {

        }

        public LinkButtonBuilder OnClick(string click)
        {
            Component.OnClick = click;
            return this;
        }

        public LinkButtonBuilder Text(string text)
        {
            Component.Text = text;
            return this;
        }
    }
}
