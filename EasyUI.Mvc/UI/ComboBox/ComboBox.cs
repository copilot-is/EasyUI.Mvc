using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;

namespace EasyUI.Mvc.UI
{
    public class ComboBox : ViewComponentBase
    {
        public ComboBox(ViewContext viewContext)
            : base(viewContext)
        {

        }

        protected override void WriteHtml(HtmlTextWriter writer)
        {
            new ComboBoxHtmlBuilder(this).Build().WriteTo(writer);

            base.WriteHtml(writer);
        }
    }
}
