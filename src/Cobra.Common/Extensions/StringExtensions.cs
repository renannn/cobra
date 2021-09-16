using Cobra.Common.Collections.Extensions;
using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Cobra.Common.Extensions;

//
// Summary:
//     Extension methods for String class.
public static class StringExtensions
{
    //
    // Summary:
    //     Adds a char to end of given string if it does not ends with the char.
    public static string EnsureEndsWith(this string str, char c)
    {
        return str.EnsureEndsWith(c, StringComparison.Ordinal);
    }

    //
    // Summary:
    //     Adds a char to end of given string if it does not ends with the char.
    public static string EnsureEndsWith(this string str, char c, StringComparison comparisonType)
    {
        if (str == null)
        {
            throw new ArgumentNullException("str");
        }

        if (str.EndsWith(c.ToString(), comparisonType))
        {
            return str;
        }

        return str + c;
    }

    //
    // Summary:
    //     Adds a char to end of given string if it does not ends with the char.
    public static string EnsureEndsWith(this string str, char c, bool ignoreCase, CultureInfo culture)
    {
        if (str == null)
        {
            throw new ArgumentNullException("str");
        }

        if (str.EndsWith(c.ToString(culture), ignoreCase, culture))
        {
            return str;
        }

        return str + c;
    }

    //
    // Summary:
    //     Adds a char to beginning of given string if it does not starts with the char.
    public static string EnsureStartsWith(this string str, char c)
    {
        return str.EnsureStartsWith(c, StringComparison.Ordinal);
    }

    //
    // Summary:
    //     Adds a char to beginning of given string if it does not starts with the char.
    public static string EnsureStartsWith(this string str, char c, StringComparison comparisonType)
    {
        if (str == null)
        {
            throw new ArgumentNullException("str");
        }

        if (str.StartsWith(c.ToString(), comparisonType))
        {
            return str;
        }

        return c + str;
    }

    //
    // Summary:
    //     Adds a char to beginning of given string if it does not starts with the char.
    public static string EnsureStartsWith(this string str, char c, bool ignoreCase, CultureInfo culture)
    {
        if (str == null)
        {
            throw new ArgumentNullException("str");
        }

        if (str.StartsWith(c.ToString(culture), ignoreCase, culture))
        {
            return str;
        }

        return c + str;
    }

    //
    // Summary:
    //     Indicates whether this string is null or an System.String.Empty string.
    public static bool IsNullOrEmpty(this string str)
    {
        return string.IsNullOrEmpty(str);
    }

    //
    // Summary:
    //     indicates whether this string is null, empty, or consists only of white-space
    //     characters.
    public static bool IsNullOrWhiteSpace(this string str)
    {
        return string.IsNullOrWhiteSpace(str);
    }

    //
    // Summary:
    //     Gets a substring of a string from beginning of the string.
    //
    // Exceptions:
    //   T:System.ArgumentNullException:
    //     Thrown if str is null
    //
    //   T:System.ArgumentException:
    //     Thrown if len is bigger that string's length
    public static string Left(this string str, int len)
    {
        if (str == null)
        {
            throw new ArgumentNullException("str");
        }

        if (str.Length < len)
        {
            throw new ArgumentException("len argument can not be bigger than given string's length!");
        }

        return str.Substring(0, len);
    }

    //
    // Summary:
    //     Converts line endings in the string to System.Environment.NewLine.
    public static string NormalizeLineEndings(this string str)
    {
        return str.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", Environment.NewLine);
    }

