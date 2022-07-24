namespace DataLayer
{
    public class ProductDataProvider
    {
        public List<ProductModel> GetAll()
        {
            // Sql or EF or json or memory
            var products = new List<ProductModel>
            {
                new () { Name = "Samsung", Price = 500 },
                new () { Name = "Apple", Price = 1000 }
            };
            return products;
        }
    }
}
