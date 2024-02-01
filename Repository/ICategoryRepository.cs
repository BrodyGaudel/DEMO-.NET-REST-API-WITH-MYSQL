using product_service.Entity;

namespace product_service.Repository
{
    public interface ICategoryRepository
    {
        Category FindById(Guid id);
        List<Category> FindAll();
        List<Category> Search(string keyword);
        Category Save(Category category);
        List<Category> SaveAll(List<Category> categories);
        void DeleteById(Guid id);
        void DeleteAll();
        void DeleteAll(List<Category> categories);
    }
}
