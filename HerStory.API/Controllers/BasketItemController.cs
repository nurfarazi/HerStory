using HerStory.Core.Entities;
using HerStory.Infra.Services;

namespace HerStory.API.Controllers
{
    public class BasketItemController : BaseController<BasketItem>
    {
        private readonly BasketItemService service;

        public BasketItemController(BasketItemService service) : base(service)
        {
            this.service = service;
        }
    }
}