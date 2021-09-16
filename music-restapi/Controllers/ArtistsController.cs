using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using music_restapi.Data;
using music_restapi.Models;
using Microsoft.VisualStudio.TestPlatform.Utilities.Helpers;
using Microsoft.EntityFrameworkCore;

namespace music_restapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        public APIDbContext _dbContext;
        public ArtistsController(APIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Artist artist)
        {
            await _dbContext.Artists.AddAsync(artist);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        // api/artists
        [HttpGet]
        public async Task<IActionResult> GetArtists()
        {
            var artists = await (from artist in _dbContext.Artists
                                select new
                                {
                                    Id = artist.ID,
                                    Name = artist.Name
                                }).ToListAsync();
            return Ok(artists);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ArtistDetails([FromForm]int id)
        {
            var artist = await _dbContext.Artists.Where(a=>a.ID == id).Include(a => a.Songs).ToListAsync();
            return Ok(artist);
        }
    }
}
