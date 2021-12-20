using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayerProject.WEB.DTOs;
using NLayerProject.Core.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.WEB.Filters
{
    public class NotFoundFilter : ActionFilterAttribute
    {

        private readonly ICategoryService _categoryService;
        public NotFoundFilter(ICategoryService categoryService)
        {
            _categoryService = categoryService; 
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var id = (int)context.ActionArguments.Values.FirstOrDefault();
            var category = await _categoryService.GetByIdAsync(id);

            if (category is not  null)
                await next.Invoke();
            else 
            {
                ErrorDto error = new ErrorDto();
                
                error.Errors.Add($"id'si {id} olan ürün bulunamadı. ");

                context.Result = new RedirectToActionResult("Error", "Home", error);
            }

        }
    }
}
