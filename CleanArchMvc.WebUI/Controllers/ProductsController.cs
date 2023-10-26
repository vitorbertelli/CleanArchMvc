﻿using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers;

public class ProductsController : Controller
{
	private IProductService _productService;

	public ProductsController(IProductService productService)
	{
		_productService = productService;

	}
	public async Task<IActionResult> Index()
	{
		var products = await _productService.GetProducts();
		return View(products);
	}
}
