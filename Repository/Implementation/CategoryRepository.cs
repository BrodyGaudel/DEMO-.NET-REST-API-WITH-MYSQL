using product_service.Entity;

namespace product_service.Repository.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository() {
            _context = new ApplicationDbContext();
        }

        public void DeleteAll()
        {
            _context.Categories.RemoveRange(_context.Categories);
            _context.SaveChanges();
        }

        public void DeleteAll(List<Category> categories)
        {
            _context.Categories.RemoveRange(categories);
            _context.SaveChanges();
        }

        public void DeleteById(Guid id)
        {
            var category = _context.Categories.Find(id);

            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }

        public List<Category> FindAll()
        {
            return [.. _context.Categories];
        }

        public Category FindById(Guid id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public Category Save(Category category)
        {
            var existing = _context.Categories.Find(category.Id);

            if (existing == null)
            {
                _context.Categories.Add(category);
            }
            else
            {
                _context.Entry(existing).CurrentValues.SetValues(category);
            }

            _context.SaveChanges();
            return category;
        }

        public List<Category> SaveAll(List<Category> categories)
        {
            if (categories == null || categories.Count == 0)
            {
                return [];
            }

            List<Category> savedCategories = [];

            foreach (Category category in categories)
            {
                savedCategories.Add(Save(category));
            }

            return savedCategories;
        }

        public List<Category> Search(string keyword)
        {
            return
            [
                .. _context.Categories.Where(c => c.Name.Contains(keyword) || c.Description.Contains(keyword)),
            ];
        }
    }
}
