using DataLayer;

namespace BusinessLayer
{
    public class ProductService
    {
        //private InMemoryDataProvider _dataProvider = new InMemoryDataProvider();
        private FileDataProvider _dataProvider = new FileDataProvider();

        public List<ProductModel> GetAll()
        {
            var products = _dataProvider.GetAll();

            // Бизнес логика приложения
            //.................................

            return products;
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
