using HerStory.Core.Entities;
using HerStory.Core.Interfaces;

namespace HerStory.Infra.Services
{
    public class ProductService : Service<Product>
    {
        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {
        }
    }
}