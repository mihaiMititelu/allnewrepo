using System;
using System.ComponentModel.DataAnnotations;

namespace UniFIIcation.Models
{

    public class Announcement
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(1000)]
        public string TextContent { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }
    }
}