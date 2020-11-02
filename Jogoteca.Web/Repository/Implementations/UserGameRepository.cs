using Jogoteca.Repository;
using Jogoteca.Repository.Interfaces;
using Jogoteca.Models.Entities;
using Jogoteca.DbContexts;

namespace Jogoteca.Web.Repository.Implementations
{
    public class UserGameRepository : GenericRepository<UserGame, JogotecaDbContext>, IUserGameRepository
    {
        public UserGameRepository(JogotecaDbContext context) : base(context) {

        }
    }
}