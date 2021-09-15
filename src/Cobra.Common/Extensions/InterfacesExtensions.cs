using System;

namespace Cobra.Common;

public static class InterfacesExtensions
{
    public static bool Implements<I>(this Type source) where I : class
    {
        return typeof(I).IsAssignableFrom(source);
    }
}