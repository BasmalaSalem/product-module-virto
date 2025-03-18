using BaseProductModule.Core.Model;
using BaseProductModule.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseProductModule.Web.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
public class BaseProductController : ControllerBase
{
    private readonly IBaseProductService _productService;
    public BaseProductController(IBaseProductService productService)
    {
        _productService = productService;

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProductById(string id)
    {
        return await _productService.GetProductByIdAsync(id);
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAllProducts()
    {
        return await _productService.GetAllProductsAsync();
    }
    [HttpPost]
    public async Task<ActionResult<Product>> AddProduct(Product product)
    {
        return await _productService.CreateProductAsync(product);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Product>> UpdateProduct(string id, Product product)
    {
        return await _productService.UpdateProductAsync(id, product);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        await _productService.DeleteProductAsync(id);

        return NoContent();
    }
}

