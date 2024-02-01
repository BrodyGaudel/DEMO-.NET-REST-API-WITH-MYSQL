using product_service.Dto;

namespace product_service.Service
{
    public interface ICategoryService
    {
        CategoryDTO GetCategoryById(Guid id);
        List<CategoryDTO> GetCategories();
        List<CategoryDTO> SearchCategories(string keyword);
        CategoryDTO CreateCategory(CategoryDTO categoryDTO);
        List<CategoryDTO> CreateListOfCategories(List<CategoryDTO> categoriesDTO);
        CategoryDTO UpdateCategory(Guid id, CategoryDTO categoryDTO);
        void DeleteCategoryById(Guid id);
        void DeleteAllCategories();
        void DeleteListOfCategories(List<CategoryDTO> categoriesDTO);
    }
}
