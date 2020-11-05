using Jogoteca.Repository;
using Jogoteca.Repository.Interfaces;
using Jogoteca.Models.Entities;
using Jogoteca.DbContexts;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Jogoteca.Repository.Implementations
{
    public class UserGameRepository : GenericRepository<UserGame, JogotecaDbContext>, IUserGameRepository
    {
        public UserGameRepository(JogotecaDbContext context) : base(context) {

        }
        
        public override async ValueTask<UserGame> GetById(Guid id)
        {
            return await Context.UserGames
                .Where(ug => ug.Id == id)
                .Include(ug => ug.Game)
                .Include(ug => ug.User)
                .FirstOrDefaultAsync();
        }

        public async Task<List<UserGame>> SearchByGameAndOwner(
            Guid ownerId,
            Guid? gameId = null,
            bool onlyBorrowable = false
        ) {
            var query = Context.UserGames.Where(go => go.User.Id == ownerId);
            
            if(gameId.HasValue)
            {
                query = query.Where(go => go.Game.Id == gameId);
            }

            if(onlyBorrowable){
                query = query.Where(go => !go.GameBorrowings.Any(gb => gb.RealEndDate == null));
            }

            return await query
                .Include(go => go.Game)
                .Include(go => go.User)
                .ToListAsync();
        }
    
        public Task<List<Game>> SearshGamesByUser(Guid userId){
            return Context.UserGames.Where(go => go.User.Id == userId).Select(go => go.Game).ToListAsync();
        }
    }
}