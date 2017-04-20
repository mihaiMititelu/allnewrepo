using System;
using System.ComponentModel.DataAnnotations;

namespace DungeonMaster.Models
{
    public class Competition
    {
        [Key]
        public Guid Id { get; set;}

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public int Type { get; set; }

        [Required]
        public int Format { get; set; }

        public int Registration { get; set; }

        public DateTime StartTime { get; set; }

        [StringLength(255)]
        public string Game { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }
    }
}
