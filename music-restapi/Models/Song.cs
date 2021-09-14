using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace music_restapi.Models
{
    public class Song
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title cannot be null or empty")]
        public string Title { get; set; }
        [MinLength(3)]
        public string Language { get; set; }
        public string Duration { get; set; }
    }
}
