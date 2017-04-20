using System.ComponentModel.DataAnnotations;

namespace DungeonMaster.Models
{
    public class Team
    {
        [Required]
        public string TeamName { get; set; }

        public string Website { get; set; }

        public string Description { get; set; }
    }
}
