using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using music_restapi.Data;
using music_restapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace music_restapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        public APIDbContext _dbContext;
        public AlbumsController(APIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Album album)
        {
            await _dbContext.Albums.AddAsync(album);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        public async Task<IActionResult> GetAlbums()
        {
            var albums = await _dbContext.Albums.Select(a => new { a.ID, a.Name }).ToListAsync();
            return Ok(albums);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> AlbumDetails([FromForm] int id)
        {
            var albumdetails = await _dbContext.Albums.Where(a => a.ID == id).Include(a => a.Songs).ToListAsync();
            return Ok(albumdetails);
        }
    }
}
