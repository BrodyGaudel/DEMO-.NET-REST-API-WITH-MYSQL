using product_service.Dto;

namespace product_service.Service
{
    public interface IProductService
    {
        ProductDTO GetProductById(Guid id);
        List<ProductDTO> GetAllProducts();
        List<ProductDTO> SearchProducts(string keyword);
        ProductDTO SaveProduct(ProductDTO productDTO);
        ProductDTO UpdateProduct(Guid id, ProductDTO productDTO);
        void DeleteProductById(Guid id);
        void DeleteAllProducts();
    }
}
