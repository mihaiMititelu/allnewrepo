using System.ComponentModel.DataAnnotations;

namespace UniFIIcation.Models
{
    public class MateriiModel
    {
        [DataType(DataType.MultilineText)]
        public string Headline { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Comment { get; set; }

        public string Button { get; set; }
    }
}