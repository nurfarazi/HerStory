using HerStory.Core.Entities;
using HerStory.Core.Interfaces;

namespace HerStory.Infra.Services
{
    public class ProductTypeService : Service<ProductType>
    {
        public ProductTypeService(IGenericRepository<ProductType> repository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {
        }
    }
}