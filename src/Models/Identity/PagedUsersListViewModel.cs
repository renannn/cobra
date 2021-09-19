using cloudscribe.Web.Pagination;
using Cobra.Entities.Administration;
using System.Collections.Generic;

namespace Cobra.Models.Identity
{
    public class PagedUsersListViewModel
    {
        public PagedUsersListViewModel()
        {
            Paging = new PaginationSettings();
        }

        public List<User> Users { get; set; } = new();

        public List<Role> Roles { get; set; } = new();

        public PaginationSettings Paging { get; set; }
    }
}
