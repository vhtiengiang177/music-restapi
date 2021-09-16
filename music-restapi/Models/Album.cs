using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace music_restapi.Models
{
    public class Album
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ArtistID { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}
