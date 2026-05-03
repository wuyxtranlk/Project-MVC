namespace Bài_Thi.Services.Products;

public interface IProductService
{
    IEnumerable<Products> GetProducts();
    Products? GetProductById(int id);

    List<Product> FilterByAnyKeyWord(string keyword);
}
