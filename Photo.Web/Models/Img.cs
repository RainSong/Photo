using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Photo.Web.Models
{
    public class Img
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        public int PageId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// 显示的宽度
        /// </summary>
        public int DisplayWidth
        {
            get { return 635; }
        }
        /// <summary>
        /// 显示的高度
        /// </summary>
        public int DisplayHeight
        {
            get
            {
                if (Width * Height == 0) return 0;
                return (Height * DisplayWidth) / Width;
            }
        }
    }
}