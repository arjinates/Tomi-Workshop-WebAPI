using AutoMapper;
using Moq;
using Tomi.Application.Features.Products.Queries;
using Tomi.Application.Models;
using Tomi.Application.Services.Handlers.Products;
using Tomi.Domain.Entities;
using Tomi.Domain.IRepositories;

namespace Tomi.Products
{
    public class GetAllProductsHandlerTests
    {
        [Fact]
        public async Task Handle_ValidRequest_ReturnsProductModels()
        {
            var products = new List<Product>
            {
                new Product { Id = "1", Name = "Product 1", Price = 50},
                new Product { Id = "2", Name = "Product 1", Price = 50},
        };
            var productModels = new List<ProductModel>
            {
                new ProductModel { Id = "1", Name = "Product 1", Price = 50 },
                new ProductModel { Id = "2", Name = "Product 2", Price = 100 }
            }; 

            var productRepositoryMock = new Mock<IProductRepository>();
            var mapperMock = new Mock<IMapper>();

            productRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(products);
            mapperMock.Setup(m => m.Map<IEnumerable<ProductModel>>(products)).Returns(productModels);

            var handler = new GetAllProductsHandler(productRepositoryMock.Object, mapperMock.Object);
            var request = new GetAllProductsQuery();

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(productModels, result);
        }
    }
}
