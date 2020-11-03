using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jogoteca.Models.Entities;
using Jogoteca.Models.DTOs;

namespace Jogoteca.Service.Interfaces
{
    public interface IGameBorrowingService : IGenericService<GameBorrowing>
    {
        Task<int> BorrowGame(Guid gameId, Guid ownerId, Guid borrowerId, DateTime predictedDevolution);

        Task<int> BorrowGame(Guid gameOwnershipId, Guid borrowerId, DateTime predictedDevolution);
        
        Task<List<GameBorrowingDTO>> GetHistoryBorrowedByOwner(Guid ownerId);

        Task<int> MarkAsReturned(Guid id);
    }
}