using DataLayer.CurrencyServices;
using DataLayer.DataProviders;
using DataLayer.Models;

namespace BusinessLayer
{
    public class ProductService : IProductService
    {
        private readonly IDataProvider _dataProvider;
        private readonly ICurrenceExchange _currenceExchange;

        public ProductService(
            IDataProvider dataProvider,
            ICurrenceExchange currenceExchange)
        {
            _dataProvider = dataProvider;
            _currenceExchange = currenceExchange;
        }

        public List<ProductModel> GetAll()
        {
            var products = _dataProvider.GetAll();
            var coeff = _currenceExchange.GetCoeff();

            var correctProducts = products.Select(p => new ProductModel
            {
                Name = p.Name,
                Price = p.Price * coeff

            }).ToList();

            return correctProducts;
        }
    }
}
