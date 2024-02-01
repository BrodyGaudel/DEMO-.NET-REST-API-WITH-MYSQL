using product_service.Entity;
using product_service.Dto;
using product_service.Repository;
using product_service.Util;

namespace product_service.Service
{
    public class CategoryService(ICategoryRepository icategoryRepository, IMappers imappers) : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository = icategoryRepository;
        private readonly IMappers mappers = imappers;

        public CategoryDTO CreateCategory(CategoryDTO categoryDTO)
        {
            if(categoryDTO == null)
            {
                throw new ArgumentException("CategoryDTO can not be null", nameof(categoryDTO));
            }
            Category category = mappers.FromCategoryDTO(categoryDTO);
            Category categorySaved = categoryRepository.Save(category);
            return mappers.FromCategory(categorySaved);
        }

        public List<CategoryDTO> CreateListOfCategories(List<CategoryDTO> categoriesDTO)
        {
            if(categoriesDTO == null || categoriesDTO.Count == 0)
            {
                return [];
            }
            else
            {
                List<Category> categories = mappers.FromListOfCategoryDTOs(categoriesDTO);
                List<Category> categoriesSaved = categoryRepository.SaveAll(categories);
                return mappers.FromListOfCategories(categoriesSaved);
            }
        }

        public void DeleteAllCategories()
        {
            categoryRepository.DeleteAll();
        }

        public void DeleteCategoryById(Guid id)
        {
            categoryRepository.DeleteById(id);
        }

        public void DeleteListOfCategories(List<CategoryDTO> categoriesDTO)
        {
            List<Category> categories = mappers.FromListOfCategoryDTOs(categoriesDTO);
            categoryRepository.DeleteAll(categories);
        }

        public List<CategoryDTO> GetCategories()
        {
            List<Category> categories = categoryRepository.FindAll();
            return mappers.FromListOfCategories(categories);
        }

        public CategoryDTO GetCategoryById(Guid id)
        {
            Category category = categoryRepository.FindById(id);
            return mappers.FromCategory(category);
        }

        public List<CategoryDTO> SearchCategories(string keyword)
        {
            List<Category> categories = categoryRepository.Search(keyword);
            return mappers.FromListOfCategories(categories);
        }

        public CategoryDTO UpdateCategory(Guid id, CategoryDTO categoryDTO)
        {
            Category categoryToUpdate = categoryRepository.FindById(id);
            if(categoryToUpdate == null)
            {
               throw new InvalidOperationException($"Category with ID {id} not found");
            }
            else
            {
                categoryToUpdate.Name = categoryDTO.Name;
                categoryToUpdate.Description = categoryDTO.Description;
                Category category = categoryRepository.Save(categoryToUpdate);
                return mappers.FromCategory(category);
            }
        }
    }
}
