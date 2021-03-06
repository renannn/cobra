using Cobra.Common.Collections.Extensions;
using Cobra.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Cobra.Common
{
    [DebuggerStepThrough]
    public static class Check
    {
        public static T NotNull<T>(T value, string parameterName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }
            return value;
        }

        public static string NotNullOrEmpty(string value, string parameterName)
        {
            if (value.IsNullOrEmpty())
            {
                throw new ArgumentException(String.Concat(parameterName, " can not be null or empty!"), parameterName);
            }
            return value;
        }

        public static ICollection<T> NotNullOrEmpty<T>(ICollection<T> value, string parameterName)
        {
            if (value.IsNullOrEmpty<T>())
            {
                throw new ArgumentException(String.Concat(parameterName, " can not be null or empty!"), parameterName);
            }
            return value;
        }

        public static string NotNullOrWhiteSpace(string value, string parameterName)
        {
            if (value.IsNullOrWhiteSpace())
            {
                throw new ArgumentException(String.Concat(parameterName, " can not be null, empty or white space!"), parameterName);
            }
            return value;
        }
    }
}