using Microsoft.EntityFrameworkCore;
using Jogoteca.Models.Entities;

namespace Jogoteca.DbContexts
{
    public abstract class BaseDbContext : DbContext
    {

        public BaseDbContext() { }
        public BaseDbContext(DbContextOptions options) : base(options) {}
    }
}