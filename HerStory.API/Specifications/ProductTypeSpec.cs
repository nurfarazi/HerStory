using HerStory.Core.Entities;
using HerStory.Core.Specifications;

namespace HerStory.API.Specifications
{
    public class ProductTypeSpec : BaseSpecification<ProductType>
    {
        public ProductTypeSpec(GenericParams genericParams)
        {
            AddOrderByDescending(x => x.Name);
        }
    }
}