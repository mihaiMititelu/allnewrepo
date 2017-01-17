
using System.Collections.Generic;

namespace UniFIIcation.Models
{
    public class Materie
    {

        public int MaterieId { get; set; }
        public string Name { get; set; }

        public List<Postare> Postari { get; set; }
        public List<Upload> Uploads { get; set; }
    }
}
