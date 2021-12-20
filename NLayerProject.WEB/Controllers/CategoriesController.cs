using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.WEB.DTOs;
using NLayerProject.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using NLayerProject.Core.Models;
using NLayerProject.WEB.Filters;
using NLayerProject.WEB.ApiService;

namespace NLayerProject.WEB.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly CategoryApiService _categoryApiService;

        public CategoriesController(ICategoryService categoryService,IMapper mapper,CategoryApiService categoryApiService)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _categoryApiService = categoryApiService;
        }

        public async Task<IActionResult> Index()
        {
            // katmanlı mimari kullanılarak yapılan işlem 

            /*var categories = await _categoryService.GetAllAsync();                  
            var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categories); */
            
            // api kullanılarak yapılan işlem 

            var categories = await _categoryApiService.GetAllAsync();
            return View(categories);
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        public async Task<IActionResult> Delete(int id) 
        {
            var category = await _categoryApiService.GetByIdAsync(id);
            _categoryApiService.Delete(category.Id).Wait();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id) 
        {
            var category = _categoryApiService.GetByIdAsync(id).Result;
            return View(category); 
        }

        [HttpPost]

        public IActionResult Update(CategoryDto model) 
        {
            
            _categoryApiService.Update(model).Wait();
            return RedirectToAction("Index");
        }

        public IActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryDto model) 
        {
            /*if (!ModelState.IsValid) 
            {
                return View(model);
            }*/
            //await _categoryService.AddAsync(_mapper.Map<Category>(model));
            await _categoryApiService.AddAsync(model);
            return RedirectToAction("Index");
        }

    }
}
