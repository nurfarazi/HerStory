using HerStory.Core.Entities;
using HerStory.Core.Specifications;

namespace HerStory.API.Specifications
{
    public class BasketSpec : BaseSpecification<Basket>
    {
        public BasketSpec(GenericParams genericParams)
        {
            AddInclude(x => x.Items);
        }

        public BasketSpec(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Items);
        }
    }
}