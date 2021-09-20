using System.Collections.Generic;

namespace Cobra.Admin.Areas.Admin.Pages.User
{
	public class UserRolesModel
	{
		public Entities.Administration.User User { get; set; } = new();

		public List<Entities.Administration.Role> Roles { get; set; } = new();
	}
}
