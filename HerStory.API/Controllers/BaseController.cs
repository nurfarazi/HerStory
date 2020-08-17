using System;
using System.Threading.Tasks;
using HerStory.API.Errors;
using HerStory.API.Models;
using HerStory.Core.Entities;
using HerStory.Core.Entities.OrderAggregate;
using HerStory.Infra.Services;
using Microsoft.AspNetCore.Mvc;

namespace HerStory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController<TEntity> : ControllerBase where TEntity : BaseEntity
    {
        private readonly Service<TEntity> service;

        public BaseController(Service<TEntity> service)
        {
            this.service = service;
        }

        [HttpPost]
        public virtual async Task<IActionResult> CreateAsync(TEntity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse(400));
            }

            await this.service.AddAsync(entity);

            return Ok();
        }

        [HttpGet("{id}")]
        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await this.service.GetByIdAsync(id);
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> EditAsync(string id, TEntity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse(400));
            }

            try
            {
                await this.service.UpdateAsync(entity);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new ApiResponse(400, e.Message));
            }
        }
        
        [HttpDelete("{id}")]
        public virtual async Task<int> DeleteAsync(int id)
        {
            return await this.service.DeleteAsync(id);
        }
    }
}