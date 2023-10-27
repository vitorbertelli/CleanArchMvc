using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using MediatR;

namespace CleanArchMvc.Application.Services;

public class ProductService : IProductService
{
	private readonly IMediator _mediator;
	private readonly IMapper _mapper;

	public ProductService(IMediator mediator, IMapper mapper)
	{
		_mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
		_mapper = mapper;
	}

	public async Task<IEnumerable<ProductDTO>> GetProducts()
	{
		var productsQuery = new GetProductsQuery() ?? throw new Exception("Entity could not be loaded.");
		var result = await _mediator.Send(productsQuery);
		return _mapper.Map<IEnumerable<ProductDTO>>(result);
	}

	public async Task<ProductDTO> GetById(int? id)
	{
		var productsQuery = new GetProductByIdQuery(id.Value) ?? throw new Exception("Entity could not be loaded.");
		var result = await _mediator.Send(productsQuery);
		return _mapper.Map<ProductDTO>(result);
	}

	public async Task<ProductDTO> GetProductCategory(int? id)
	{
		var productsQuery = new GetProductByIdQuery(id.Value) ?? throw new Exception("Entity could not be loaded.");
		var result = await _mediator.Send(productsQuery);
		return _mapper.Map<ProductDTO>(result);
	}

	public async Task Create(ProductDTO productDto)
	{
		var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDto);
		await _mediator.Send(productCreateCommand);
	}

	public async Task Update(ProductDTO productDto)
	{
		var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDto);
		await _mediator.Send(productUpdateCommand);
	}

	public async Task Remove(int? id)
	{
		var productRemoveCommand = new ProductRemoveCommand(id.Value) ?? throw new Exception("Entity could not be loaded.");
		await _mediator.Send(productRemoveCommand);
	}
}
