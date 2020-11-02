using Jogoteca.Repository;
using Jogoteca.Repository.Interfaces;
using Jogoteca.Models.Entities;
using Jogoteca.DbContexts;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Jogoteca.Web.Repository.Implementations
{
    public class UserRepository : GenericRepository<User, JogotecaDbContext>, IUserRepository
    {
        public UserRepository(JogotecaDbContext context) : base(context) {

        }
    }
}