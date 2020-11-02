
using Jogoteca.Models.Exceptions;
using Jogoteca.Models.Entities;
using Jogoteca.Repository.Interfaces;
using Jogoteca.Service.Interfaces;

namespace Jogoteca.Service.Implementations
{
    public class UserService : GenericService<IUserRepository, User>, IUserService
    {
        public UserService(IUserRepository repository) : base(repository)
        {
            
        }
    }
}