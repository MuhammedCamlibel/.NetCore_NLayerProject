using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.API.DTOs;
using NLayerProject.Core.Models;
using NLayerProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NLayerProject.API.Controllers
{
    //[Route("api/[controller]/[action]")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        
        public CategoriesController(ICategoryService categoryService,IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
           
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            var categoriesDto =  _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return Ok(categoriesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) 
        {
            var category = await _categoryService.GetByIdAsync(id);
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return Ok(categoryDto);
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto categoryDto) 
        {
            
            var category = _mapper.Map<Category>(categoryDto);
            var newCategory = await _categoryService.AddAsync(category);
            return Created(string.Empty,_mapper.Map<CategoryDto>(newCategory));
        }

        [HttpPut]
        public IActionResult UpdateCategory(CategoryDto categoryDto) 
        {
            var category = _mapper.Map<Category>(categoryDto);
             _categoryService.Update(category);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveCategory(int id) 
        {
            var category =  _categoryService.GetByIdAsync(id).Result;
            _categoryService.Remove(category);
            return NoContent();
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetWithProductsById(int id) 
        {

            var category = await _categoryService.GetWithProductsByIdAsync(id);
            var abc = _mapper.Map<CategoryWithProductsDto>(category);

            return Ok(abc);
        }

        

        

        


    }
}
