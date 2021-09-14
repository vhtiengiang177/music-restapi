using Microsoft.EntityFrameworkCore;
using music_restapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace music_restapi.Data
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {

        }

        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>().HasData(
                new Song
                {
                    Id = 1,
                    Title = "A",
                    Language = "Eng",
                    Duration = "2:30"
                },
                new Song 
                { 
                    Id = 2,
                    Title = "B",
                    Language = "Viet",
                    Duration = "3:00"
                });
        }
    }
}
