using System;
using System.ComponentModel.DataAnnotations;

namespace UniFIIcation.Models
{
    public class Postare
    {
        [Required]
        public Guid PostareId { get; set; }

        [MaxLength(1000)]
        [Required]
        public string Content { get; set; }

        public DateTime DateTime { get; set; } = DateTime.Now;


        public Guid UserId { get; set; }
        public int MaterieId { get; set; }
        public Materie Materie { get; set; }
    }
}