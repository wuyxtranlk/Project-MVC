namespace StageFive.Services.Products;

public interface IProductService
{
    // lấy hết toàn bộ sản phẩm
    List<Product> GetProducts();
    //lấy sản phẩm theo id
    Product? GetProductById(int id);
    //sắp xếp sản phẩm theo giá
    List<Product> SortByPrice(bool ascending = true);
    // tìm kiếm theo tên sản phẩm
    List<Product> FilterByName(string name);
    // tìm kiếm sản phẩm
    List<Product> FilterByAnyKeyWord(string keyword);

}
