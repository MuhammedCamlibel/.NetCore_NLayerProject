using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayerProject.API.DTOs;
using System.Linq;

namespace NLayerProject.API.Filters
{
    public class ValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid) 
            {
                var errorDto = new ErrorDto();
                errorDto.Status = 400;

                var modelError =  context.ModelState.Values.SelectMany(x => x.Errors);
                
                modelError.ToList().ForEach(x => errorDto.Errors.Add(x.ErrorMessage));

                context.Result = new BadRequestObjectResult(errorDto);
               
            }
            
        }
    }
}
