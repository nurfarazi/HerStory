using System;
using System.Threading.Tasks;
using HerStory.Core.Entities;
using HerStory.Core.Interfaces;

namespace HerStory.Infra.Services
{
    public class BasketService : Service<Basket>
    {
        private readonly IGenericRepository<Basket> repository;
        private readonly IUnitOfWork unitOfWork;

        private readonly BasketItemService basketItemServie;
        private readonly ProductService productService;

        public BasketService(IGenericRepository<Basket> repository, IUnitOfWork unitOfWork,
            BasketItemService basketItemService, ProductService productService)
            : base(repository, unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;

            this.basketItemServie = basketItemService;
            this.productService = productService;
        }

        public async Task UpsertBasketItem(int basketId, BasketItem basketItem)
        {
            var basket = await this.repository
                .GetByIdAsync(basketId).ConfigureAwait(false);
            var product = await this.productService
                .GetByIdAsync(basketItem.ProductId).ConfigureAwait(false);
            var item = await this.basketItemServie
                .FindAsync(basketItem.Id, basketItem.ProductId).ConfigureAwait(false);
            if (item == null)
            {
                if (basket != null && product != null)
                {
                    var newItem = new BasketItem
                    {
                        ProductId = basketItem.ProductId,
                        BasketId = basketId,
                        ProductName = product.Title,
                        Price = product.Price,
                        Quantity = basketItem.Quantity
                    };

                    await this.basketItemServie.AddAsync(newItem);
                }
                else
                {
                    throw new Exception("Something went wrong");
                }
            }
            else
            {
                basketItem.Price = item.Price;
                basketItem.ProductName = product.Title;
                basketItem.Quantity = item.Quantity;

                await this.basketItemServie.UpdateAsync(basketItem).ConfigureAwait(false);

                await this.unitOfWork.Complete();
            }
        }
    }
}