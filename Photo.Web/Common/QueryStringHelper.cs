using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Photo.Web
{
    public class QueryStringHelper : UIParamemterHelper
    {
        public override object GetValue(string key)
        {
            if (string.IsNullOrEmpty(key)) return null;
            return HttpContext.Current.Request.QueryString[key];
        }
    }
}