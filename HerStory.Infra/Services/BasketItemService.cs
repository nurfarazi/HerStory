using System.Threading.Tasks;
using HerStory.Core.Entities;
using HerStory.Core.Interfaces;
using HerStory.Infra.Data;

namespace HerStory.Infra.Services
{
    public class BasketItemService : Service<BasketItem>
    {
        private readonly BasketItemRepository repository;

        public BasketItemService(BasketItemRepository repository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {
            this.repository = repository;
        }

        public Task<BasketItem> FindAsync(int id, int productId)
        {
            return this.repository.FindAsync(id, productId);
        }
    }
}