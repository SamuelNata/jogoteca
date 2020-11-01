using Jogoteca.Models.Entities;
using Jogoteca.Repository.Interfaces;
using Jogoteca.Service.Interfaces;

namespace Jogoteca.Service.Implementations
{
    public class GameService : GenericService<IGameRepository, Game>, IGameService
    {
        public GameService(IGameRepository repository) : base(repository)
        {

        }
    }
}