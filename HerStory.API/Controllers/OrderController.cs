using System.Threading.Tasks;
using HerStory.API.Errors;
using HerStory.API.Helpers;
using HerStory.API.Models;
using HerStory.API.Specifications;
using HerStory.Core.Entities;
using HerStory.Core.Entities.OrderAggregate;
using HerStory.Core.Specifications;
using HerStory.Infra.Services;
using Microsoft.AspNetCore.Mvc;

namespace HerStory.API.Controllers
{
    public class OrderController : BaseController<Order>
    {
        private readonly OrderService service;

        public OrderController(OrderService service) : base(service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<Pagination<Order>> IndexAsync([FromQuery] GenericParams genericParams)
        {
            var spec = new OrderSpec(genericParams);

            var data = await this.service.ListAsync(spec);
            
            var totalItems = data.Count;

            return new Pagination<Order>(genericParams.PageIndex, genericParams.PageSize, totalItems, data);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Order>> CreateOrderAsync(OrderDto orderDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse(400));
            }

            var order = await service.CreateOrderAsync(orderDto.Email, orderDto.DeliveryMethodId, orderDto.BasketId,
                orderDto.ShipToAddress);

            if (order == null) return BadRequest(new ApiResponse(400, "Failed to create order"));

            return Ok(order);
        }
    }
}