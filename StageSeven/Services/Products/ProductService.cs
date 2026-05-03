using StageSeven.Models;

namespace StageSeven.Services.Products;

public class ProductService : IProductService
{
    public IEnumerable<Product> GetProducts() => [
        new Product {
            Id = 1,
            Name = "Iphone 14 Pro Max",
            Price = 30000000,
            Quantity = 100,
            Status = true,
            Mfg = DateTime.Now,
            Photo = "hinh1.gif"
        },
        new Product {
            Id = 2,
            Name = "Iphone 14 Pro",
            Price = 20000000,
            Quantity = 100,
            Status = false,
            Mfg = DateTime.Now,
            Photo = "hinh2.gif"
        },
        new Product {
            Id = 3,
            Name = "Iphone 14",
            Price = 10000000,
            Quantity = 100,
            Status = false,
            Mfg = DateTime.Now,
            Photo = "hinh3.gif"
        }
    ];
    public Product? GetProductById(int id) => GetProducts().FirstOrDefault(p => p.Id == id);
    public List<Product> FilterByAnyKeyWord(string keyword) => [.. GetProducts().Where(p => typeof(Product).GetProperties().Where(prop => prop.Name != nameof(Product.Status)).Any(prop => prop.GetValue(p)?.ToString()?.Contains(keyword, StringComparison.OrdinalIgnoreCase) == true)
    )];
    public void AddProduct(Product p) => GetProducts().ToList().Add(p);
    public void UpdateProduct(Product p)
    {
        var existingProduct = GetProducts().FirstOrDefault(p => p.Id == p.Id);
        if (existingProduct != null)
        {
            existingProduct.Name = p.Name;
            existingProduct.Price = p.Price;
            existingProduct.Quantity = p.Quantity;
            existingProduct.Status = p.Status;
            existingProduct.Mfg = p.Mfg;
            existingProduct.Photo = p.Photo;
        }
    }

    public void DeleteProduct(int id)
    {
        var productToDelete = GetProducts().ToList().FirstOrDefault(p => p.Id == id);
        if (productToDelete != null)
        {
            GetProducts().ToList().Remove(productToDelete);
        }
    }
}
