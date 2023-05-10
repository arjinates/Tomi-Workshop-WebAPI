using AutoFixture;
using Moq;
using Tomi.Application.Features.ShoppingCarts.Commands;
using Tomi.Application.Services.Handlers.ShoppingCarts;
using Tomi.Domain.Entities;
using Tomi.Domain.IRepositories;

namespace UnitTests.ShoppingCarts
{
    public class RemoveAllItemsFromShoppingCartTests
    {
        private readonly Mock<IShoppingCartRepository> _shoppingCartRepositoryMock;
        private readonly IFixture _fixture;
        private readonly RemoveAllItemsFromShoppingCart _removeAllItemsFromShoppingCart;

        public RemoveAllItemsFromShoppingCartTests()
        {
            _fixture = new Fixture();
            _shoppingCartRepositoryMock = new Mock<IShoppingCartRepository>();
            _removeAllItemsFromShoppingCart = new RemoveAllItemsFromShoppingCart(_shoppingCartRepositoryMock.Object);
        }

        [Fact] //Checks if ShoppingCart exists
        public async Task Handle_ShoppingCartExists_ReturnsResponse()
        {
            var removeAllItemsCommand = _fixture.Create<RemoveAllItemsCommand>();
            var shoppingCart = _fixture.Create<ShoppingCart>();

            _shoppingCartRepositoryMock.Setup(x => x.GetByUserIdAsync(removeAllItemsCommand.UserId)).ReturnsAsync(shoppingCart);
            _shoppingCartRepositoryMock.Setup(x => x.DeleteAsync(shoppingCart.Id)).Returns(Task.CompletedTask);

            var result = await _removeAllItemsFromShoppingCart.Handle(removeAllItemsCommand, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(removeAllItemsCommand.UserId, result.Data);
            Assert.Equal("ShoppingCart successfully deleted.", result.Message);
        }

        [Fact] // Checks if shoppingCart does not exists and throws and exception
        public async Task Handle_ShoppingCartDoesNotExist_ThrowsException()
        {
            var removeAllItemsCommand = _fixture.Create<RemoveAllItemsCommand>();

            _shoppingCartRepositoryMock.Setup(x => x.GetByUserIdAsync(removeAllItemsCommand.UserId)).ReturnsAsync((ShoppingCart)null);

            await Assert.ThrowsAsync<InvalidOperationException>(() => _removeAllItemsFromShoppingCart.Handle(removeAllItemsCommand, CancellationToken.None));
        }
    }
}
