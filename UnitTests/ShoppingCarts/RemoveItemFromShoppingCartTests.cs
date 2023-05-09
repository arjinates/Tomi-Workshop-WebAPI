using AutoFixture;
using AutoMapper;
using Moq;
using Tomi.Application.Features.ShoppingCarts.Commands;
using Tomi.Application.Models;
using Tomi.Application.Services.Handlers.ShoppingCarts;
using Tomi.Domain.Entities;
using Tomi.Domain.IRepositories;

namespace UnitTests.ShoppingCarts
{
    public class RemoveItemFromShoppingCartTests
    {
        private readonly Mock<IShoppingCartRepository> _shoppingCartRepositoryMock;
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly IMapper _mapper;
        private readonly IFixture _fixture;
        private readonly RemoveItemFromShoppingCart _removeItemFromShoppingCart;

        public RemoveItemFromShoppingCartTests()
        {
            _fixture = new Fixture();
            _shoppingCartRepositoryMock = new Mock<IShoppingCartRepository>();
            _productRepositoryMock = new Mock<IProductRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductModel>()));
            _removeItemFromShoppingCart = new RemoveItemFromShoppingCart(_shoppingCartRepositoryMock.Object, _productRepositoryMock.Object, _mapper);
        }

        [Fact]
        public async Task Handle_ShoppingCartAndItemExist_ReturnsResponse()
        {
            var removeItemCommand = _fixture.Create<RemoveItemCommand>();
            var shoppingCart = _fixture.Create<ShoppingCart>();
            var product = _fixture.Create<Product>();

            _shoppingCartRepositoryMock.Setup(x => x.GetByUserIdAsync(removeItemCommand.UserId)).ReturnsAsync(shoppingCart);
            _productRepositoryMock.Setup(x => x.GetByIdAsync(removeItemCommand.ProductId)).ReturnsAsync(product);
            _shoppingCartRepositoryMock.Setup(x => x.UpdateAsync(shoppingCart.Id, shoppingCart)).Returns(Task.CompletedTask);

            var result = await _removeItemFromShoppingCart.Handle(removeItemCommand, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(removeItemCommand.UserId, result.UserId);
            Assert.Equal(removeItemCommand.ProductId, result.ProductId);
        }

        [Fact]
        public async Task Handle_ShoppingCartDoesNotExist_ThrowsException()
        {
            var removeItemCommand = _fixture.Create<RemoveItemCommand>();

            _shoppingCartRepositoryMock.Setup(x => x.GetByUserIdAsync(removeItemCommand.UserId)).ReturnsAsync((ShoppingCart)null);

            await Assert.ThrowsAsync<InvalidOperationException>(() => _removeItemFromShoppingCart.Handle(removeItemCommand, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_ShoppingCartItemDoesNotExist_ThrowsException()
        {
            var removeItemCommand = _fixture.Create<RemoveItemCommand>();
            var shoppingCart = _fixture.Create<ShoppingCart>();
            var product = _fixture.Create<Product>();

            shoppingCart.ShoppingCartItemList.Clear(); // Ensure no items in cart.

            _shoppingCartRepositoryMock.Setup(x => x.GetByUserIdAsync(removeItemCommand.UserId)).ReturnsAsync(shoppingCart);
            _productRepositoryMock.Setup(x => x.GetByIdAsync(removeItemCommand.ProductId)).ReturnsAsync(product);

            await Assert.ThrowsAsync<InvalidOperationException>(() => _removeItemFromShoppingCart.Handle(removeItemCommand, CancellationToken.None));
        }
    }
}