    //
    // Summary:
    //     Gets index of nth occurence of a char in a string.
    //
    // Parameters:
    //   str:
    //     source string to be searched
    //
    //   c:
    //     Char to search in str
    //
    //   n:
    //     Count of the occurence
    public static int NthIndexOf(this string str, char c, int n)
    {
        if (str == null)
        {
            throw new ArgumentNullException("str");
        }

        int num = 0;
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == c && ++num == n)
            {
                return i;
            }
        }

        return -1;
    }

    //
    // Summary:
    //     Removes first occurrence of the given postfixes from end of the given string.
    //     Ordering is important. If one of the postFixes is matched, others will not be
    //     tested.
    //
    // Parameters:
    //   str:
    //     The string.
    //
    //   postFixes:
    //     one or more postfix.
    //
    // Returns:
    //     Modified string or the same string if it has not any of given postfixes
    public static string? RemovePostFix(this string str, params string[] postFixes)
    {
        if (str == null) return null;

        if (string.IsNullOrEmpty(str))
        {
            return string.Empty;
        }

        if (postFixes.IsNullOrEmpty())
        {
            return str;
        }

        foreach (string text in postFixes)
        {
            if (str.EndsWith(text))
            {
                return str.Left(str.Length - text.Length);
            }
        }

        return str;
    }

    //
    // Summary:
    //     Removes first occurrence of the given prefixes from beginning of the given string.
    //     Ordering is important. If one of the preFixes is matched, others will not be
    //     tested.
    //
    // Parameters:
    //   str:
    //     The string.
    //
    //   preFixes:
    //     one or more prefix.
    //
    // Returns:
    //     Modified string or the same string if it has not any of given prefixes
    public static string? RemovePreFix(this string str, params string[] preFixes)
    {
        if (str == null) return null;

        if (string.IsNullOrEmpty(str))
        {
            return string.Empty;
        }

        if (preFixes.IsNullOrEmpty())
        {
            return str;
        }

        foreach (string text in preFixes)
        {
            if (str.StartsWith(text))
            {
                return str.Right(str.Length - text.Length);
            }
        }

        return str;
    }

    //
    // Summary:
    //     Gets a substring of a string from end of the string.
    //
    // Exceptions:
    //   T:System.ArgumentNullException:
    //     Thrown if str is null
    //
    //   T:System.ArgumentException:
    //     Thrown if len is bigger that string's length
    public static string Right(this string str, int len)
    {
        if (str == null)
        {
            throw new ArgumentNullException("str");
        }

        if (str.Length < len)
        {
            throw new ArgumentException("len argument can not be bigger than given string's length!");
        }

        return str.Substring(str.Length - len, len);
    }

    //
    // Summary:
    //     Uses string.Split method to split given string by given separator.
    public static string[] Split(this string str, string separator)
    {
        return str.Split(new string[1]
        {
                separator
        }, StringSplitOptions.None);
    }

    //
    // Summary:
    //     Uses string.Split method to split given string by given separator.
    public static string[] Split(this string str, string separator, StringSplitOptions options)
    {
        return str.Split(new string[1]
        {
                separator
        }, options);
    }

    //
    // Summary:
    //     Uses string.Split method to split given string by System.Environment.NewLine.
    public static string[] SplitToLines(this string str)
    {
        return Split(str, Environment.NewLine);
    }

    //
    // Summary:
    //     Uses string.Split method to split given string by System.Environment.NewLine.
    public static string[] SplitToLines(this string str, StringSplitOptions options)
    {
        return Split(str, Environment.NewLine, options);
    }

    //
    // Summary:
    //     Converts PascalCase string to camelCase string.
    //
    // Parameters:
    //   str:
    //     String to convert
    //
    //   invariantCulture:
    //     Invariant culture
    //
    // Returns:
    //     camelCase of the string
    public static string ToCamelCase(this string str, bool invariantCulture = true)
    {
        if (string.IsNullOrWhiteSpace(str))
        {
            return str;
        }

        if (str.Length == 1)
        {
            if (!invariantCulture)
            {
                return str.ToLower();
            }

            return str.ToLowerInvariant();
        }

        return (invariantCulture ? char.ToLowerInvariant(str[0]) : char.ToLower(str[0])) + str.Substring(1);
    }

    //
    // Summary:
    //     Converts PascalCase string to camelCase string in specified culture.
    //
    // Parameters:
    //   str:
    //     String to convert
    //
    //   culture:
    //     An object that supplies culture-specific casing rules
    //
    // Returns:
    //     camelCase of the string
    public static string ToCamelCase(this string str, CultureInfo culture)
    {
        if (string.IsNullOrWhiteSpace(str))
        {
            return str;
        }

        if (str.Length == 1)
        {
            return str.ToLower(culture);
        }

        return char.ToLower(str[0], culture) + str.Substring(1);
    }

    //
    // Summary:
    //     Converts given PascalCase/camelCase string to sentence (by splitting words by
    //     space). Example: "ThisIsSampleSentence" is converted to "This is a sample sentence".
    //
    // Parameters:
    //   str:
    //     String to convert.
    //
    //   invariantCulture:
    //     Invariant culture
    public static string ToSentenceCase(this string str, bool invariantCulture = false)
    {
        if (string.IsNullOrWhiteSpace(str))
        {
            return str;
        }

        return Regex.Replace(str, "[a-z][A-Z]", (Match m) => m.Value[0] + " " + (invariantCulture ? char.ToLowerInvariant(m.Value[1]) : char.ToLower(m.Value[1])));
    }

    //
    // Summary:
    //     Converts given PascalCase/camelCase string to sentence (by splitting words by
    //     space). Example: "ThisIsSampleSentence" is converted to "This is a sample sentence".
    //
    // Parameters:
    //   str:
    //     String to convert.
    //
    //   culture:
    //     An object that supplies culture-specific casing rules.
    public static string ToSentenceCase(this string str, CultureInfo culture)
    {
        if (string.IsNullOrWhiteSpace(str))
        {
            return str;
        }

        return Regex.Replace(str, "[a-z][A-Z]", (Match m) => m.Value[0] + " " + char.ToLower(m.Value[1], culture));
    }

    //
    // Summary:
    //     Converts string to enum value.
    //
    // Parameters:
    //   value:
    //     String value to convert
    //
    // Type parameters:
    //   T:
    //     Type of enum
    //
    // Returns:
    //     Returns enum object
    public static T ToEnum<T>(this string value) where T : struct
    {
        if (value == null)
        {
            throw new ArgumentNullException("value");
        }

        return (T)Enum.Parse(typeof(T), value);
    }

    //
    // Summary:
    //     Converts string to enum value.
    //
    // Parameters:
    //   value:
    //     String value to convert
    //
    //   ignoreCase:
    //     Ignore case
    //
    // Type parameters:
    //   T:
    //     Type of enum
    //
    // Returns:
    //     Returns enum object
    public static T ToEnum<T>(this string value, bool ignoreCase) where T : struct
    {
        if (value == null)
        {
            throw new ArgumentNullException("value");
        }

        return (T)Enum.Parse(typeof(T), value, ignoreCase);
    }

    public static string ToMd5(this string str)
    {
        using (MD5 mD = MD5.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            byte[] array = mD.ComputeHash(bytes);
            StringBuilder stringBuilder = new StringBuilder();
            byte[] array2 = array;
            foreach (byte b in array2)
            {
                stringBuilder.Append(b.ToString("X2"));
            }

            return stringBuilder.ToString();
        }
    }

    //
    // Summary:
    //     Converts camelCase string to PascalCase string.
    //
    // Parameters:
    //   str:
    //     String to convert
    //
    //   invariantCulture:
    //     Invariant culture
    //
    // Returns:
    //     PascalCase of the string
    public static string ToPascalCase(this string str, bool invariantCulture = true)
    {
        if (string.IsNullOrWhiteSpace(str))
        {
            return str;
        }

        if (str.Length == 1)
        {
            if (!invariantCulture)
            {
                return str.ToUpper();
            }

            return str.ToUpperInvariant();
        }

        return (invariantCulture ? char.ToUpperInvariant(str[0]) : char.ToUpper(str[0])) + str.Substring(1);
    }

    //
    // Summary:
    //     Converts camelCase string to PascalCase string in specified culture.
    //
    // Parameters:
    //   str:
    //     String to convert
    //
    //   culture:
    //     An object that supplies culture-specific casing rules
    //
    // Returns:
    //     PascalCase of the string
    public static string ToPascalCase(this string str, CultureInfo culture)
    {
        if (string.IsNullOrWhiteSpace(str))
        {
            return str;
        }

        if (str.Length == 1)
        {
            return str.ToUpper(culture);
        }

        return char.ToUpper(str[0], culture) + str.Substring(1);
    }

    //
    // Summary:
    //     Gets a substring of a string from beginning of the string if it exceeds maximum
    //     length.
    //
    // Exceptions:
    //   T:System.ArgumentNullException:
    //     Thrown if str is null
    public static string? Truncate(this string str, int maxLength)
    {
        if (str == null)
            return null;

        if (str.Length <= maxLength)
        {
            return str;
        }

        return str.Left(maxLength);
    }

    //
    // Summary:
    //     Gets a substring of a string from beginning of the string if it exceeds maximum
    //     length. It adds a "..." postfix to end of the string if it's truncated. Returning
    //     string can not be longer than maxLength.
    //
    // Exceptions:
    //   T:System.ArgumentNullException:
    //     Thrown if str is null
    public static string? TruncateWithPostfix(this string str, int maxLength)
    {
        return str.TruncateWithPostfix(maxLength, "...");
    }

    //
    // Summary:
    //     Gets a substring of a string from beginning of the string if it exceeds maximum
    //     length. It adds given postfix to end of the string if it's truncated. Returning
    //     string can not be longer than maxLength.
    //
    // Exceptions:
    //   T:System.ArgumentNullException:
    //     Thrown if str is null
    public static string? TruncateWithPostfix(this string str, int maxLength, string postfix)
    {
        if (str == null)
            return null;

        if (string.IsNullOrEmpty(str) || maxLength == 0)
        {
            return string.Empty;
        }

        if (str.Length <= maxLength)
        {
            return str;
        }

        if (maxLength <= postfix.Length)
        {
            return postfix.Left(maxLength);
        }

        return str.Left(maxLength - postfix.Length) + postfix;
    }

    /// <summary>
    /// Returns a new string in which all occurrences of a specified string in the current instance are replaced with another specified string, using the provided comparison type.
    /// </summary>
    public static bool Contains(this string commandText, string value, StringComparison comparisonType) =>
        !string.IsNullOrWhiteSpace(commandText) && commandText.IndexOf(value, comparisonType) >= 0;

    /// <summary>
    /// Returns a new string in which all occurrences of a specified string in the current instance are replaced with another specified string, using the provided comparison type.
    /// </summary>
    public static bool Contains(this string commandText, char value, StringComparison comparisonType) =>
        !string.IsNullOrWhiteSpace(commandText) && commandText.IndexOf(value.ToString(), comparisonType) >= 0;

    /// <summary>
    /// Returns a new string in which all occurrences of a specified string in the current instance are replaced with another specified string, using the provided comparison type.
    /// </summary>
    public static string Replace(this string str, string oldValue, string @newValue, StringComparison comparisonType)
    {
        @newValue = @newValue ?? string.Empty;
        if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(oldValue) || oldValue.Equals(@newValue, comparisonType))
        {
            return str;
        }
        int foundAt;
        while ((foundAt = str.IndexOf(oldValue, 0, comparisonType)) != -1)
        {
            str = str.Remove(foundAt, oldValue.Length).Insert(foundAt, @newValue);
        }
        return str;
    }

    /// <summary>
    /// Returns the hash code for this string using the specified rules.
    /// </summary>
    public static int GetHashCode(this string str, StringComparison comparisonType)
    {
        return comparisonType switch
        {
            StringComparison.CurrentCulture => StringComparer.CurrentCulture.GetHashCode(str),
            StringComparison.CurrentCultureIgnoreCase => StringComparer.CurrentCultureIgnoreCase.GetHashCode(str),
            StringComparison.Ordinal => StringComparer.Ordinal.GetHashCode(str),
            StringComparison.OrdinalIgnoreCase => StringComparer.OrdinalIgnoreCase.GetHashCode(str),
            _ => throw new NotSupportedException(),
        };
    }
}
