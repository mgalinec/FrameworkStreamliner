using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace FrameworkStreamliner
{
    /// <summary>Extensions for System.String (string).</summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Checks if input string is UpperCase. Returns false if any char in string is LowerCase, else returns true. Ignores whitspaces, numbers and special characters.
        /// </summary>
        /// <param name="value">Input string type used as a value for UpperCase check.</param>
        /// <example>
        /// The following example shows how input value is chacked by each character and tested for UpperCase.
        /// <code>
        ///var testString = "This is a test string!";
        /// var result = testString.IsAllUpper();
        /// </code>
        /// result is false.
        /// </example>
        public static bool IsAllUpper(this string value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (Char.IsLetter(value[i]) && !Char.IsUpper(value[i]))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Extracts part of the string based on the parameters. Start is inclusive, end is exclusive.
        /// </summary>
        /// <param name="value">Input string type used as a value</param>
        /// <param name="start">String type of an element used as a starting sequance.</param>
        /// <param name="end">String type of an element used as an ending sequance.</param>
        /// <param name="addToStart">Integer type of an element used as number of characters taken from first character after starting sequance onwards. "-" would take backwards. </param>
        /// <param name="addToEnd">Integer type of an element used as number of characters taken from the start of an ending sequance onwards. </param>
        /// <param name="defaultValue">String type of an element. If set, returns the value that is set if substring is not faund, relative to parameters returnDefaultIfStartNotFound and returnDefaultIfEndNotFound . Default value is null.</param>
        /// <param name="returnDefaultIfStartNotFound">Boolean type elemnt, default true. Returns defaultValue if start sequance is not found, else if set to false, takes start of a string as start sequance.</param>
        /// <param name="returnDefaultIfEndNotFound">Boolean type elemnt, default true. Returns defaultValue if end sequance is not found, else if set to false, takes all characters till end of string as end sequance</param>
        /// <example>
        /// The following example shows how part of the string is extracted based on input values.
        /// <code>
        ///var testString = "This is a test string!";
        /// var result = testString.ExtractSubstring(start: "This is a test ", end: "!", addToStart: "This is a test ".Count());
        /// </code>
        /// result is now string "string".
        /// </example>
        public static string ExtractSubstring(this string value, string start = null, string end = null, int addToStart = 0, int addToEnd = 0, string defaultValue = null, bool returnDefaultIfStartNotFound = true, bool returnDefaultIfEndNotFound = true)
        {
            if (value.IsNullOrWhiteSpace())
            {
                return defaultValue;
            }
            int firstPosition = 0;
            if (!string.IsNullOrEmpty(start))
            {
                firstPosition = value.IndexOf(value: start, comparisonType: StringComparison.Ordinal);
                if (firstPosition < 0)
                {
                    if (returnDefaultIfStartNotFound)
                    {
                        return defaultValue;
                    }
                    firstPosition = 0;
                }
                firstPosition = firstPosition + addToStart;
            }
            int lastPosition = value.Length;
            if (!string.IsNullOrEmpty(end))
            {
                lastPosition = value.IndexOf(value: end, startIndex: firstPosition, comparisonType: StringComparison.Ordinal);
                if (lastPosition < 0)
                {
                    if (returnDefaultIfEndNotFound)
                    {
                        return defaultValue;
                    }
                    lastPosition = value.Length;
                }
                lastPosition = lastPosition + addToEnd;
                if (lastPosition > value.Length)
                {
                    lastPosition = value.Length;
                }
            }
            if (firstPosition >= lastPosition)
            {
                return defaultValue;
            }
            else
            {
                return value.Substring(firstPosition, lastPosition - firstPosition);
            }
        }

        /// <summary>
        /// Encodes text for transmitting in url get. For example, ? is encoded as %3F
        /// </summary>
        /// <param name="value">String type element used as value, can be null or empty.</param>
        /// <example>
        /// The following example shows how string is UrlEncoded.
        /// <code>
        ///var testString = "This is a test string?";
        /// var result = testString.UrlEncode();
        /// </code>
        /// result is now string "This+is+a+test+string%3F".
        /// </example>
        public static string UrlEncode(this string value)
        {
            return WebUtility.UrlEncode(value);
        }

        /// <summary>
        /// Decodes text used for url transmitting. For example %3F is decoded to ?
        /// </summary>
        /// <param name="value">String type element used as value, can be null or empty.</param>
        /// <example>
        /// The following example shows how string is UrlDecoded.
        /// <code>
        ///var testString = "This%20is%20a%20test%20string%3F";
        /// var result = testString.UrlDecode();
        /// </code>
        /// result is now string "This is a test string?".
        /// </example>
        public static string UrlDecode(this string value)
        {
            return WebUtility.UrlDecode(value);
        }

        /// <summary>
        /// Encodes a string to be displayed in a browser. For example > is decoded to &gt;
        /// </summary>
        /// <param name="value">Any string that is not null or empty</param>
        /// <example>
        /// The following example shows how string is encoded to be dispalyed in a browser.
        /// <code>
        ///var testString = "you > me";
        /// var result = testString.HtmlEncode();
        /// </code>
        /// result is now string "you &gt; me".
        /// </example>
        /// 
        public static string HtmlEncode(this string value)
        {
            return WebUtility.HtmlEncode(value);
        }

        /// <summary>
        /// Decodes a string that has been encoded to eliminate invalid HTML characters. For example &gt; is decoded to >
        /// </summary>
        /// <param name="value">String type element used as value, can be null or empty.</param>
        /// <example>
        /// The following example shows how string is decoded to remove invalid HTML characters.
        /// <code>
        ///var testString = "you &gt; me";
        /// var result = testString.HtmlDecode();
        /// </code>
        /// result is now string "you > me".
        /// </example>
        /// 
        public static string HtmlDecode(this string value)
        {
            return WebUtility.HtmlDecode(value);
        }

        /// <summary>
        /// Converts a string to its escaped representation. For example + is replaced with %2B
        /// </summary>
        /// <param name="value">String type element used as value, can be null or empty.</param>
        /// <example>
        /// The following example shows how string is converted to its escaped representation.
        /// <code>
        ///var testString = "This is a test string +";
        /// var result = testString.EscapeDataString();
        /// </code>
        /// result is now string "This%20is%20a%20test%20string%20%2B".
        /// </example>
        public static string EscapeDataString(this string value)
        {
            return Uri.EscapeDataString(value);
        }

        /// <summary>
        /// Converts a string to its escaped representation. For example \ is replaced with %5C
        /// </summary>
        /// <param name="value">String type element used as value, can be null or empty.</param>
        /// <example>
        /// The following example shows how string is converted to its escaped representation.
        /// <code>
        ///var testString = "test\\";
        /// var result = testString.EscapeUriString();
        /// </code>
        /// result is now string "test%5C".
        /// </example>
        public static string EscapeUriString(this string value)
        {
            return Uri.EscapeUriString(value);
        }

        /// <summary>
        /// Indicates whether the specified string is null or an Empty string.
        /// </summary>
        /// <param name="value">String type element used as value, can be null or empty.</param>
        /// <example>
        /// The following example shows input string is tested for null or an Empty string.
        /// <code>
        ///var testString = "";
        /// var result = testString.IsNullOrEmpty();
        /// </code>
        /// result returns true.
        /// </example>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Indicates whether a specified string is null, empty, or consists only of white-space characters.
        /// </summary>
        /// <param name="value">String type element used as value, can be null or empty.</param>
        /// <example>
        /// The following example shows input string is tested for null, empty, or if it consists only of white-space characters.
        /// <code>
        ///var testString = "  ";
        /// var result = testString.IsNullOrWhiteSpace();
        /// </code>
        /// result returns true.
        /// </example>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Converts the specified string, which encodes binary data as base-64 digits, to an equivalent 8-bit unsigned integer array.
        /// </summary>
        /// <param name="value">String type element used as value, can be null or empty.</param>
        /// <example>
        /// The following example shows how string is converted to an equivalent 8-bit unsigned integer array.
        /// <code>
        ///var testString = "AgQGCAoMDhASFA==";
        /// var result = testString.FromBase64String();
        /// </code>
        /// result is now byte[] { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 }
        /// </example>
        public static byte[] FromBase64String(this string value)
        {
            return Convert.FromBase64String(value);
        }

        /// <summary>
        /// encodes a set of characters into a sequence of bytes.
        /// </summary>
        /// <param name="value">String type element used as value, can be null or empty.</param>
        /// <example>
        /// The following example shows how the string is converted to UTF-8 bytes.
        /// <code>
        ///var testString = "string";
        /// var result = testString.GetUTF8Bytes();
        /// </code>
        /// result is now byte[] { 115, 116, 114, 105, 110, 103 }
        /// </example>
        public static byte[] GetUTF8Bytes(this string value)
        {
            if (value != null)
            {
                return Encoding.UTF8.GetBytes(value);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Parses an integer from a String. Returns false rather than throwing exceptin if input is invalid.
        /// </summary>
        /// <param name="value">String type element used as value, can be null or empty.</param>
        /// <example>
        /// The following example shows how integer is parsed from a string.
        /// <code>
        ///var testString = "123";
        /// var result = testString.TryParseInt();
        /// </code>
        /// result is now integer 123.
        /// </example>
        public static int? TryParseInt(this string value)
        {
            int i;
            bool success = int.TryParse(value, out i);
            return success ? (int?)i : (int?)null;
        }

        /// <summary>
        /// Parses a long from a String. Returns false rather than throwing exceptin if input is invalid.
        /// </summary>
        /// <param name="value">String type element used as value, can be null or empty.</param>
        /// <example>
        /// The following example shows how long is parsed from a string.
        /// <code>
        ///var testString = "123";
        /// var result = testString.TryParseInt();
        /// </code>
        /// result is now long 123.
        /// </example>
        public static long? TryParseLong(this string value)
        {
            long i;
            bool success = long.TryParse(value, out i);
            return success ? (long?)i : (long?)null;
        }

        /// <summary>
        /// Truncates the string and adds "..." at the end
        /// </summary>
        /// <param name="value">String type element used as value, can be null or empty.</param>
        /// <param name="maxLen">Maximum allowed length of the string output</param>
        /// <example>
        /// The following example shows how string is truncated based on length of the string and maximum allowed string length input.
        /// <code>
        ///var testString = "This is a test string!";
        /// int maxLen = 14;
        /// var result = testString.Ellipsize(maxLen);
        /// </code>
        /// result is now string "This is a t...".
        /// </example>
        public static string Ellipsize(this string value, int maxLen)
        {
            if (value.Length <= maxLen) return value;
            return value.Substring(0, maxLen - 3) + "...";
        }

        /// <summary>
        /// Adds a dateStamp at the begining of the string separated with a single whitespace.
        /// </summary>
        /// <param name="value">String type element used as value, can be null or empty.</param>
        /// <example>
        /// The following example shows how dateStamp is added to the string.
        /// <code>
        ///var testString = "This is a test string!";
        /// var result = testString.AddNow();
        /// </code>
        /// result is now string "22.8.2018. 8:36:22 This is a test string!".
        /// </example>
        public static string AddNow(this string value)
        {
            return DateTime.Now.ToString() + " " + value;
        }
    }

}