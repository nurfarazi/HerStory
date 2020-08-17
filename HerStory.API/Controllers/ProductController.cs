using System.Threading.Tasks;
using HerStory.API.Errors;
using HerStory.API.Helpers;
using HerStory.API.Specifications;
using HerStory.Core.Entities;
using HerStory.Core.Interfaces;
using HerStory.Core.Specifications;
using HerStory.Infra.Services;
using Microsoft.AspNetCore.Mvc;

namespace HerStory.API.Controllers
{
    public class ProductController : BaseController<Product>
    {
        private readonly ProductService service;

        public ProductController(ProductService service) : base(service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<Pagination<Product>> IndexAsync([FromQuery] ProductSpecParams genericParams)
        {
            var spec = new ProductSpec(genericParams);

            var countSpec = new ProductCountSpec(genericParams);

            var data = await this.service.ListAsync(spec);

            var totalItems = await this.service.CountAsync(countSpec);

            return new Pagination<Product>(genericParams.PageIndex, genericParams.PageSize, totalItems, data);
        }
    }
}