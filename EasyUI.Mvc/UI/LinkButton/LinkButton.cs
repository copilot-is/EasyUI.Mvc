using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;

namespace EasyUI.Mvc.UI
{
    public class LinkButton : ViewComponentBase
    {
        public LinkButton(ViewContext viewContext)
            : base(viewContext)
        {

        }

        public string Text
        {
            get;
            set;
        }

        public string OnClick
        {
            get;
            set;
        }

        protected override void WriteHtml(HtmlTextWriter writer)
        {
            new LinkButtonHtmlBuilder(this).Build().WriteTo(writer);

            base.WriteHtml(writer);
        }
    }
}
