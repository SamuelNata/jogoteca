using System;
using Microsoft.EntityFrameworkCore;
using Jogoteca.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Jogoteca.DbContexts
{
    public class JogotecaDbContext : BaseDbContext
    {
        public JogotecaDbContext(DbContextOptions<JogotecaDbContext> options):base(options) {  }

        // The line bellow was commented because the IdendityContext already declare it
        // public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameBorrowing> GameBorrowings { get; set; }
        public DbSet<UserGame> UserGames { get; set; }
    }
}
