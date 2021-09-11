using System;

namespace Cobra.SharedKernel.Interfaces
{
    public interface IHasCreationDate
    {
        DateTime? CreatedDateTime { get; set; }
    }
}
