using System.Threading.Tasks;
using HerStory.API.Helpers;
using HerStory.API.Specifications;
using HerStory.Core.Entities;
using HerStory.Core.Specifications;
using HerStory.Infra.Services;
using Microsoft.AspNetCore.Mvc;

namespace HerStory.API.Controllers
{
    public class ProductTypeController : BaseController<ProductType>
    {
        private readonly ProductTypeService service;

        public ProductTypeController(ProductTypeService service) : base(service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<Pagination<ProductType>> IndexAsync([FromQuery] GenericParams genericParams)
        {
            var spec = new ProductTypeSpec(genericParams);

            var countSpec = new ProductTypeCountSpec(genericParams);

            var totalItems = await this.service.CountAsync(countSpec);

            var data = await this.service.ListAsync(spec);

            return new Pagination<ProductType>(genericParams.PageIndex, genericParams.PageSize, totalItems, data);
        }
    }
}