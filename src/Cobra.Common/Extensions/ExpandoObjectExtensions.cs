using System.Collections.Generic;
using System.Linq;

namespace Cobra.Common;

public static class ExpandoObjectExtensions
{
    public static string? GetId(this object obj)
    {
        var json = obj.ToJson();
        var dictionary = json.JsonToObject<IDictionary<string, object>>();
        return dictionary.FirstOrDefault(x => x.Key == "Id").Value.ToString();
    }
}