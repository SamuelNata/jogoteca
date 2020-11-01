using Microsoft.EntityFrameworkCore;
using Jogoteca.Models.Entities;

namespace Jogoteca.Models
{
    public abstract class BaseDbContext : DbContext
    {

        public BaseDbContext() { }
        public BaseDbContext(DbContextOptions options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameBorrowing> GameBorrowings { get; set; }
        public DbSet<UserGame> UserGames { get; set; }
    }
}