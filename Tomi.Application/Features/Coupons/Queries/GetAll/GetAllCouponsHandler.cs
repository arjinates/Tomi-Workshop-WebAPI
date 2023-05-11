using AutoMapper;
using MediatR;
using Tomi.Application.Models;
using Tomi.Domain.IRepositories;

namespace Tomi.Application.Features.Coupons.Queries.GetAll
{
    public class GetAllCouponsHandler : IRequestHandler<GetAllCouponsQuery, IEnumerable<CouponModel>>
    {
        private readonly ICouponRepository _couponRepository;
        private readonly IMapper _mapper;

        public GetAllCouponsHandler(ICouponRepository couponRepository, IMapper mapper)
        {
            _couponRepository = couponRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CouponModel>> Handle(GetAllCouponsQuery request, CancellationToken cancellationToken)
        {
            var coupons = await _couponRepository.GetAllAsync();
            var couponViewModel = _mapper.Map<IEnumerable<CouponModel>>(coupons);
            return couponViewModel;
        }
    }
}