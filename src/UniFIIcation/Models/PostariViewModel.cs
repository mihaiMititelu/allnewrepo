using System.Collections.Generic;

namespace UniFIIcation.Models
{
    public class PostariViewModel
    {
       
        public List<Postare> VmPostari { get; set; }
        public List<Upload> VmUploads { get; set; }
        public string NumeMaterie;
        public int MaterieId;
        public string NumeUser;

        public PostariViewModel()
        {
            VmPostari = new List<Postare>();
            VmUploads = new List<Upload>();
        }
    }
}
