using System;
using System.Linq;
using System.Reflection;

namespace Cobra.Common.Reflection;

public static class TypeExtensions
{
    public static Assembly GetAssembly(this Type type)
    {
        return type.GetTypeInfo().Assembly;
    }

    public static MethodInfo GetMethod(this Type type, string methodName, int pParametersCount = 0, int pGenericArgumentsCount = 0)
    {
        return (from m in (from m in type.GetMethods()
                           where m.Name == methodName
                           select m).ToList()
                select new
                {
                    Method = m,
                    Params = m.GetParameters(),
                    Args = m.GetGenericArguments()
                } into x
                where x.Params.Length == pParametersCount && x.Args.Length == pGenericArgumentsCount
                select x.Method).First();
    }
}