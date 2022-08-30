using DataLayer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text.Json;

namespace DataLayer.DataProviders
{
    public class FileDataProvider : IDataProvider
    {
        private readonly static string FilePath = "./Mock.json";

        public string AddNew(ProductModel product)
        {
            var products = GetAll();
            products.Add(product);

            var jsonString = JsonConvert.SerializeObject(products);
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

            var jobject = JObject.Parse(data);
            var jobjectProduct = jobject.SelectToken(nameof(ProductModel));

            var products = jobjectProduct.ToObject<ProductModel[]>();

            return products.ToList();
        }

        //public void InitFile()
        //{
        //    var products = new List<ProductModel>
        //    {
        //        new () { Name = "FileSamsung", Price = 500 },
        //        new () { Name = "FileApple", Price = 1000 }
        //    };

        //    var jsonString = JsonSerializer.Serialize(products);
        //    using (var writer = new StreamWriter(FilePath))
        //    {
        //        writer.Write(jsonString);
        //    }
        //}
    }
}
