using System;
using Microsoft.EntityFrameworkCore;
using Jogoteca.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Jogoteca.Models.DTOs;

namespace Jogoteca.DbContexts
{
    public class JogotecaDbContext : BaseDbContext
    {
        public JogotecaDbContext(DbContextOptions<JogotecaDbContext> options):base(options) {  }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // To query a non-entity class, add the configuration here
            modelBuilder.Entity<GameBorrowingDTO>().HasNoKey();
        }


        // The line bellow was commented because the IdendityContext already declare it
        // public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameBorrowing> GameBorrowings { get; set; }
        public DbSet<UserGame> UserGames { get; set; }
    }
}
