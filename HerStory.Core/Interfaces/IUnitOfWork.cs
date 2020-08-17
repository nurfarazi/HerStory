using System;
using System.Threading.Tasks;
using HerStory.Core.Entities;

namespace HerStory.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        Task<int> Complete();
    }
}