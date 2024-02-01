using product_service.Dto;
using product_service.Entity;

namespace product_service.Util
{
    public interface IMappers
    {
        CategoryDTO FromCategory(Category category);
        List<CategoryDTO> FromListOfCategories(List<Category> categories);
        Category FromCategoryDTO(CategoryDTO categoryDTO);
        List<Category> FromListOfCategoryDTOs(List<CategoryDTO> categoryDTOs);
        ProductDTO FromProduct(Product product);
        Product FromProductDTO(ProductDTO productDTO);
        List<ProductDTO> FromListOfProducts(List<Product> products);
        List<Product> FromListOfProductDTOs(List<ProductDTO> productDTOs);

    }
}
