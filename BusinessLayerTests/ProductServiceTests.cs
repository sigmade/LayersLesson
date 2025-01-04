using DataLayer.CurrencyServices;
using DataLayer.DataProviders;
using DataLayer.Models;
using NSubstitute;
using Xunit;
using Assert = Xunit.Assert;

namespace BusinessLayer.Tests
{
    public class ProductServiceTests
    {
        private readonly IDataProvider _dataProvider;
        private readonly BestExcangeService _currencyExchange;
        private readonly ProductService _productService;

        public ProductServiceTests()
        {
            _dataProvider = Substitute.For<IDataProvider>();
            _currencyExchange = Substitute.For<BestExcangeService>(null, null);
            _productService = new ProductService(_dataProvider, _currencyExchange);
        }

        [Fact]
        public void GetAllTest()
        {
            // Arrange
            var products = new List<ProductModel>
                {
                    new ProductModel { Name = "Product1", Price = 10 },
                    new ProductModel { Name = "Product2", Price = 20 }
                };
            _dataProvider.GetAll().Returns(products);
            _currencyExchange.GetCoeff().Returns(1.5m);

            // Act
            var result = _productService.GetAll();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("Product1", result[0].Name);
            Assert.Equal(15, result[0].Price);
            Assert.Equal("Product2", result[1].Name);
            Assert.Equal(30, result[1].Price);
        }
    }
}