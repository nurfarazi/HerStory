using HerStory.Core.Entities;
using HerStory.Core.Specifications;

namespace HerStory.API.Specifications
{
  public class ProductCountSpec : BaseSpecification<Product>
  {
    public ProductCountSpec(GenericParams genericParams) : base(c =>
      (string.IsNullOrEmpty(genericParams.Search) || c.Title.ToLower().Contains(genericParams.Search)))
    {
    }
  }
}