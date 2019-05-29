using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkStreamliner
{
    /// <summary>Extensions for Array or System.Collections and its children.</summary>
    public static class CollectionsExtensions
    {
        /// <summary>Gets random Item from collection or returns ArgumentException if collection is null or empty. Note that whole IEnumerable will be enumerated.</summary>
        /// <typeparam name="T">Any type of element for value collection</typeparam>
        /// <param name="value">IEnumerable of typeparam to select random item from, that is not null or empty</param>
        /// <example>
        /// The following example shows how random item is selected from the IEnumerable.
        /// <code>
        /// var testIEnumerable = new List&lt;int&gt;() { 1, 2, 1, 3, 4 };
        /// var result = testIEnumerable.RandomItem();
        /// </code>
        /// result is now one of 1, 2, 3, 4 on random.
        /// </example>
        public static T RandomItem<T>(this IEnumerable<T> value)
        {
            if (value == null)
            {
                throw new ArgumentException("Source cannot be null or empty.");
            }
            var count = value.Count();
            if (count == 0)
            {
                throw new ArgumentException("Source cannot be null or empty.");
            }
            return value.ElementAt(StaticEx.Rng.Next(0, count));
        }

        //Copy paste from public static T RandomItem<T>(this IEnumerable<T> value) and changed IEnumerable to ICollection
        /// <summary>
        /// Gets random Item from collection or returns ArgumentException if collection is null or empty.
        /// </summary>
        /// <typeparam name="T">Any type of element for value collection</typeparam>
        /// <param name="value">ICollection of typeparam to select random item from, that is not null or empty</param>
        /// <example>
        /// The following example shows how random item is selected from the ICollection.
        /// <code>
        /// var testICollection = new List&lt;int&gt;() { 1, 2, 1, 3, 4 };
        /// var result = testICollection.RandomItem();
        /// </code>
        /// result is now one of 1, 2, 3, 4 on random.
        /// </example>
        public static T RandomItem<T>(this ICollection<T> value)
        {
            if (value == null || value.Count == 0)
            {
                throw new ArgumentException("Source cannot be null or empty.");
            }
            return value.ElementAt(StaticEx.Rng.Next(0, value.Count));
        }

        //Copy paste from public static T RandomItem<T>(this IEnumerable<T> value) and changed IEnumerable to Array.
        /// <summary>
        /// Gets random Item from array or returns ArgumentException if array is null or empty.
        /// </summary>
        /// <typeparam name="T">Any type of element for value collection</typeparam>
        /// <param name="value">Array of typeparam to select random item from, that is not null or empty</param>
        /// <example>
        /// The following example shows how random item is selected from the array.
        /// <code>
        /// var testArray = new List&lt;int&gt;() { 1, 2, 1, 3, 4 };
        /// var result = testArray.RandomItem();
        /// </code>
        /// result is now one of 1, 2, 3, 4 on random.
        /// </example>
        public static T RandomItem<T>(this T[] value)
        {
            if (value == null || value.Length == 0)
            {
                throw new ArgumentException("Source cannot be null or empty.");
            }
            return value[StaticEx.Rng.Next(0, value.Length)];
        }

        /// <summary>
        /// Based on the input count, takes that many Items from IList randomly, returns ArgumentException if list is null or empty
        /// or count input is bigger then total number of Items in list.
        /// </summary>
        /// <typeparam name="T">Any type of element for value collection</typeparam>
        /// <param name="value">IList of typeparam to take sample from, that is not null or empty</param>
        /// <param name="count">Number of typeparam elements wanted from the IList as sample</param>
        /// <example>
        /// The following example shows how random items is selected from the IList.
        /// <code>
        ///var testIList = new List&lt;int&gt;() { 1, 2, 1, 3, 4 };
        ///int count = 2;
        /// var result = testIList.Sample(count);
        /// </code>
        /// result is now list of 2 numbers picked from the list of 1, 2, 1, 3, 4 on random.
        /// </example>
        public static IList<T> Sample<T>(this IList<T> value, int count)
        {
            if (value == null || value.Count == 0)
            {
                throw new ArgumentException("List cannot be null or empty.");
            }
            if (count >= value.Count)
            {
                throw new ArgumentException("Count cannot be larger than List Count. User Randomize instead.");
            }
            HashSet<int> sampleIndexes = new HashSet<int>();
            while (sampleIndexes.Count < count)
            {
                sampleIndexes.Add(StaticEx.Rng.Next(0, value.Count));
            }
            IList<T> result = new List<T>(count);
            foreach (var currentSampleIndex in sampleIndexes)
            {
                result.Add(value[currentSampleIndex]);
            }
            return result;
        }

        /// <summary>
        /// Based on the input count, takes that many Items from array randomly, returns ArgumentException if list is null or empty
        /// or count input is bigger then total number of Items in array.
        /// </summary>
        /// <typeparam name="T">Any type of element for value collection</typeparam>
        /// <param name="value">Array of typeparam to take sample from, that is not null or empty</param>
        /// <param name="count">Number of elements wanted from the array as sample</param>
        /// <example>
        /// The following example shows how random items is selected from the array.
        /// <code>
        ///var testIList = new List&lt;int&gt;() { 1, 2, 1, 3, 4 };
        ///int count = 2;
        /// var result = testIList.Sample(count);
        /// </code>
        /// result is now list of 2 numbers picked from the list of 1, 2, 1, 3, 4 on random.
        /// </example>
        public static T[] Sample<T>(this T[] value, int count)
        {
            if (value == null || value.Length == 0)
            {
                throw new ArgumentException("Array cannot be null or empty.");
            }
            if (count >= value.Length)
            {
                throw new ArgumentException("Count cannot be larger or the same as Array Count. User Randomize instead.");
            }
            HashSet<int> sampleIndexes = new HashSet<int>();
            while (sampleIndexes.Count < count)
            {
                sampleIndexes.Add(StaticEx.Rng.Next(0, value.Length));
            }
            T[] result = new T[count];
            int i = 0;
            foreach (var currentSampleIndex in sampleIndexes)
            {
                result[i] = value[currentSampleIndex];
                i++;
            }
            return result;
        }

        /// <summary>
        /// Randomizes Items in the IList, returns ArgumentException if list is null or empty.
        /// </summary>
        /// <typeparam name="T">Any type of element for value collection</typeparam>
        /// <param name="value">IList of typeparam to randomize positions in list, that is not null or empty</param>
        /// <example>
        /// The following example shows how random items is selected from the array.
        /// <code>
        ///var testIList = new List&lt;int&gt;() { 1, 2, 1, 3, 4 };
        /// var result = testIList.Randomize();
        /// </code>
        /// result is now new list of items with new random positions.
        /// </example>
        public static IList<T> Randomize<T>(this IList<T> value)
        {
            if (value == null || value.Count == 0)
            {
                throw new ArgumentException("List cannot be null or empty.");
            }
            int n = value.Count;
            int k = 0;
            while (n > 1)
            {
                k = StaticEx.Rng.Next(n--);
                //n = n - 1; pa maknut minus samo treba isprobat
                T temp = value[n];
                value[n] = value[k];
                value[k] = temp;
            }
            return value;
        }

        /// <summary>
        /// Randomizes Items in the Array, returns ArgumentException if Array is null or empty.
        /// </summary>
        /// <typeparam name="T">Any type of element for value collection</typeparam>
        /// <param name="value">Array of typeparam to randomize positions in array, that is not null or empty</param>
        /// <example>
        /// The following example shows how random items is selected from the array.
        /// <code>
        ///var testArray = new List&lt;int&gt;() { 1, 2, 1, 3, 4 };
        /// var result = testArray.Randomize();
        /// </code>
        /// result is now list of items with new random positions.
        /// </example>
        public static T[] Randomize<T>(this T[] value)
        {
            if (value == null || value.Length == 0)
            {
                throw new ArgumentException("Array cannot be null or empty.");
            }
            int n = value.Length;
            int k = 0;
            while (n > 1)
            {
                k = StaticEx.Rng.Next(n--);
                T temp = value[n];
                value[n] = value[k];
                value[k] = temp;
            }
            return value;
        }

        /// <summary>
        /// Compares two sequences and returns true if both are null or equal, else returns false.
        /// </summary>
        /// <typeparam name="TSource">Any type of element for first and second collection</typeparam>
        /// <param name="first">IEnumerable of typeparam to compare with second</param>
        /// <param name="second">IEnumerable of typeparam to compare with first</param>
        /// <example>
        /// The following example shows how two collestions are compared with one another.
        /// <code>
        /// var firstSequence = new List&lt;int&gt;() { 1, 2, 3, };
        /// var secondSequence = new List&lt;int&gt;() { 1, 2, 3 };
        /// var result = firstSequence.NullableSequenceEqual(secondSequence);
        /// </code>
        /// </example>
        public static bool NullableSequenceEqual<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            if (first == null && second == null)
            {
                return true;
            }
            else if (first == null && second != null)
            {
                return false;
            }
            else if (first != null && second == null)
            {
                return false;
            }
            else
            {
                return first.SequenceEqual(second);
            }
        }
    }
}
