using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jogoteca.Models;
using Jogoteca.Repository;

namespace Jogoteca.Service
{
        
    public abstract class GenericService<TRespository, TEntity> : IGenericService<TEntity>
        where TEntity : BaseEntity
        where TRespository : IGenericRepository<TEntity>
    {
        protected internal TRespository Repository { get; set; }

        protected GenericService(TRespository respository)
        {
            Repository = respository;
        }

        public virtual Task<int> Save(TEntity obj)
        {
            return Repository.Save(obj);
        }

        public int SaveAll(IEnumerable<TEntity> obj)
        {
            return Repository.SaveAll(obj);
        }

        public virtual Task<int> Update(TEntity obj)
        {
            return Repository.Update(obj);
        }

        public virtual ValueTask<TEntity> GetById(long id)
        {
            return Repository.GetById(id);
        }

        public Task<List<TEntity>> GetAll()
        {
            return Repository.GetAll();
        }

        public virtual Task<int> Remove(TEntity obj)
        {
            return Repository.Remove(obj);
        }

        public async Task<TEntity> FindByIdOrFail(long id)
        {
            var model = await GetById(id);

            if (model == null)
            {
                throw new Exception("Registro não encontrado.");
            }

            return model;
        }
    }
}