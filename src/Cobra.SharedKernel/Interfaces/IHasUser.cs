using System;

namespace Cobra.SharedKernel.Interfaces
{
    public interface IHasUser<TUser> where TUser : class
    {
        TUser User { get; set; }
        Guid UserId { get; set; }
    }
}
