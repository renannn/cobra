using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;
using System;
using System.Threading.Tasks;

namespace Cobra.Infrastructure.Filters
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RazorPageFeatureGate : Attribute, IAsyncPageFilter
    {
        private string Feature { get; }
        public RazorPageFeatureGate(string feature) => Feature = feature;

        public virtual async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
        {
            var fm = context.HttpContext.RequestServices.GetRequiredService<IFeatureManagerSnapshot>();
            var isEnabled = await fm.IsEnabledAsync(Feature).ConfigureAwait(false);
            if (isEnabled)
            {
                await next.Invoke().ConfigureAwait(false);
            }
            else
            {
                context.HttpContext.Response.Redirect("/404");
                await context.HttpContext.Response.CompleteAsync().ConfigureAwait(false);
            }
        }

        public virtual Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context) => Task.CompletedTask;
    }
}
