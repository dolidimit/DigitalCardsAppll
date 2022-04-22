using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalCardsAppll.Data
{
    public class DigitalCardsDbContext : IdentityDbContext
    {
        public DbSet<Card> Cards { get; set; }

        public DbSet<Quote> Quotes { get; set; }

        public DbSet<Sticker> Stickers { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Package> Packages { get; set; }

        public DbSet<Example> Examples { get; set; }

        public DigitalCardsDbContext(DbContextOptions<DigitalCardsDbContext> options)
            : base(options)
        {
        }
    }
}
