using System;
using Microsoft.EntityFrameworkCore;
using Jogoteca.Models.Entities;

namespace Jogoteca.Models.DbContexts
{
    public class DefaultDbContext : BaseDbContext
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options):base(options) {  }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     // Addd the Postgres Extension for UUID generation
        //     modelBuilder.HasPostgresExtension("uuid-ossp");
        // }

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameBorrowing> GameBorrowings { get; set; }
        public DbSet<UserGame> UserGames { get; set; }
    }
}
