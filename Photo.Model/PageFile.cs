using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Photo.Model
{
    [Table("page_file")]
    public  class PageFile
    {
        public PageFile() { }

        public int id { get; set; }

        [Required]
        public int page_id { get; set; }

        [Required]
        public int file_id { get; set; }

        public DateTime add_time { get; set; }
    }
}
