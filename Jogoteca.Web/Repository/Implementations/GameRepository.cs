using Jogoteca.Repository;
using Jogoteca.Repository.Interfaces;
using Jogoteca.Models.Entities;
using Jogoteca.Models.DbContexts;

namespace Jogoteca.Web.Repository.Implementations
{
    public class GameRepository : GenericRepository<Game, DefaultDbContext>, IGameRepository
    {
        public GameRepository(DefaultDbContext context) : base(context) {

        }
    }
}