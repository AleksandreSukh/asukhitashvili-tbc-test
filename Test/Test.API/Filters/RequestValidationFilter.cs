using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Test.Contracts;

namespace Test.API.Filters
{
    public class RequestValidationFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errorResponse = new ErrorResponse();
                errorResponse.StatusCode = (int) HttpStatusCode.BadRequest;
                errorResponse.Errors = context.ModelState.AsEnumerable()
                    .Where(e => e.Value != null && e.Value.Errors.Count>0)
                    .SelectMany(e => e.Value.Errors.Select(eve => eve.ErrorMessage))
                    .ToList();

                context.Result = new BadRequestObjectResult(errorResponse);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }    
    
    public class RequestValidationFilterAsync : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            await next();
        }
    }
}
