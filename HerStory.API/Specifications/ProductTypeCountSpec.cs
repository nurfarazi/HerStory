using HerStory.Core.Entities;
using HerStory.Core.Specifications;

namespace HerStory.API.Specifications
{
    public class ProductTypeCountSpec : BaseSpecification<ProductType>
    {
        public ProductTypeCountSpec(GenericParams genericParams) : base(c =>
            (string.IsNullOrEmpty(genericParams.Search) || c.Name.ToLower().Contains(genericParams.Search)))
        {
        }
    }
}