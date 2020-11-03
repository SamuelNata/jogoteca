using Jogoteca.Repository;
using Jogoteca.Repository.Interfaces;
using Jogoteca.Models.Entities;
using Jogoteca.DbContexts;

namespace Jogoteca.Web.Repository.Implementations
{
    public class GameRepository : GenericRepository<Game, JogotecaDbContext>, IGameRepository
    {
        public GameRepository(JogotecaDbContext context) : base(context) {

        }
    }
}