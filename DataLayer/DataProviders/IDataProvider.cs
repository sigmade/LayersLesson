using DataLayer.Models;

namespace DataLayer.DataProviders
{
    public interface IDataProvider
    {
        string AddNew(ProductModel product);
        List<ProductModel> GetAll();
    }
}