namespace StageFive.Services.Products;

public class ProductService : IProductService
{
    public readonly List<Product> list = [
        new Product { Id = 1, Name = "Iphone 14 Pro Max", Price = 30000000, Quantity = 100, Status = true, Mfg = DateTime.Now, Photo = "hinh1.gif" },
        new Product { Id = 2, Name = "Iphone 14 Pro", Price = 25000000, Quantity = 100, Status = true, Mfg = DateTime.Now, Photo = "hinh2.gif" },
        new Product { Id = 3, Name = "Iphone 14", Price = 20000000, Quantity = 100, Status = true, Mfg = DateTime.Now, Photo = "hinh3.gif" },
    ];

    public List<Product> GetProducts() => list;
    public Product? GetProductById(int id) => list.FirstOrDefault(p => p.Id == id);
    public List<Product> SortByPrice(bool ascending = true) => [.. list.OrderBy(p => ascending ? p.Price : -p.Price)];
    //list.OrderBy(p => ascending ? p.Price : -p.Price).ToList(); 
    //ascending ? list.OrderBy(p => p.Price).ToList() : list.OrderByDescending(p => p.Price).ToList();
    public List<Product> FilterByName(string name) => String.IsNullOrWhiteSpace(name) ? list : [.. list.Where(p => p.Name?.Contains(name, StringComparison.OrdinalIgnoreCase) == true)];
    public List<Product> FilterByAnyKeyWord(string keyword) => String.IsNullOrWhiteSpace(keyword) ? list : [.. list.Where(p => typeof(Product).GetProperties().Any(prop => prop.GetValue(p)?.ToString()?.Contains(keyword, StringComparison.OrdinalIgnoreCase) == true)
    )];
}
