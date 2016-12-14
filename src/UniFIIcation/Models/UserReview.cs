using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniFIIcation.Models
{
    public class UserReview
    {
        [DataType(DataType.MultilineText)]
        public string Headline { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Comment { get; set; }

        public string Button { get; set; }
    }
}
