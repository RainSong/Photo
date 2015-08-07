using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Photo.Web.Common
{
    public class FormHelper : UIParamemterHelper
    {
        public override object GetValue(string key)
        {
            return HttpContext.Current.Request.Form[key];
        }
    }
}