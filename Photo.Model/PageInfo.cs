using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Photo.Model
{
    [Table("Page_info")]
    public class PageInfo
    {
        public PageInfo() { }

        public int id { get; set; }

        [Required]
        public int url_id { get; set; }

        [StringLength(20)]
        public string encoding { get; set; }

        public string content { get; set; }

        [StringLength(200)]
        public string title { get; set; }

        [StringLength(1000)]
        public string description { get; set; }

        public DateTime add_time { get; set; }

        public int is_readed { get; set; }

        [NotMapped]
        public IEnumerable<FileInfo> fiels { get; set; }
    }
}
