using System;
using System.Collections.Generic;

namespace Cobra.Common.Collections.Extensions;

//
// Summary:
//     Extension methods for Collections.
public static class CollectionExtensions
{
    //
    // Summary:
    //     Checks whatever given collection object is null or has no item.
    public static bool IsNullOrEmpty<T>(this ICollection<T> source)
    {
        if (source != null)
        {
            return source.Count <= 0;
        }

        return true;
    }

    //
    // Summary:
    //     Adds an item to the collection if it's not already in the collection.
    //
    // Parameters:
    //   source:
    //     Collection
    //
    //   item:
    //     Item to check and add
    //
    // Type parameters:
    //   T:
    //     Type of the items in the collection
    //
    // Returns:
    //     Returns True if added, returns False if not.
    public static bool AddIfNotContains<T>(this ICollection<T> source, T item)
    {
        if (source == null)
        {
            throw new ArgumentNullException("source");
        }

        if (source.Contains(item))
        {
            return false;
        }

        source.Add(item);
        return true;
    }

    /// <summary>
    /// Adds the `AddRange` to an `IList`
    /// </summary>
    public static void AddRange<T>(this IList<T> source, IEnumerable<T> newList)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (newList == null)
        {
            throw new ArgumentNullException(nameof(newList));
        }

        if (source is List<T> concreteList)
        {
            concreteList.AddRange(newList);
            return;
        }

        foreach (var element in newList)
        {
            source.Add(element);
        }
    }
}