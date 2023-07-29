using MyFirstApi.Shared;

namespace MyFirstApi.Entities
{
    public class Phone : BaseProduct
    {
        public Phone(string? brand, string? name, string? color, decimal? cost, decimal? price) : base(brand, name, color, cost, price) { }
    }
}