using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Photo.Web
{
    public class CommonHelpr
    {
        public static bool IsNull<T>(T t)
        {
            if (t == null) return true;
            if (System.DBNull.Value.Equals(t)) return true;
            return false;
        }
    }
}