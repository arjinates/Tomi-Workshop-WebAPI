using AutoFixture;
using AutoMapper;
using Moq;
using Tomi.Application.Features.ShoppingCarts.Commands;
using Tomi.Application.Services.Handlers.ShoppingCarts;
using Tomi.Domain.Entities;
using Tomi.Domain.IRepositories;

namespace UnitTests.ShoppingCarts
{
    public class AddItemToShoppingCartTests
    {
        private readonly Mock<IShoppingCartRepository> _mockShoppingCartRepository;
        private readonly Mock<IProductRepository> _mockProductRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IFixture _fixture;

        public AddItemToShoppingCartTests()
        {
            _mockShoppingCartRepository = new Mock<IShoppingCartRepository>();
            _mockProductRepository = new Mock<IProductRepository>();
            _mockMapper = new Mock<IMapper>();
            _fixture = new Fixture();
        }

        [Fact] //Test if shoppingCart does not exists
        public async Task Handle_ShoppingCartDoesNotExist_CreatesNewShoppingCart()
        {
            var command = _fixture.Create<AddItemCommand>();
            var product = _fixture.Create<Product>();

            _mockShoppingCartRepository
                .Setup(x => x.GetByUserIdAsync(command.UserId))
                .ReturnsAsync((ShoppingCart)null);

            _mockProductRepository
                .Setup(x => x.GetByIdAsync(command.ProductId))
                .ReturnsAsync(product);

            var handler = new AddItemToShoppingCart(_mockShoppingCartRepository.Object, _mockProductRepository.Object, _mockMapper.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            _mockShoppingCartRepository.Verify(x => x.CreateAsync(It.Is<ShoppingCart>(sc => sc.UserId == command.UserId)), Times.Once);
        }

        [Fact] //Test if shoppingCart exists and adds new items?
        public async Task Handle_ShoppingCartExists_AddsItemToShoppingCart()
        {
            var command = _fixture.Create<AddItemCommand>();
            var product = _fixture.Create<Product>();
            var shoppingCart = _fixture.Create<ShoppingCart>();

            _mockShoppingCartRepository
                .Setup(x => x.GetByUserIdAsync(command.UserId))
                .ReturnsAsync(shoppingCart);

            _mockProductRepository
                .Setup(x => x.GetByIdAsync(command.ProductId))
                .ReturnsAsync(product);

            var handler = new AddItemToShoppingCart(_mockShoppingCartRepository.Object, _mockProductRepository.Object, _mockMapper.Object);

            var result = await handler.Handle(command, CancellationToken.None);

            _mockShoppingCartRepository.Verify(x => x.UpdateAsync(shoppingCart.Id, It.IsAny<ShoppingCart>()), Times.Once);
        }
    }
}
