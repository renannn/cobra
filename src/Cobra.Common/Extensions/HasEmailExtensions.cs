using System.ComponentModel.DataAnnotations;

namespace Cobra.Common;

public static class HasEmailExtensions
{
    public static bool IsValidEmail(this string source)
    {
        return new EmailAddressAttribute().IsValid(source);
    }
}
