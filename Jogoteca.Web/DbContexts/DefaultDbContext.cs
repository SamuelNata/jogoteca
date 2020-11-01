using System;
using Microsoft.EntityFrameworkCore;
using Jogoteca.Models.Entities;

namespace Jogoteca.DbContexts
{
    public class DefaultDbContext : BaseDbContext
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options):base(options) {  }

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameBorrowing> GameBorrowings { get; set; }
        public DbSet<UserGame> UserGames { get; set; }
    }
}
