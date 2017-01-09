using System;
using System.ComponentModel.DataAnnotations;

namespace UniFIIcation.Models
{
    public class ReviewModels
    {
        [Key]
        public string Id { get; set; }

        public DateTime DateTime { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(1000)]
        public string Comment { get; set; }
    }
}
