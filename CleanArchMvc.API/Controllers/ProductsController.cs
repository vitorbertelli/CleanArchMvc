using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
    {
        var products = await _productService.GetProducts();
        if (products == null) return NotFound("Products not found");
        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CategoryDTO>> GetById(int id)
    {
        var product = await _productService.GetById(id);
        if (product == null) return NotFound("Product not found");
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ProductDTO productDTO)
    {
        if (productDTO == null) return BadRequest("Invalid Data");
        await _productService.Create(productDTO);
        return new CreatedAtRouteResult("GetById", new { id = productDTO.Id }, productDTO);
    }

    [HttpPut]
    public async Task<ActionResult> Put(int id, [FromBody] ProductDTO productDTO)
    {
        if (id != productDTO.Id) return BadRequest("Invalid Id");
        if (productDTO == null) return BadRequest("Invalid Data");
        await _productService.Update(productDTO);
        return Ok(productDTO);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var product = await _productService.GetById(id);
        if (product == null) return NotFound("Product not found");
        await _productService.Remove(id);
        return Ok(product);
    }
}
