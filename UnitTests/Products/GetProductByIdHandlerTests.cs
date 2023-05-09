using AutoMapper;
using Moq;
using Tomi.Application.Features.Products.Queries;
using Tomi.Application.Models;
using Tomi.Application.Services.Handlers.Products;
using Tomi.Domain.Entities;
using Tomi.Domain.IRepositories;

namespace Tomi.Products
{
    public class GetProductByIdHandlerTests
    {
        [Fact]
        public async Task Handle_ValidRequest_ReturnsProductModel()
        { 
            var product = new Product { Id = "1", Name = "Product 1", Price = 50 };
            var productModel = new ProductModel { Id = "1", Name = "Product 1", Price = 50 };

            var productRepositoryMock = new Mock<IProductRepository>();
            var mapperMock = new Mock<IMapper>();

            productRepositoryMock.Setup(repo => repo.GetByIdAsync(product.Id)).ReturnsAsync(product);
            mapperMock.Setup(m => m.Map<ProductModel>(product)).Returns(productModel);

            var handler = new GetProductByIdHandler(productRepositoryMock.Object, mapperMock.Object);
            var request = new GetProductByIdQuery { Id = product.Id };

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(productModel, result);
        }
    }
}
