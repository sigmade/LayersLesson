using DataLayer.CurrencyServices;
using DataLayer.DataProviders;
using DataLayer.Models;

namespace BusinessLayer
{
    public class ProductService
    {
        private IDataProvider _dataProvider;
        private ICurrenceExchange _currenceExchange;

        public ProductService(IDataProvider dataProvider, ICurrenceExchange currenceExchange)
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

            // Бизнес логика приложения
            //.................................

            return correctProducts;
        }

        public string AddNew(ProductModel product)
        {
            // Бизнес логика приложения
            //.................................

            var result = _dataProvider.AddNew(product);

            return result;
        }
    }
}
