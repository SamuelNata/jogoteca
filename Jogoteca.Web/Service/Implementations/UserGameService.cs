using Jogoteca.Models.Entities;
using Jogoteca.Repository.Interfaces;
using Jogoteca.Service.Interfaces;

namespace Jogoteca.Service.Implementations
{
    public class UserGameService : GenericService<IUserGameRepository, UserGame>, IUserGameService
    {
        public UserGameService(IUserGameRepository repository) : base(repository)
        {

        }
    }
}