using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ponderer.Models
{
    public class Lyric
    {
        [Key]
        public int LyricId { get; set; }

        [Display(Name = "Music Lyrics")]
        public string MusicLyric { get; set; }

        [Display(Name = "Song Title")]
        public string SongTitle { get; set; }

        public string Artist { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
