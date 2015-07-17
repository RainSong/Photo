using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Photo.Model
{
    [Table("page_tag")]
    public class PageTag
    {
        public PageTag() { }

        public int id { get; set; }

        [Required]
        public int page_id { get; set; }

        [Required]
        public int tag_id { get; set; }

        public DateTime add_time { get; set; }
    }
}
