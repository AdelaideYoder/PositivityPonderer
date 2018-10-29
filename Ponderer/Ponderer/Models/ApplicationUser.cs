﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Ponderer.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {

        }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        public string Email { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Quote> Quotes { get; set; }

        public virtual ICollection<Lyric> Lyrics { get; set; }

        public virtual ICollection<Mantra> Mantras { get; set; }
    }
}
