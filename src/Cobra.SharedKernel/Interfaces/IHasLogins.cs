using System.Collections.Generic;

namespace Cobra.SharedKernel.Interfaces
{
    public interface IHasLogins<TUserLogin> where TUserLogin : class
    {
        List<TUserLogin> Logins { get; set; }
    }
}
