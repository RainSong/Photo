using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Photo.Web.Models
{
    public class Tag
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Citations { get; set; }

        public IEnumerable<Web.Models.Page> Pages { get; set; }
    }
}