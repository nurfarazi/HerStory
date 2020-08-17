using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerStory.Core.Entities;
using HerStory.Core.Entities.OrderAggregate;
using HerStory.Core.Interfaces;

namespace HerStory.Infra.Services
{
    public class OrderService : Service<Order>
    {
        private readonly IGenericRepository<Order> repository;
        private readonly IUnitOfWork unitOfWork;

        private readonly BasketService basketService;
        private readonly ProductService productService;

        public OrderService(IGenericRepository<Order> repository, IUnitOfWork unitOfWork, BasketService basketService,
            ProductService productService)
            : base(repository, unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.basketService = basketService;
            this.productService = productService;
        }

        public async Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId,
            int basketId, Address shippingAddress)
        {
            var basket = await this.basketService.GetByIdAsync(basketId);

            var items = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                var productItem = await this.productService.GetByIdAsync(item.Id);
                var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Title, productItem.Image);
                var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity);
                items.Add(orderItem);
            }

            var subtotal = items.Sum(item => item.Price * item.Quantity);
            
            var order = new Order(items, buyerEmail, shippingAddress, subtotal);

            this.repository.AddAsync(order);
            var result = await this.unitOfWork.Complete().ConfigureAwait(false);

            return order;
        }
    }
}