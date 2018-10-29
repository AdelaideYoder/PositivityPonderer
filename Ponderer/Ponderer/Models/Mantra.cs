using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ponderer.Models
{
    public class Mantra
    {
        [Key]
        public int MantraId { get; set; }

        public string MorningMantra { get; set; }

        public string PlaceFound { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
