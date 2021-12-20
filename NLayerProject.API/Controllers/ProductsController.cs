using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.API.DTOs;
using NLayerProject.API.Filters;
using NLayerProject.Core.Models;
using NLayerProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.API.Controllers
{
    //[ValidationFilter] // Controller bazında filter 
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService,IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
           
            var products = await _productService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }
        [ServiceFilter(typeof(ProductNotFoundFilter))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
             var product = await _productService.GetByIdAsync(id);

            return Ok(_mapper.Map<ProductDto>(product));
        }

        // [ValidationFilter] // Method bazında filter
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto) 
        {
            var product = _mapper.Map<Product>(productDto);
            var Savedproduct = await _productService.AddAsync(product);

            return Created(string.Empty, _mapper.Map<ProductDto>(Savedproduct));
        } 
        
        [HttpPut]
        public IActionResult UpdateProduct (ProductDto productDto) 
        {
            if (string.IsNullOrEmpty(productDto.Id.ToString()) || productDto.Id == default)
                throw new Exception("Id alanı boş geçilemez");

            var product = _mapper.Map<Product>(productDto);
            _productService.Update(product);
            return NoContent();
            
        }

        [ServiceFilter(typeof(ProductNotFoundFilter))]
        [HttpDelete("{id}")]    
        public IActionResult RemoveProduct(int id) 
        {
            var product = _productService.GetByIdAsync(id).Result;
            _productService.Remove(product);
            return NoContent();
        }
        [ServiceFilter(typeof(ProductNotFoundFilter))]
        [HttpGet("{id}/category")]
        public async Task<IActionResult> GetWithCategoryById(int id) 
        {
            var product = await _productService.GetWithCategoryByIdAsync(id);
            return Ok(_mapper.Map<ProductWithCategoryDto>(product));
        }

        [HttpGet("Where")]
        public async Task<IActionResult> Where( [FromQuery] string value) 
        {
            
            var products = await _productService.Where(x => x.Name.Contains(value) || x.Price < Convert.ToInt32(value) );

            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }

    }
}
