using System;
using System.ComponentModel.DataAnnotations;

namespace ProiectDeTest8.Models
{
    public class Postare
    {
        [Required]
        public Guid PostareId { get; set; }
        [MaxLength(1000)]
        [Required]
        public string Content { get; set; }

        private DateTime _insDate = DateTime.Now;
        public DateTime DateTime
        {
            get { return _insDate; }
            set { _insDate = value; }
        }


        public Guid UserId { get; set; }
        public int MaterieId { get; set; }
        public Materie Materie { get; set; }
    }
}
