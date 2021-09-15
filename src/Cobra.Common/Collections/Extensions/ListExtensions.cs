using System;
using System.Collections.Generic;

namespace Cobra.Common.Collections.Extensions;

/// <summary>
/// Extension methods for <see cref="T:System.Collections.Generic.IList`1" />.
/// </summary>
public static class ListExtensions
{
    /// <summary>
    /// Sort a list by a topological sorting, which consider their  dependencies
    /// </summary>
    /// <typeparam name="T">The type of the members of values.</typeparam>
    /// <param name="source">A list of objects to sort</param>
    /// <param name="getDependencies">Function to resolve the dependencies</param>
    /// <returns></returns>
    public static List<T> SortByDependencies<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> getDependencies)
    {
        List<T> ts = new List<T>();
        Dictionary<T, bool> ts1 = new Dictionary<T, bool>();
        foreach (T t in source)
        {
            ListExtensions.SortByDependenciesVisit<T>(t, getDependencies, ts, ts1);
        }
        return ts;
    }

    /// <summary>
    /// </summary>
    /// <typeparam name="T">The type of the members of values.</typeparam>
    /// <param name="item">Item to resolve</param>
    /// <param name="getDependencies">Function to resolve the dependencies</param>
    /// <param name="sorted">List with the sortet items</param>
    /// <param name="visited">Dictionary with the visited items</param>
    private static void SortByDependenciesVisit<T>(T item, Func<T, IEnumerable<T>> getDependencies, List<T> sorted, Dictionary<T, bool> visited)
    {
        bool flag;
        string str;
        if (!visited.TryGetValue(item, out flag))
        {
            visited[item] = true;
            IEnumerable<T> ts = getDependencies(item);
            if (ts != null)
            {
                foreach (T t in ts)
                {
                    ListExtensions.SortByDependenciesVisit<T>(t, getDependencies, sorted, visited);
                }
            }
            visited[item] = false;
            sorted.Add(item);
        }
        else if (flag)
        {
            T t1 = item;
            if (t1 != null)
            {
                str = t1.ToString();
            }
            else
            {
                str = null;
            }
            throw new ArgumentException(String.Concat("Cyclic dependency found! Item: ", str));
        }
    }
}