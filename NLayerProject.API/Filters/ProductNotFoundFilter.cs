using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayerProject.API.DTOs;
using NLayerProject.Core.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.API.Filters
{
    public class ProductNotFoundFilter : ActionFilterAttribute
    {

        private readonly IProductService _productService;
        public ProductNotFoundFilter(IProductService productService)
        {
            _productService = productService; 
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var id = (int)context.ActionArguments.Values.FirstOrDefault();
            var product = await _productService.GetByIdAsync(id);

            if (product is not  null)
                await next.Invoke();
            else 
            {
                ErrorDto error = new ErrorDto();
                error.Status = 404;
                error.Errors.Add($"id'si {id} olan ürün bulunamadı. ");

                context.Result = new NotFoundObjectResult(error);
            }

        }
    }
}
