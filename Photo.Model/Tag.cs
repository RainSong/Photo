using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Photo.Model
{
    [Table("tag")]
    public class Tag
    {
        public Tag() { }

        
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string tag { get; set; }

        public DateTime? add_time { get; set; }

        public int citations { get; set; }
    }
}
