namespace MyFirstApi.Shared
{
    public class BaseProduct : BaseEntity
    {
        public string? Brand { get; set; }
        public string? Name { get; set; }
        public string? Color { get; set; }
        public decimal? Cost { get; set; }
        public decimal? Price { get; set; }
        public BaseProduct(string? brand, string? name, string? color, decimal? cost, decimal? price)
        {
            Brand = brand;
            Name = name;
            Color = color;
            Cost = cost;
            Price = price;
        }
        public void Update(string? brand, string? name, string? color, decimal? cost, decimal? price)
        {
            Brand = brand;
            Name = name;
            Color = color;
            Cost = cost;
            Price = price;
        }
        public override string ToString()
        {
            return $"Brand: {Brand}, Name: {Name}, Color: {Color}, IMEI: {Id}";
        }
    }
}
