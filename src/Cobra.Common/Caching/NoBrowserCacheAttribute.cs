using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Cobra.Common;

/// <summary>
/// Sets `no-cache`, `must-revalidate`, `no-store` headers for the current `Response`.
/// </summary>
public sealed class NoBrowserCacheAttribute : ActionFilterAttribute
{
    /// <summary>
    /// surrounds execution of the action
    /// </summary>
    public override void OnResultExecuting(ResultExecutingContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        context.HttpContext.DisableBrowserCache();
        base.OnResultExecuting(context);
    }
}