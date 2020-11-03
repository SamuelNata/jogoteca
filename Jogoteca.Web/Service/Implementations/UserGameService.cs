using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jogoteca.Models.Exceptions;
using Jogoteca.Models.Entities;
using Jogoteca.Repository.Interfaces;
using Jogoteca.Service.Interfaces;
using Jogoteca.Web.Extensions;

namespace Jogoteca.Service.Implementations
{
    public class UserGameService : GenericService<IUserGameRepository, UserGame>, IUserGameService
    {
        public UserGameService(IUserGameRepository repository) : base(repository)
        {
            
        }

        public Task<List<UserGame>> SearchByGameAndOwner(
            Guid ownerId,
            Guid? gameId = null,
            bool onlyBorrowable = false
        ){
            return Repository.SearchByGameAndOwner(ownerId, gameId, onlyBorrowable);
        }

        public Task<List<Game>> SearshGamesByUser(Guid userId){
            return Repository.SearshGamesByUser(userId);
        }

        public async Task<int> RemoveGameFromUser(Guid gameId, Guid userId){
            var gameOwnerships = await SearchByGameAndOwner(userId, gameId, true);
            if(!gameOwnerships.Any()){
                throw new BusinessRuleFException("Você não possui este jogo para excluir, ou ele está emprestado");
            }

            var gameToRemove = gameOwnerships.First();
            return await Remove(gameToRemove);
        }
    }
}