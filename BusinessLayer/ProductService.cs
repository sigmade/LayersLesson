using DataLayer;

namespace BusinessLayer
{
    public class ProductService
    {
        public List<ProductModel> GetAll()
        {
            var dataProvider = new ProductDataProvider();
            var products = dataProvider.GetAll();

            // Бизнес логика приложения
            //.................................

            return products;
        }
    }
}
