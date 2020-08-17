using System.Collections.Generic;
using System.Threading.Tasks;
using HerStory.Core.Entities;
using HerStory.Core.Interfaces;
using HerStory.Core.Specifications;

namespace HerStory.Infra.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : BaseEntity
    {
        public Service(IGenericRepository<TEntity> repository, IUnitOfWork unitOfWork)
        {
            Repository = repository;
            UnitOfWork = unitOfWork;
        }

        protected IUnitOfWork UnitOfWork { get; private set; }

        protected IGenericRepository<TEntity> Repository { get; private set; }


        public virtual Task<TEntity> GetByIdAsync(int id)
        {
            return Repository.GetByIdAsync(id);
        }

        public virtual Task<IReadOnlyList<TEntity>> ListAllAsync()
        {
            return Repository.ListAllAsync();
        }

        public virtual Task<TEntity> GetEntityWithSpec(ISpecification<TEntity> specification)
        {
            return Repository.GetEntityWithSpec(specification);
        }

        public virtual Task<IReadOnlyList<TEntity>> ListAsync(ISpecification<TEntity> specification)
        {
            return Repository.ListAsync(specification);
        }

        public virtual Task<int> CountAsync(ISpecification<TEntity> specification)
        {
            return Repository.CountAsync(specification);
        }

        public virtual Task AddAsync(TEntity entity)
        {
            Repository.AddAsync(entity);
            var task = UnitOfWork.Complete();
            return task;
        }

        public virtual Task UpdateAsync(TEntity entity)
        {
            Repository.Update(entity);
            var task = UnitOfWork.Complete();
            return task;
        }

        public virtual async Task<int> DeleteAsync(int id)
        {
            var row = await Repository.GetByIdAsync(id);
            Repository.Delete(row);
            var task = await UnitOfWork.Complete();
            return task;
        }
    }
}