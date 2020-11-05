using System;
using Jogoteca.DbContexts;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Jogoteca.Tests
{
    public abstract class InMemoryTest : IDisposable
    {
        private const string InMemoryConnectionString = "DataSource=:memory:";
        private readonly SqliteConnection _connection;

        protected readonly JogotecaDbContext DbContext;

        protected InMemoryTest()
        {
            _connection = new SqliteConnection(InMemoryConnectionString);
            _connection.Open();
            var options = new DbContextOptionsBuilder<JogotecaDbContext>()
                    .UseSqlite(_connection)
                    .Options;
            DbContext = new JogotecaDbContext(options);
            DbContext.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _connection.Close();
        }

        public void AddRandomUsers(int quantity){
            while(quantity-- > 0){
                DbContext.Users.Add(new Models.Entities.User{
                    Email = $"user-{quantity}@email.com",
                    UserName = $"user-{quantity}@email.com",
                    Name = $"user-{quantity}",
                    PasswordHash = "abcdefgijokl"
                });
            }
            DbContext.SaveChanges();
        }

        public void AddRandomGames(int quantity){
            while(quantity-- > 0){
                DbContext.Games.Add(new Models.Entities.Game{
                    Name = $"game-{quantity}",
                    Year = (short)quantity
                });
            }
            DbContext.SaveChanges();
        }
    }
}