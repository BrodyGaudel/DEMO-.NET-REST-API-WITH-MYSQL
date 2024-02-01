using product_service.Entity;

namespace product_service.Repository
{
    public interface IProductRepository
    {
        Product FindById(Guid id);
        List<Product> FindAll();
        List<Product> Search(string keyword);
        Product Save(Product product);
        List<Product> SaveAll(List<Product> products);
        void DeleteById(Guid id);
        void DeleteAll();
        void DeleteAll(List<Product> products);
    }
}
