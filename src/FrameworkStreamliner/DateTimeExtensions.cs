using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkStreamliner
{
    /// <summary>Extensions for System.DateTime (DateTime).</summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Converts DateTime value to string in format of "yyyyMMdd" and then to its 32-bit signed integer equivalent. 
        /// </summary>
        /// <param name="value">System.DateTime type used for value</param>
        /// <example>
        /// The following example shows how System.DateTime input is converted to integer.
        /// <code>
        /// var testTime = new DateTime(year: 2000, month: 12, day: 15);
        /// var result = testTime.ToInt();
        /// </code>
        /// result is now integer 20001215.
        /// </example>
        public static int ToInt(this DateTime value)
        {
            return int.Parse(value.ToString("yyyyMMdd"));
        }

        /// <summary>
        /// Returns IEnumerable DateTime in order given date value and toDate, both are inclusive.
        /// </summary>
        /// <param name="value">DateTime type of elment used as value</param>
        /// <param name="toDate">DateTime type of element used as toDate</param>
        /// <example>
        /// The following example shows how days are enumerated given the value DateTime and toDate DateTime.
        /// <code>
        ///var testTime = DateTime.Now;
        /// var toDate = testTime.AddDays(10);
        /// var result = testTime.EnumDays(toDate);
        /// </code>
        /// result is now list DateTimes beetween two given DateTimes.
        /// </example>
        public static IEnumerable<DateTime> EnumDays(this DateTime value, DateTime toDate)
        {
            if (toDate > value)
            {
                var day = value;
                while (day.Date <= toDate.Date)
                {
                    yield return day;
                    day = day.AddDays(1);
                }
            }
            else if (toDate.Date == value.Date)
            {
                yield return value;
            }
            else
            {
                var day = value;
                while (day.Date >= toDate.Date)
                {
                    yield return day;
                    day = day.AddDays(-1);
                }
            }
        }
    }
}
