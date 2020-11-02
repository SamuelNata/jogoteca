using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jogoteca.Model.Exceptions;
using Jogoteca.Models.Entities;
using Jogoteca.Repository.Interfaces;
using Jogoteca.Service.Interfaces;
using Jogoteca.Web.Extensions;

namespace Jogoteca.Service.Implementations
{
    public class UserService : GenericService<IUserRepository, User>, IUserService
    {
        public UserService(IUserRepository repository) : base(repository)
        {
            
        }
    }
}