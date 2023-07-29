using MyFirstApi.Shared;

namespace MyFirstApi.Entities
{
    public class Laptop : BaseProduct
    {

        public Laptop(string? brand, string? name, string? color, decimal? cost, decimal? price) : base(brand, name, color, cost, price) { }
    }
}
