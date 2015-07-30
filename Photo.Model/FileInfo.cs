using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Photo.Model
{
    [Table("file_info")]
    public class FileInfo
    {
        public int id { get; set; }

        [Required]
        [StringLength(32)]
        public string md5 { get; set; }

        [StringLength(50)]
        public string extension { get; set; }

        public int size { get; set; }

        public string url { get; set; }

        public DateTime add_time { get; set; }

        [StringLength(200)]
        public string path { get; set; }

        [NotMapped]
        public int PageId { get; set; }


        public int width { get; set; }

        public int height { get; set; }
    }
}
