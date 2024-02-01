using Microsoft.AspNetCore.Mvc;
using product_service.Dto;
using product_service.Service;

namespace product_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService) : ControllerBase
    {
        private readonly IProductService productService = productService ?? throw new ArgumentNullException(nameof(productService));

        [HttpGet("list")]
        public ActionResult<IEnumerable<ProductDTO>> GetAllProducts()
        {
            var products = productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("get/{id}")]
        public ActionResult<ProductDTO> GetProductById(Guid id)
        {
            try
            {
                var product = productService.GetProductById(id);
                return Ok(product);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost("save")]
        public ActionResult<ProductDTO> SaveProduct([FromBody] ProductDTO productDTO)
        {
            try
            {
                var savedProduct = productService.SaveProduct(productDTO);
                return CreatedAtAction(nameof(GetProductById), new { id = savedProduct.Id }, savedProduct);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("update/{id}")]
        public ActionResult<ProductDTO> UpdateProduct(Guid id, [FromBody] ProductDTO productDTO)
        {
            try
            {
                var updatedProduct = productService.UpdateProduct(id, productDTO);
                return Ok(updatedProduct);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("delete/{id}")]
        public ActionResult DeleteProductById(Guid id)
        {
            try
            {
                productService.DeleteProductById(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("delete-all")]
        public ActionResult DeleteAllProducts()
        {
            try
            {
                productService.DeleteAllProducts();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("search")]
        public ActionResult<IEnumerable<ProductDTO>> SearchProducts([FromQuery] string keyword)
        {
            try
            {
                var products = productService.SearchProducts(keyword);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
