using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ponderer.Data;
using Ponderer.Models;

namespace Ponderer.ViewModels
{
    public class QuoteCreateViewModel
    {
        public Quote Quote { get; set; }

        public int QuoteId { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        private ApplicationDbContext _context;

        public QuoteCreateViewModel(ApplicationDbContext context)
        {
            _context = context;
        }

    }
}
