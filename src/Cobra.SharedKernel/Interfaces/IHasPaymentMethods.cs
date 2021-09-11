using System.Collections.Generic;

namespace Cobra.SharedKernel.Interfaces
{
    public interface IHasPaymentMethods<TPaymentMethod> where TPaymentMethod : class
    {
        List<TPaymentMethod> PaymentMethods { get; set; }
    }
}
