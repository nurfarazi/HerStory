using System.Linq;
using System.Threading.Tasks;
using HerStory.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HerStory.Infra.Data
{
    public class BasketItemRepository : GenericRepository<BasketItem>
    {
        private readonly StoreContext context;

        public BasketItemRepository(StoreContext context) : base(context)
        {
            this.context = context;
        }

        public Task<BasketItem> FindAsync(int id, int productId)
        {
            return this.context.BasketItems.Where(i => i.Id == id && i.ProductId == productId)
                .FirstOrDefaultAsync();
        }
    }
}