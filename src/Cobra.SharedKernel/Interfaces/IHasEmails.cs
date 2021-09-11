using System.Collections.Generic;

namespace Cobra.SharedKernel.Interfaces
{
    public interface IHasEmails<TEmails> where TEmails : class
    {
        List<TEmails> Emails { get; set; }
    }
}
