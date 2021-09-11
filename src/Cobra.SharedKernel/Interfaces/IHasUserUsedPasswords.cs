using System.Collections.Generic;

namespace Cobra.SharedKernel.Interfaces
{
    public interface IHasUserUsedPasswords<TUsedPassword> where TUsedPassword : class
    {
        List<TUsedPassword> UserUsedPasswords { get; set; }
    }
}
