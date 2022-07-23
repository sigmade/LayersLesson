using DataLayer;

namespace BusinessLayer
{
    public class ProductService
    {
        public List<ProductModel> GetAll()
        {
            var dataProvider = new ProductDataProvider();

            // Some business logic

            return dataProvider.GetAll();
        }
    }
}
