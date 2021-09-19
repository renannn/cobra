using Cobra.Common.Extensions;
using Hangfire.Dashboard;

namespace Cobra.Infrastructure.Hangfire
{
    public class AuthorizationFilter : IDashboardAuthorizationFilter
    {
        private readonly string _requiredPermissionName;

        public AuthorizationFilter(string requiredPermissionName = null)
        {
            _requiredPermissionName = requiredPermissionName;
        }

        public bool Authorize(DashboardContext context)
        {
            //if (!IsLoggedIn(context))
            //{
            //    return false;
            //}

            //if (!_requiredPermissionName.IsNullOrEmpty() && !IsPermissionGranted(context, _requiredPermissionName))
            //{
            //    return false;
            //}

            return true;
        }

        private static bool IsLoggedIn(DashboardContext context)
        {
            return context.GetHttpContext().User.Identity.IsAuthenticated;
        }

        private static bool IsPermissionGranted(DashboardContext context, string requiredPermissionName)
        {
            return context.GetHttpContext().User.IsInRole(requiredPermissionName);
        }
    }
}