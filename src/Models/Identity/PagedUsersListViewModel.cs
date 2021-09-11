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

        public List<User> Users { get; set; }

        public List<Role> Roles { get; set; }

        public PaginationSettings Paging { get; set; }
    }
}
