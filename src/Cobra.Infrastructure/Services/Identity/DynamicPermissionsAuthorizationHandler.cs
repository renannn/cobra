using Cobra.Common;
using Cobra.Entities.Administration;
using Cobra.Infrastructure.Services.Contracts.Identity;
using Cobra.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Cobra.Infrastructure.Services.Identity
{
    /// <summary>
    /// More info: http://www.dotnettips.info/post/2581
    /// </summary>
    public class DynamicPermissionRequirement : IAuthorizationRequirement
    {
    }

    public class DynamicPermissionsAuthorizationHandler : AuthorizationHandler<DynamicPermissionRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;
        private readonly ISecurityTrimmingService _securityTrimmingService;
        public DynamicPermissionsAuthorizationHandler(
            UserManager<User> userManager,
            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        protected override async Task HandleRequirementAsync(
             AuthorizationHandlerContext context,
             DynamicPermissionRequirement requirement)
        {
            var routeData = _httpContextAccessor.HttpContext.GetRouteData();

            var controllerName = routeData?.Values["controller"]?.ToString();

            var areaName = routeData?.Values["area"]?.ToString();
            var area = string.IsNullOrWhiteSpace(areaName) ? string.Empty : areaName;

            var controller = string.IsNullOrWhiteSpace(controllerName) ? string.Empty : controllerName;

            var actionName = routeData?.Values["action"]?.ToString();
            var action = string.IsNullOrWhiteSpace(actionName) ? string.Empty : actionName;

            //This is just a sample: How to access form values from an AuthorizationHandler
            var request = _httpContextAccessor.HttpContext.Request;
            if (request.Method.Equals("post", StringComparison.OrdinalIgnoreCase))
            {
                if (request.IsAjaxRequest() && request.ContentType.Contains("application/json"))
                {
                    var httpRequestInfoService = _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IHttpRequestInfoService>();
                    var model = await httpRequestInfoService.DeserializeRequestJsonBodyAsAsync<RoleViewModel>();
                    if (model != null)
                    {

                    }
                }
                else
                {
                    foreach (var item in request.Form)
                    {
                        var formField = item.Key;
                        var formFieldValue = item.Value;
                    }
                }
            }

            if (_securityTrimmingService.CanCurrentUserAccess(area, controller, action))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
        }
    }
}