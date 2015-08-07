using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Photo.Web
{
    public class RoteValueHelper : UIParamemterHelper
    {
        public override object GetValue(string key)
        {
            return HttpContext.Current.Request.RequestContext.RouteData.Values[key];
        }
    }
}