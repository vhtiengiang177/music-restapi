using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using music_restapi.Models;

namespace music_restapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private static List<Song> songs = new List<Song>() {
            new Song(){Id=0, Title="A", Language="English" },
            new Song(){Id=1, Title="B", Language="English" },
            new Song(){Id=2, Title="C", Language="English" },
            new Song(){Id=3, Title="D", Language="English" }
        };

        [HttpGet]
        public IEnumerable<Song> Get()
        {
            return songs;
        }

        [HttpPost]
        public void Post([FromBody]Song song)
        {
            songs.Add(song);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Song song)
        {
            songs[id] = song;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            songs.RemoveAt(id);
        }
    }
}
