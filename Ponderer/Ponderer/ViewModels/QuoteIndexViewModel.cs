using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ponderer.Data;
using Ponderer.Models;

namespace Ponderer.ViewModels
{
    public class QuoteIndexViewModel
    {
        public Quote Quote { get; set; }

        public IEnumerable<Quote> Quotes { get; set; }

        private ApplicationDbContext _context;

        public QuoteIndexViewModel(ApplicationDbContext context)
        {
            Quotes = context.Quotes;


        }

        public QuoteIndexViewModel(DbSet<Quote> quotes)
        {
            Quotes = quotes;
        }
    }
}
