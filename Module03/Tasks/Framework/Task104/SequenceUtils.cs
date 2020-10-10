// <copyright file="SequenceUtils.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Framework.Task104
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Task 4.
    /// Implement the function which takes as argument a sequence and returns a list of items without any elements with the same value next to each other.
    /// Preserve the original order of elements.
    /// </summary>
    public static class SequenceUtils
    {
        /// <summary>
        /// Returns list of elements without repeating values next to each other.
        /// </summary>
        /// <typeparam name="T">Type of elements.</typeparam>
        /// <param name="sequence">Source sequence.</param>
        /// <returns>Result sequence.</returns>
        public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> sequence)
        {
            var list = new List<T>();
            if (sequence.Count() == 0)
            {
                return list;
            }

            var previousItem = sequence.First();
            list.Add(previousItem);

            foreach (var item in sequence)
            {
                if (!item.Equals(previousItem))
                {
                    list.Add(item);
                    previousItem = item;
                }
            }

            return list;
        }

        /// <summary>
        /// Returns string without repeating characters next to each other.
        /// </summary>
        /// <param name="sourceString">Source string.</param>
        /// <returns>Result string.</returns>
        public static string UniqueInOrderString(string sourceString) => new string(UniqueInOrder(sourceString).ToArray());
    }
}
