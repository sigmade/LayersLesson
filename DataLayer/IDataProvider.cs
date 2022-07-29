namespace DataLayer
{
    public interface IDataProvider
    {
        string AddNew(ProductModel product);
        List<ProductModel> GetAll();
    }
}