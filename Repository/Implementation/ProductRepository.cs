using Microsoft.EntityFrameworkCore;
using product_service.Entity;

namespace product_service.Repository.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository() {
            _context = new ApplicationDbContext();
        }

        public void DeleteAll()
        {
            _context.Products.RemoveRange(_context.Products);
            _context.SaveChanges();
        }

        public void DeleteAll(List<Product> products)
        {
            _context.Products.RemoveRange(products);
            _context.SaveChanges();
        }

        public void DeleteById(Guid id)
        {
            var user = _context.Products.Find(id);
            if (user != null)
            {
                _context.Products.Remove(user);
                _context.SaveChanges();
            }
        }

        public List<Product> FindAll()
        {
            return [.. _context.Products];
        }

        public Product FindById(Guid id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public Product Save(Product product)
        {
            return CreateOrUpdate(product);
        }

        public List<Product> SaveAll(List<Product> products)
        {
            if (products == null || products.Count == 0)
            {
                return [];
            }

            List<Product> savedProducts = [];

            foreach (Product product in products)
            {
                savedProducts.Add(CreateOrUpdate(product));
            }

            return savedProducts;
        }

        public List<Product> Search(string keyword)
        {
            return
            [
                .. _context.Products.Where(product => EF.Functions.Like(product.Name, $"%{keyword}%") || EF.Functions.Like(product.Description, $"%{keyword}%")),
            ];
        }

        private Product CreateOrUpdate(Product product)
        {
            Product existing = _context.Products.Find(product.Id);
            if (existing == null)
            {
                _context.Products.Add(product);
            }
            else
            {
                _context.Products.Update(product);
            }

            _context.SaveChanges();
            return product;
        }
    }
}
