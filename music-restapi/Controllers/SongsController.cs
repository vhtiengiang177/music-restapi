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
    public class SongsController : ControllerBase
    {
        public APIDbContext _dbContext { get; set; }
        public SongsController(APIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Song song)
        {
            await _dbContext.Songs.AddAsync(song);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSongs()
        {
            var songs = await _dbContext.Songs
                .Select(s => new { s.Id, s.Title, s.Duration })
                .ToListAsync();
            return Ok(songs);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> FeaturedSongs()
        {
            var songs = await _dbContext.Songs
                .Where(s=>s.IsFeatured == true)
                .Select(s => new { s.Id, s.Title, s.Duration })
                .ToListAsync();
            return Ok(songs);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> NewSongs()
        {
            var songs = await _dbContext.Songs
                .OrderByDescending(s=> s.UploadedDate)
                .Select(s => new { s.Id, s.Title, s.Duration })
                .Take(3) // so luong record hien thi trong db la 3
                .ToListAsync();
            return Ok(songs);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> SearchSongs(string query)
        {
            var songs = await _dbContext.Songs
                .Where(s=>s.Title.StartsWith(query))
                .Select(s => new { s.Id, s.Title, s.Duration })
                .Take(3) // so luong record hien thi trong db la 3
                .ToListAsync();
            return Ok(songs);
        }
    }
}
