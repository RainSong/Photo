using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Photo.Model
{
    [Table("url")]
    public class URL
    {
        public URL() { }

        [Required]
        public int id { get; set; }

        [Required]
        [StringLength(500)]
        public string url { get; set; }

        public DateTime add_time { get; set; }

        [Required]
        [StringLength(32)]
        public string md5 { get; set; }

        public int is_read { get; set; }
    }
}
