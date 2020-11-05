using System;
using Xunit;
using Moq;
using Jogoteca.Repository.Interfaces;
using Jogoteca.Service.Interfaces;
using System.Threading.Tasks;
using Jogoteca.Models.Entities;
using Jogoteca.Web.Repository.Implementations;
using Jogoteca.Service.Implementations;
using Jogoteca.Models.Exceptions;
using System.Linq;

namespace Jogoteca.Tests
{
    public class GameBorrowingServiceTests : InMemoryTest
    {
        private readonly IGameBorrowingRepository _gameBorrowingRepository;
        private readonly IUserGameRepository _userGameRepository;
        private readonly IGameBorrowingService _sut;

        public GameBorrowingServiceTests(){
            _gameBorrowingRepository = new GameBorrowingRepository(DbContext);
            _userGameRepository = new UserGameRepository(DbContext);
            _sut = new GameBorrowingService(_gameBorrowingRepository, _userGameRepository);
        }


        [Fact]
        public async Task DatabaseIsAvailableAndCanBeConnectedTo()
        {
            Assert.True(await DbContext.Database.CanConnectAsync());
        }

        [Fact]
        public void CantMarkInexistentGameAsReturned()
        {
            Assert.ThrowsAsync<NotFoundException>(() => _sut.MarkAsReturned(new Guid()));
        }

        [Fact]
        public async Task MarkGameAsReturnedIfBorrowingExists()
        {
            // Data Setup
            this.AddRandomUsers(2);
            var users = DbContext.Users.Take(2).ToList();
            Assert.Equal(2, users.Count());

            this.AddRandomGames(1);
            var game = DbContext.Games.First();
            Assert.NotNull(game);
            
            var gameOwnership = DbContext.UserGames.Add(new UserGame{ 
                GameId = game.Id,
                UserId = users[0].Id
            });
            
            await _sut.BorrowGame(game.Id, gameOwnership.Entity.Id, users[1].Id, DateTime.Now);

            var borrow = DbContext.GameBorrowings.Add(new GameBorrowing{
                GameBorrowerId = users[0].Id,
                GameOwnershipId = gameOwnership.Entity.Id
            });
            DbContext.SaveChanges();
            
            // Test
            var result = await _sut.MarkAsReturned(borrow.Entity.Id);
            Assert.Equal(1, result);
        }
    }
}
