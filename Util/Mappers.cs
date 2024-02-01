using product_service.Dto;
using product_service.Entity;

namespace product_service.Util
{
    public class Mappers : IMappers
    {
        public Mappers() { }

        public CategoryDTO FromCategory(Category category)
        {
            return new CategoryDTO(category.Id, category.Name, category.Description, category.Type);
        }

        public Category FromCategoryDTO(CategoryDTO categoryDTO)
        {
            return new Category(categoryDTO.Id, categoryDTO.Name, categoryDTO.Description, categoryDTO.Type);
        }

        public List<CategoryDTO> FromListOfCategories(List<Category> categories)
        {
            if (categories == null || categories.Count == 0)
            {
                return [];
            }
            List<CategoryDTO> categoryDTOs = [];
            foreach (Category c in categories)
            {
                categoryDTOs.Add(FromCategory(c));
            }
            return categoryDTOs;
        }

        public List<Category> FromListOfCategoryDTOs(List<CategoryDTO> categoryDTOs)
        {
            if (categoryDTOs == null || categoryDTOs.Count == 0) { return []; }
            List<Category> categories = [];
            foreach (CategoryDTO c in categoryDTOs)
            {
                var tmp = FromCategoryDTO(c);
                categories.Add(tmp);
            }
            return categories;
        }

        public List<Product> FromListOfProductDTOs(List<ProductDTO> productDTOs)
        {
            List<Product> products = [];
            foreach (ProductDTO p in productDTOs)
            {
                products.Add(FromProductDTO(p));
            }
            return products;
        }

        public List<ProductDTO> FromListOfProducts(List<Product> products)
        {
            List<ProductDTO> productDTOs = [];
            foreach(Product p in products)
            {
                productDTOs.Add(FromProduct(p));
            }
            return productDTOs;
        }

        public ProductDTO FromProduct(Product product)
        {
            ProductDTO productDTO = new()
            {
                CategoryId = product.CategoryId,
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                DateOfManufacture = product.DateOfManufacture,
                Quantity = product.Quantity
            };
            return productDTO;
        }

        public Product FromProductDTO(ProductDTO productDTO)
        {
            Product product = new()
            {
                CategoryId = productDTO.CategoryId,
                Id = productDTO.Id,
                Name = productDTO.Name,
                Description = productDTO.Description,
                Price = productDTO.Price,
                DateOfManufacture = productDTO.DateOfManufacture,
                Quantity = productDTO.Quantity
            };
            return product;
        }
    }
}
