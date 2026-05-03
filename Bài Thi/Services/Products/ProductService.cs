namespace Bài_Thi.Services.Products;

public class ProductService : IProductService
{
    public IEnumerable<Products> GetProducts() => [
        new Products {
            Id = 1,
            Name = "Iphone 14 Pro Max",
            Price = 30000000,
            Quantity = 100,
            Status = true,
            Mfg = DateTime.Now,
            Photo = "hinh1.gif"
        },
        new Products {
            Id = 2,
            Name = "Iphone 14 Pro",
            Price = 20000000,
            Quantity = 100,
            Status = false,
            Mfg = DateTime.Now,
            Photo = "hinh2.gif"
        },
        new Products {
            Id = 3,
            Name = "Iphone 14",
            Price = 10000000,
            Quantity = 100,
            Status = false,
            Mfg = DateTime.Now,
            Photo = "hinh3.gif"
        }
    ];
    public Products? GetProductById(int id) => GetProducts().FirstOrDefault(p => p.Id == id);
    public List<Producs> FilterByAnyKeyWord(string keyword) => [.. GetProducts().Where(p => typeof(Products).GetProperties().Where(prop => prop.Name != nameof(Products.Status)).Any(prop => prop.GetValue(p)?.ToString()?.Contains(keyword, StringComparison.OrdinalIgnoreCase) == true)
    )];
}
