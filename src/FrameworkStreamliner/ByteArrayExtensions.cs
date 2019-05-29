using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace FrameworkStreamliner
{
    /// <summary>Extensions for System.Byte array (byte[]).</summary>
    public static class ByteArrayExtensions
    {
        /// <summary>Converts this byte array to equivalent base 64 string or returns null if this array is null or empty.</summary>
        /// <param name="value">Byte array to convert, can be null or empty.</param>
        /// <remarks>Calls Convert.ToBase64String(value) but with additional testing for null or empty so it doesn't return exceptions.</remarks>
        /// <example>
        /// The following example shows how array of bytes are converted to Base64 string.
        /// <code>
        /// var testBytes = new byte[] { 1, 2, 1, 3, 4 };
        /// var resultString = testBytes.ToBase64String();
        /// </code>
        /// resultString now equals "AQIBAwQ="
        /// </example>
        public static string ToBase64String(this byte[] value)
        {
            if (value == null || value.Length == 0)
            {
                return null;
            }
            return Convert.ToBase64String(value);
        }

        /// <summary>Compresses this byte array with gz compression or returns null or empty if this array is null or empty respectively.</summary>
        /// <param name="value">Byte array to compress, can be null or empty.</param>
        /// <remarks>
        /// Writes all bytes to GZipStream that uses MemoryStream for storing and then when compressed returns them.
        /// Before everything this byte array is tested for null or empty to avoid exceptions.
        /// </remarks>
        /// <example>
        /// The following example shows how array of bytes from string are compressed to gz.
        /// <code>
        /// byte[] testBytes = Encoding.UTF8.GetBytes("This string will be compressed using gz compression.");
        /// var resultBytes = testBytes.CompressGZip();
        /// var resultString = Encoding.UTF8.GetString(resultBytes);
        /// </code>
        /// resultString now equals "\u001f�\b\0\0\0\0\0\u0004\0\v��,V(.)��KW(���QHJUH��-(J-.NMQ(-\u0006I�W��2���\0�\u0016\u000354\0\0\0"
        /// </example>
        public static byte[] CompressGZip(this byte[] value)
        {
            if (value == null)
            {
                return null;
            }
            if (value.Length == 0)
            {
                return value;
            }

            using (MemoryStream memory = new MemoryStream())
            {
                using (GZipStream gz = new GZipStream(memory, CompressionMode.Compress, false))
                {
                    gz.Write(value, 0, value.Length);
                }
                return memory.ToArray();
            }
        }

        /// <summary>Decompresses this byte array that is compressed with gz compression or returns null or empty if this array is null or empty respectively.</summary>
        /// <param name="value">Byte array to decompress, can be null or empty.</param>
        /// <remarks>
        /// Writes all bytes to GZipStream in decompress model using MemoryStream then returns them using another memory stream that reads from them.
        /// Before everything this byte array is tested for null or empty to avoid exceptions.
        /// </remarks>
        /// <example>
        /// The following example shows how array of bytes from string are compressed to gz and decompressed.
        /// <code>
        /// byte[] testBytes = Encoding.UTF8.GetBytes("This string will be compressed using gz compression.");
        /// var compressedBytes = testBytes.CompressGZip();
        /// var compressedString = Encoding.UTF8.GetString(compressedBytes);
        /// var resultBytes = compressedBytes.DecompressGZip();
        /// var resultString = Encoding.UTF8.GetString(resultBytes);
        /// </code>
        /// resultString now equals "This string will be compressed using gz compression."
        /// while compressedString equals "\u001f�\b\0\0\0\0\0\u0004\0\v��,V(.)��KW(���QHJUH��-(J-.NMQ(-\u0006I�W��2���\0�\u0016\u000354\0\0\0"
        /// </example>
        public static byte[] DecompressGZip(this byte[] value)
        {
            if (value == null)
            {
                return null;
            }
            if (value.Length == 0)
            {
                return value;
            }
            using (GZipStream stream = new GZipStream(new MemoryStream(value), CompressionMode.Decompress))
            {
                const int size = 4096;
                byte[] buffer = new byte[size];
                using (MemoryStream memory = new MemoryStream())
                {
                    int count = 0;
                    do
                    {
                        count = stream.Read(buffer, 0, size);
                        if (count > 0)
                        {
                            memory.Write(buffer, 0, count);
                        }
                    }
                    while (count > 0);
                    return memory.ToArray();
                }
            }
        }

        /// <summary>Decodes this byte array into UTF8 encoding or returns null or empty if this array is null or empty respectively.</summary>
        /// <param name="value">Byte array to decode into UTF8 string, can be null or empty.</param>
        /// <remarks>Calls Encoding.UTF8.GetString but with additional testing for null or empty so it doesn't return exceptions.</remarks>
        /// <example>
        /// The following example shows how array of bytes are converted from and to UTF8 string.
        /// <code>
        /// byte[] testBytes = Encoding.UTF8.GetBytes("test");
        /// var resultBytes = testBytes.GetUTF8String();
        /// var resultString = Encoding.UTF8.GetString(testBytes);
        /// </code>
        /// resultString now equals "test"
        /// while resultBytes equals new byte[] {116, 101, 115, 116}
        /// </example>
        public static string GetUTF8String(this byte[] value)
        {
            if (value == null)
            {
                return null;
            }
            if (value.Length == 0)
            {
                return "";
            }
            return Encoding.UTF8.GetString(value, 0, value.Length);
        }
    }
}
