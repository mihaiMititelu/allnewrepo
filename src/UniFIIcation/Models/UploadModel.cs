using System;
using System.ComponentModel.DataAnnotations;

namespace UniFIIcation.Models
{
    public class Upload
    {
        [Required]
        public Guid UploadId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        public DateTime DateTimeUpload { get; set; } = DateTime.Now;

        public Guid UserId { get; set; }
        public int MaterieId { get; set; }
        public Materie Materie { get; set; }
    }
}
