using BaseProductModule.Core.Model;
using BaseProductModule.Core.Services;
using Microsoft.AspNetCore.Mvc;
using PhysicalProductModule.Core.Model;

namespace PhysicalProductModule.Web.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
public class PhysicalProductController : ControllerBase
{
    private readonly IBaseProductService<PhysicalProduct> _productService;

    /// <summary>
    /// Initializes a new instance of the BaseProductController
    /// </summary>
    /// <param name="productService">The product service dependency</param>
    public PhysicalProductController(IBaseProductService<PhysicalProduct> productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// Retrieves a single product by its unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the product to retrieve</param>
    /// <returns>The requested product</returns>
    /// <response code="200">Returns the requested product</response>
    /// <response code="404">If no product exists with the specified identifier</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PhysicalProduct>> GetProductById(string id)
    {
        return await _productService.GetProductByIdAsync(id);
    }

    /// <summary>
    /// Retrieves all available products
    /// </summary>
    /// <returns>A list of all products</returns>
    /// <response code="200">Returns the complete product list</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<PhysicalProduct>>> GetAllProducts()
    {
        return await _productService.GetAllProductsAsync();
    }

    /// <summary>
    /// Creates a new product
    /// </summary>
    /// <param name="product">The product data to create</param>
    /// <returns>The newly created product</returns>
    /// <response code="201">Returns the newly created product</response>
    /// <response code="400">If the product data is invalid</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PhysicalProduct>> AddProduct(PhysicalProduct product)
    {
        var createdProduct = await _productService.CreateProductAsync(product);
        return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, createdProduct);
    }

    /// <summary>
    /// Updates an existing product
    /// </summary>
    /// <param name="id">The unique identifier of the product to update</param>
    /// <param name="product">The updated product data</param>
    /// <returns>The updated product</returns>
    /// <response code="200">Returns the updated product</response>
    /// <response code="400">If the request data is invalid</response>
    /// <response code="404">If no product exists with the specified identifier</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PhysicalProduct>> UpdateProduct(string id, PhysicalProduct product)
    {
        return await _productService.UpdateProductAsync(id, product);
    }

    /// <summary>
    /// Deletes a product by its identifier
    /// </summary>
    /// <param name="id">The numeric identifier of the product to delete</param>
    /// <returns>No content response</returns>
    /// <response code="204">Product was successfully deleted</response>
    /// <response code="404">If no product exists with the specified identifier</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        await _productService.DeleteProductAsync(id);
        return NoContent();
    }
}
