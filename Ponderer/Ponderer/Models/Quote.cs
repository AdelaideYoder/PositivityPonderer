﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ponderer.Models
{
    public class Quote
    {
        [Key]
        public int QuoteId { get; set; }

        public string InspirationalQuote { get; set; }

        public string Author { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
