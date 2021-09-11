using System;

namespace Cobra.SharedKernel.Helpers
{
    [AttributeUsageAttribute(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public sealed class IncludeAttribute : Attribute { }
}
