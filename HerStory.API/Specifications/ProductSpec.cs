using HerStory.Core.Entities;
using HerStory.Core.Specifications;

namespace HerStory.API.Specifications
{
    public class ProductSpec : BaseSpecification<Product>
    {
        public ProductSpec(ProductSpecParams genericParams) : base(c =>
            (string.IsNullOrEmpty(genericParams.Search) || c.Title.ToLower().Contains(genericParams.Search)) &&
            (!genericParams.ProductTypeId.HasValue || c.ProductTypeId == genericParams.ProductTypeId)
        )
        {
            AddOrderByDescending(x => x.Title);
            AddInclude(x => x.ProductType);
            ApplyPaging(genericParams.PageSize * (genericParams.PageIndex - 1), genericParams.PageSize);

            if (string.IsNullOrEmpty(genericParams.Sort)) return;
            switch (genericParams.Sort)
            {
                case "priceAsc":
                    AddOrderBy(p => p.Price);
                    break;
                case "priceDesc":
                    AddOrderByDescending(p => p.Price);
                    break;
                default:
                    AddOrderBy(n => n.Title);
                    break;
            }
        }

        public ProductSpec(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
        }
    }
}