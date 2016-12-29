using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniFIIcation.Models
{

    public class Announcement
    {
        [Key]
        public Guid Id;
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(1000)]
        public string TextContent { get; set; }
        public string Author { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }

        //public ICollection<Announcement> News; todo> do we need this?
    }
}