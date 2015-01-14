using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace EasyUI.Mvc.UI
{
    public static class HtmHelperExtension
    {
        public static ViewComponentFactory EasyUI(this HtmlHelper helper)
        {
            return new ViewComponentFactory(helper);
        }
    }
}
