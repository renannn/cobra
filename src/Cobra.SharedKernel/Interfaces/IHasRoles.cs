using System.Collections.Generic;

namespace Cobra.SharedKernel.Interfaces
{
    public interface IHasRoles<TRole> where TRole : class
    {
        List<TRole> Roles { get; set; }
    }
}
