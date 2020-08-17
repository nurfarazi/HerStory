using System.Collections.Generic;
using System.Threading.Tasks;
using HerStory.API.Errors;
using HerStory.API.Specifications;
using HerStory.Core.Entities;
using HerStory.Core.Specifications;
using HerStory.Infra.Services;
using Microsoft.AspNetCore.Mvc;

namespace HerStory.API.Controllers
{
    public class BasketController : BaseController<Basket>
    {
        private readonly BasketService service;

        public BasketController(BasketService service) : base(service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IReadOnlyList<Basket>> IndexAsync([FromQuery] GenericParams genericParams)
        {
            var spec = new BasketSpec(genericParams);

            return await this.service.ListAsync(spec);
        }
        
        [HttpGet("{id}")]
        public override async Task<Basket> GetByIdAsync(int id)
        {
            var spec = new BasketSpec(id);
            
            return await this.service.GetEntityWithSpec(spec);
        }

        [HttpPost]
        [Route("basketItem/{id}")]
        public async Task<IActionResult> CreateBasketItemAsync(int id, BasketItem basketItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse(400));
            }

            await this.service.UpsertBasketItem(id, basketItem);
            return Ok();
        }
    }
}