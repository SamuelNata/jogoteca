using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jogoteca.Models;

namespace Jogoteca.Repository
{
    public partial interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<int> Save(TEntity obj);
        int SaveAll(IEnumerable<TEntity> obj);
        Task<int> SaveAllAsync(IEnumerable<TEntity> obj);
        Task<int> Update(TEntity obj);
        ValueTask<TEntity> GetById(long id);
        Task<List<TEntity>> GetAll();
        Task<int> Remove(TEntity obj);
        int RemoveAll(List<TEntity> obj);
    }
}