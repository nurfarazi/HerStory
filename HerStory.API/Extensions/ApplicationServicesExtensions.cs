using System.Linq;
using HerStory.API.Errors;
using HerStory.Core.Entities;
using HerStory.Core.Interfaces;
using HerStory.Infra.Data;
using HerStory.Infra.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace HerStory.API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<OrderService>();
            services.AddScoped<ProductService>();
            services.AddScoped<ProductTypeService>();
            services.AddScoped<BasketService>();
            services.AddScoped<BasketItemService>();
            services.AddScoped<CouponService>();
            
            services.AddScoped<BasketItemRepository>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(x => x.Value.Errors)
                        .Select(x => x.ErrorMessage).ToArray();

                    var errorResponse = new ApiValidationErrorResponse
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });

            return services;
        }
    }
}