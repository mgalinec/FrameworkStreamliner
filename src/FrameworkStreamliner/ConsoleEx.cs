using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkStreamliner
{
    /// <summary>Methods for System.Console that are not available in System.Console.</summary>
    public static class ConsoleEx
    {
        /// <summary>
        /// Writes console ouput using a red color, with boolean option to exclude timestamp.
        /// </summary>
        /// <param name="message">A string message for console output</param>
        /// <param name="excludeAddingNow">Boolean if console should exclude timestamp. Default is false</param>
        /// <example>
        /// The following example shows how to write in console output with red color.
        /// <code>
        /// var testString = "This is a test string?";
        /// ConsoleEx.WriteLineRed(testString);
        /// </code>  
        /// </example>
        public static void WriteLineRed(string message, bool excludeAddingNow = false)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(excludeAddingNow ? message : message.AddNow());
            Console.ResetColor();
        }

        /// <summary>
        /// Writes console ouput using a green color, with boolean option to exclude timestamp.
        /// </summary>
        /// <param name="message">A string message for console output</param>
        /// <param name="excludeAddingNow">Boolean if console should exclude timestamp. Default is false</param>
        /// <example>
        /// The following example shows how to write in console output with green color.
        /// <code>
        /// var testString = "This is a test string?";
        /// ConsoleEx.WriteLineGreen(testString);
        /// </code>
        /// </example>
        public static void WriteLineGreen(string message, bool excludeAddingNow = false)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(excludeAddingNow ? message : message.AddNow());
            Console.ResetColor();
        }

        /// <summary>
        /// Writes console ouput using a yellow color, with boolean option to exclude timestamp.
        /// </summary>
        /// <param name="message">A string message for console output</param>
        /// <param name="excludeAddingNow">Boolean if console should exclude timestamp. Default is false</param>
        /// <example>
        /// The following example shows how to write in console output with yellow color.
        /// <code>
        /// var testString = "This is a test string?";
        /// ConsoleEx.WriteLineYellow(testString);
        /// </code>
        /// </example>
        public static void WriteLineYellow(string message, bool excludeAddingNow = false)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(excludeAddingNow ? message : message.AddNow());
            Console.ResetColor();
        }

        /// <summary>
        /// Writes console ouput using a default color.
        /// </summary>
        /// <param name="message">A string message for console output</param>
        /// <param name="excludeAddingNow">Boolean if console should exclude timestamp. Default is false</param>
        /// <example>
        /// The following example shows how to write in console output with default color.
        /// <code>
        /// var testString = "This is a test string?";
        /// ConsoleEx.WriteLine(testString);
        /// </code>
        /// </example>
        public static void WriteLine(string message, bool excludeAddingNow = false)
        {
            Console.WriteLine(excludeAddingNow ? message : message.AddNow());
        }

        /// <summary>
        /// Changes color of the console ouput based on the ConsoleColor input.
        /// </summary>
        /// <param name="message">A string message for console output</param>
        /// <param name="color">ConsoleColor type input for color to be used in Console output</param>
        /// <param name="excludeAddingNow">Boolean if console should exclude timestamp. Default is false</param>
        /// <example>
        /// The following example shows how to write in console output with input color of the type ConsoleColor.
        /// <code>
        /// var testString = "This is a test string?";
        /// ConsoleColor color = 1;
        /// ConsoleEx.WriteLineWithColor(testString, color);
        /// </code>
        /// </example>
        public static void WriteLineWithColor(string message, ConsoleColor color, bool excludeAddingNow = false)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(excludeAddingNow ? message : message.AddNow());
            Console.ResetColor();
        }
    }
}
