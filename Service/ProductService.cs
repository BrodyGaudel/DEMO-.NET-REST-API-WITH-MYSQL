using product_service.Dto;
using product_service.Entity;
using product_service.Repository;
using product_service.Util;

namespace product_service.Service
{
    public class ProductService(IProductRepository iproductRepository, ICategoryRepository icategoryRepository, IMappers imappers) : IProductService
    {
        private readonly IProductRepository productRepository = iproductRepository;
        private readonly ICategoryRepository categoryRepository = icategoryRepository;
        private readonly IMappers mappers = imappers;

        public void DeleteAllProducts()
        {
            productRepository.DeleteAll();
        }

        public void DeleteProductById(Guid id)
        {
            productRepository.DeleteById(id);
        }

        public List<ProductDTO> GetAllProducts()
        {
            List<Product> products = productRepository.FindAll();
            if(products == null || products.Count == 0)
            {
                return [];
            }
            return mappers.FromListOfProducts(products);
        }

        public ProductDTO GetProductById(Guid id)
        {
            if(id == Guid.Empty)
            {
                throw new ArgumentException("Product ID cannot be empty", nameof(id));
            }
            Product product = productRepository.FindById(id) ?? throw new InvalidOperationException($"Product with ID {id} not found");
            return mappers.FromProduct(product);
        }

        public ProductDTO SaveProduct(ProductDTO productDTO)
        {
            if(productDTO == null)
            {
                throw new ArgumentNullException(nameof(productDTO), "ProductDTO cannot be null");
            }
            Category category = categoryRepository.FindById(productDTO.CategoryId) ?? throw new InvalidOperationException($"Category with ID {productDTO.CategoryId} not found");
            Product product = mappers.FromProductDTO(productDTO);
            product.CategoryId = category.Id;
            Product savedProduct = productRepository.Save(product);
            return mappers.FromProduct(savedProduct);
        }

        public List<ProductDTO> SearchProducts(string keyword)
        {
            List<Product> products = productRepository.Search(keyword);
            if(products != null && products.Count > 0)
            {
                return mappers.FromListOfProducts(products);
            }
            return [];
            
        }

        public ProductDTO UpdateProduct(Guid id, ProductDTO productDTO)
        {
            if (productDTO == null)
            {
                throw new ArgumentNullException(nameof(productDTO), "ProductDTO cannot be null");
            }
            Product product = productRepository.FindById(id) ?? throw new InvalidOperationException($"Product with ID {id} not found");
            UpdateProductProperties(product, productDTO);
            Product productUpdated = productRepository.Save(product);
            return mappers.FromProduct(productUpdated);
        }

        private static void UpdateProductProperties(Product product, ProductDTO productDTO)
        {
            product.DateOfManufacture = productDTO.DateOfManufacture;
            product.Price = productDTO.Price;
            product.Description = productDTO.Description;
            product.Name = productDTO.Name;
            product.Quantity = productDTO.Quantity;
        }
    }
}
