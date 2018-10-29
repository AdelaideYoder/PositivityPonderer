using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ponderer.Models;

namespace Ponderer.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {}
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Lyric> Lyrics { get; set; }
        public DbSet<Mantra> Mantras{ get; set; }
        public DbSet<Quote> Quotes { get; set; }
    }
}
