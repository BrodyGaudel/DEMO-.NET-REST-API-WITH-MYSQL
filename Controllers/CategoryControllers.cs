using Microsoft.AspNetCore.Mvc;
using product_service.Dto;
using product_service.Service;

namespace product_service.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("get/{id}")]
        public IActionResult GetCategoryById(Guid id)
        {
            CategoryDTO categoryDTO = _categoryService.GetCategoryById(id);

            if (categoryDTO == null)
            {
                return NotFound();
            }
            return Ok(categoryDTO);
        }

        [HttpGet("get-list")]
        public IActionResult GetCategories()
        {
            List<CategoryDTO> categoriesDTO = _categoryService.GetCategories();
            return Ok(categoriesDTO);
        }

        [HttpGet("search")]
        public IActionResult SearchCategories([FromQuery] string keyword)
        {
            List<CategoryDTO> categoriesDTO = _categoryService.SearchCategories(keyword);
            return Ok(categoriesDTO);
        }

        [HttpPost("create")]
        public IActionResult CreateCategory([FromBody] CategoryDTO dto)
        {
            CategoryDTO createdCategory = _categoryService.CreateCategory(dto);
            return CreatedAtAction(nameof(GetCategoryById), new { id = createdCategory.Id }, createdCategory);
        }

        [HttpPost("create-list")]
        public IActionResult CreateListOfCategories([FromBody] List<CategoryDTO> dtos)
        {
            var createdCategories = _categoryService.CreateListOfCategories(dtos);
            return Ok(createdCategories);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateCategory(Guid id, [FromBody] CategoryDTO dto)
        {
            CategoryDTO updatedCategory = _categoryService.UpdateCategory(id, dto);
            if (updatedCategory == null)
            {
                return NotFound();
            }
            return Ok(updatedCategory);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteCategoryById(Guid id)
        {
            _categoryService.DeleteCategoryById(id);
            return NoContent();
        }

        [HttpDelete("delete-all")]
        public IActionResult DeleteAllCategories()
        {
            _categoryService.DeleteAllCategories();
            return NoContent();
        }

        [HttpDelete("delete-list")]
        public IActionResult DeleteListOfCategories([FromBody] List<CategoryDTO> dtos)
        {
            _categoryService.DeleteListOfCategories(dtos);
            return NoContent();
        }
    }

}
