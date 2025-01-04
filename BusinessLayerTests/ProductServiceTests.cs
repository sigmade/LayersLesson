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
        private readonly ICurrenceExchange _currenceExchange;
        private readonly ProductService _productService;

        public ProductServiceTests()
        {
            _dataProvider = Substitute.For<IDataProvider>();
            _currenceExchange = Substitute.For<ICurrenceExchange>();
            _productService = new ProductService(_dataProvider, _currenceExchange);
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
            _currenceExchange.GetCoeff().Returns(2);

            // Act
            var result = _productService.GetAll();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal(20, result[0].Price);
            Assert.Equal(40, result[1].Price);
        }
    }
}