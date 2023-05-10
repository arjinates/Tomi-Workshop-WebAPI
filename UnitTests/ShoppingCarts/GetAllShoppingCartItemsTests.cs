using AutoFixture;
using AutoMapper;
using Moq;
using Tomi.Application.Features.ShoppingCarts.Queries;
using Tomi.Application.Services.Handlers.ShoppingCarts;
using Tomi.Domain.Entities;
using Tomi.Domain.IRepositories;

namespace UnitTests.ShoppingCarts
{
    public class GetAllShoppingCartItemsTests
    {
        private readonly Mock<IShoppingCartRepository> _shoppingCartRepositoryMock;
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly IFixture _fixture;
        private readonly GetAllShoppingCartItems _getAllShoppingCartItems;

        public GetAllShoppingCartItemsTests()
        {
            _fixture = new Fixture();
            _shoppingCartRepositoryMock = new Mock<IShoppingCartRepository>();
            _productRepositoryMock = new Mock<IProductRepository>();
            _mapperMock = new Mock<IMapper>();
            _getAllShoppingCartItems = new GetAllShoppingCartItems(_shoppingCartRepositoryMock.Object, _productRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact] //Check if ShoppingCart exists
        public async Task Handle_ShoppingCartExists_ReturnsShoppingCart()
        {
            var getAllShoppingCartItemsByUserIdQuery = _fixture.Create<GetAllShoppingCartItemsByUserIdQuery>();
            var shoppingCart = _fixture.Create<ShoppingCart>();
            var product = _fixture.Create<Product>();

            _shoppingCartRepositoryMock.Setup(x => x.GetByUserIdAsync(getAllShoppingCartItemsByUserIdQuery.UserId)).ReturnsAsync(shoppingCart);
            _productRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(product);

            var result = await _getAllShoppingCartItems.Handle(getAllShoppingCartItemsByUserIdQuery, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(shoppingCart.ShoppingCartItemList.Count, result.Items.Count);
        }

        [Fact] //Check if it throws an exception if cart does not exists
        public async Task Handle_ShoppingCartDoesNotExist_ThrowsException()
        {
            var getAllShoppingCartItemsByUserIdQuery = _fixture.Create<GetAllShoppingCartItemsByUserIdQuery>();

            _shoppingCartRepositoryMock.Setup(x => x.GetByUserIdAsync(getAllShoppingCartItemsByUserIdQuery.UserId)).ReturnsAsync((ShoppingCart)null);

            await Assert.ThrowsAsync<InvalidOperationException>(() => _getAllShoppingCartItems.Handle(getAllShoppingCartItemsByUserIdQuery, CancellationToken.None));
        }
    }
}
