using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jogoteca.Models.Entities;
using Jogoteca.Models.DTOs;

namespace Jogoteca.Repository.Interfaces
{
    public interface IGameBorrowingRepository : IGenericRepository<GameBorrowing>
    {
        Task<List<GameBorrowingDTO>> GetHistoryBorrowedByOwner(Guid ownerId);
    }
}