using System.Collections.Generic;

namespace UniFIIcation.Models
{
    public class PostariViewModel
    {
       
        public List<Postare> VMPostari { get; set; }
        public List<Upload> VMUploads { get; set; }
        public string NumeMaterie;
        public int MaterieId;
        public string NumeUser;

        public PostariViewModel()
        {
            this.VMPostari = new List<Postare>();
            this.VMUploads = new List<Upload>();
        }
    }
}
