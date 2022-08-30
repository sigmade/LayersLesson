using AutocompleteTypes;

namespace DataLayer.Models
{
    [StubGen]
    public class ProductModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        [InnerStubGen]
        public ShopModel Shop { get; set; }
    }

    public class ShopModel
    {
        public string Name { get; set; }
        public bool HasDelivery { get; set; }
    }
}