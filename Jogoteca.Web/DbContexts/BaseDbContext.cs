using Microsoft.EntityFrameworkCore;
using Jogoteca.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity;

namespace Jogoteca.DbContexts
{
    public abstract class BaseDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {

        public BaseDbContext() { }
        public BaseDbContext(DbContextOptions options) : base(options) {}
    }
}