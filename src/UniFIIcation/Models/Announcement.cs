using System;
using System.ComponentModel.DataAnnotations;

namespace UniFIIcation.Models
{
    public class Announcement
    {
        public string Title { get; set; }
        [Required]
        [StringLength(1000)]
        public string TextContent { get; set; }
        public string Author { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }
    }
}