namespace DataLayer
{
    public class InMemoryDataProvider : IDataProvider
    {
        private static List<ProductModel> Products = new List<ProductModel>
            {
                new () { Name = "Samsung", Price = 500 },
                new () { Name = "Apple", Price = 1000 }
            };

        public List<ProductModel> GetAll()
        {
            return Products;
        }

        public string AddNew(ProductModel product)
        {
            Products.Add(product);
            return "Success";
        }
    }
}
