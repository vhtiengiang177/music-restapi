using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using music_restapi.Data;
using music_restapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace music_restapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private APIDbContext _dbContext;

        public SongsController(APIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<SongsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _dbContext.Songs.ToListAsync());
        }

        // GET api/<SongsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var song = await _dbContext.Songs.FindAsync(id);
            if(song == null)
            {
                return NotFound();
            }
            else
                return Ok(song);
        }

        // POST api/<SongsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Song song)
        {
            await _dbContext.Songs.AddAsync(song);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<SongsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Song songObj)
        {
            var song = await _dbContext.Songs.FindAsync(id);
            if(song == null)
            {
                return NotFound("No record found against this id");
            }
            else
            {
                song.Title = songObj.Title;
                song.Language = songObj.Language;
                await _dbContext.SaveChangesAsync();
                return Ok("Record Updated Successfully");
            }
        }

        // DELETE api/<SongsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var song = await _dbContext.Songs.FindAsync(id);
            if(song == null)
            {
                return NotFound("No record found against this id");
            }
            else
            {
                _dbContext.Songs.Remove(song);
                await _dbContext.SaveChangesAsync();
                return Ok("Record Deleted");
            }
        }

    }
}
