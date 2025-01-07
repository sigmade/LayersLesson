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

    /// <summary>
    /// RedisSessionService использует Redis для хранения 
    /// сессионных данных пользователя. 
    /// см. ADR-0002 Переход на архитектуру без сохранения состояния
    /// </summary>


    /// <summary>
    /// RedisSessionService uses Redis to store 
    /// user session data. 
    /// see ADR-0002 Transition to stateless architecture
    /// </summary>
    public class RedisSessionService : ISessionService
    {


        private readonly IRedisClient _redisClient;
        public RedisSessionService(IRedisClient redisClient)
        {
            _redisClient = redisClient;
        }
        public void SetSession(string key, string value)
        {
            _redisClient.Set(key, value);
        }
        public string GetSession(string key)
        {
            return _redisClient.Get(key);
        }
    }
}
