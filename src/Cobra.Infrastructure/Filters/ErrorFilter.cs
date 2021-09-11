using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Cobra.Infrastructure.Filters
{
    public class ErrorFilter : Attribute, IAlwaysRunResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            if (context.Result is StatusCodeResult statusCodeResult && statusCodeResult.StatusCode == 404)
            {
                context.HttpContext.Response.Redirect("/404");
            }
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is StatusCodeResult statusCodeResult && statusCodeResult.StatusCode == 404)
            {
                context.HttpContext.Response.Redirect("/404");
            }
        }
    }
}
