using HerStory.Core.Entities;
using HerStory.Core.Interfaces;

namespace HerStory.Infra.Services
{
    public class CouponService : Service<Coupon>
    {
        public CouponService(IGenericRepository<Coupon> repository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {
        }
    }
}