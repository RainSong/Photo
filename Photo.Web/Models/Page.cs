using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Photo.Web.Models
{
    public class Page
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Tag> Tags { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Img> Imgs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Img DefaultImg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddTime { get; set; }
    }
}