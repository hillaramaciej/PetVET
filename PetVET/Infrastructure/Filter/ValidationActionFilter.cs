using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Net;


namespace System.Web.Http.Filters
{
    public class ModelStateValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                List<string> list = (from modelState in context.ModelState.Values from error in modelState.Errors select error.ErrorMessage).ToList();

                //Also add exceptions.
                //list.AddRange(from modelState in context.ModelState.Values from error in modelState.Errors select error.ErrorMessage.ToString());

                context.Result = new BadRequestObjectResult(list);
                
            }
            base.OnActionExecuting(context);
            
        }
    }
}