using HerStory.Core.Entities.OrderAggregate;
using HerStory.Core.Specifications;

namespace HerStory.API.Specifications
{
    public class OrderSpec : BaseSpecification<Order>
    {
        public OrderSpec(GenericParams genericParams) : base(c =>
            (string.IsNullOrEmpty(genericParams.Search) || c.BuyerEmail.ToLower().Contains(genericParams.Search))
        )
        {
            AddInclude(x => x.OrderItems);
        }
    }
}