using DataLayer.Models;
using System.Text.Json;

namespace DataLayer.DataProviders
{
    public class FileDataProvider : IDataProvider
    {
        private readonly string FilePath = "./Mock.json";

        public string AddNew(ProductModel product)
        {
            var products = GetAll();
            products.Add(product);

            var jsonString = JsonSerializer.Serialize(products);
            using (var writer = new StreamWriter(FilePath))
            {
                writer.Write(jsonString);
            }

            return "Success";
        }

        public List<ProductModel> GetAll()
        {
            var data = "";
            using (var reader = new StreamReader(FilePath))
            {
                data = reader.ReadToEnd();
            }

            var products = JsonSerializer.Deserialize<List<ProductModel>>(data);
            return products;
        }

        public void InitFile()
        {
            var products = new List<ProductModel>
            {
                new () { Name = "FileSamsung", Price = 500 },
                new () { Name = "FileApple", Price = 1000 }
            };

            var jsonString = JsonSerializer.Serialize(products);
            using (var writer = new StreamWriter(FilePath))
            {
                writer.Write(jsonString);
            }
        }
    }
}
