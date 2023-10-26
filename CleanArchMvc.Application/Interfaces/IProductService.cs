using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetProducts();
    Task<ProductDTO> GetById(int? id);
    Task<ProductDTO> GetProductCategory(int? id);
    Task Create(ProductDTO productDto);
    Task Update(ProductDTO productDto);
    Task Remove(int? id);
}
