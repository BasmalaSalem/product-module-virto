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
        return await _productService.GetByIdAsync(id);
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAllProducts()
    {
        return await _productService.GetAllAsync();
    }
    [HttpPost]
    public async Task<ActionResult<Product>> AddProduct(Product product)
    {
        return await _productService.CreateAsync(product);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Product>> UpdateProduct(string id, Product product)
    {
        return await _productService.UpdateAsync(id, product);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        await _productService.DeleteAsync(id);

        return NoContent();
    }
}

