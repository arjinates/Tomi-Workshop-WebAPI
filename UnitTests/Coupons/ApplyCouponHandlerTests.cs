using AutoMapper;
using Moq;
using Tomi.Application.Enums.CouponEnums;
using Tomi.Application.Features.Coupons.Commands;
using Tomi.Application.Services.Handlers.Coupons;
using Tomi.Domain.Entities;
using Tomi.Domain.IRepositories;

namespace Tomi.Coupons
{
    public class ApplyCouponHandlerTests
    {
        [Fact]
        public async Task Handle_ValidRequest_ReturnsCouponModel()
        {
            var couponId = "testCouponId";
            var userId = "testUserId";

            var coupon = new Coupon
            {
                CouponId = couponId,
                DiscountType = DiscountType.Ratio.ToString(),
                Value = 10
            };

            var shoppingCart = new ShoppingCart
            {
                UserId = userId,
                ShoppingCartItemList = new List<ShoppingCartItem>
                {
                    new ShoppingCartItem { ItemId = "1", Count = 2 },
                    new ShoppingCartItem { ItemId = "2", Count = 1 }
                }
            };

            var product1 = new Product { Id = "1", Price = 50 };
            var product2 = new Product { Id = "2", Price = 100 };

            var couponRepositoryMock = new Mock<ICouponRepository>();
            var shoppingCartRepositoryMock = new Mock<IShoppingCartRepository>(); //using Mock lib, configuring dependencies
            var productRepositoryMock = new Mock<IProductRepository>();
            var mapperMock = new Mock<IMapper>();

            couponRepositoryMock.Setup(repo => repo.GetByCouponIdAsync(couponId)).ReturnsAsync(coupon);
            shoppingCartRepositoryMock.Setup(repo => repo.GetByUserIdAsync(userId)).ReturnsAsync(shoppingCart);
            productRepositoryMock.Setup(repo => repo.GetByIdAsync("1")).ReturnsAsync(product1);
            productRepositoryMock.Setup(repo => repo.GetByIdAsync("2")).ReturnsAsync(product2);

            var handler = new ApplyCouponHandler(couponRepositoryMock.Object, shoppingCartRepositoryMock.Object, mapperMock.Object, productRepositoryMock.Object);

            var request = new ApplyCouponCommand { CouponId = couponId, UserId = userId };

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.NotNull(result); //test time
            Assert.Equal(couponId, result.CouponId);
            Assert.Equal(200, result.BasketTotalPrice);
            Assert.Equal(180, result.BasketFinalValue);
        }
    }
}

