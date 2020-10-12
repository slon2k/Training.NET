// <copyright file="Task303Tests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Tests.Collections
{
    using System.Collections.Generic;
    using NUnit.Framework;
    using static Tasks.Collections.Task303;

    /// <summary>
    /// Tests for Task 3.
    /// </summary>
    public class Task303Tests
    {
        /// <summary>
        /// Testing list of Fibonacci Numbers.
        /// </summary>
        /// <param name="limit">Numbers count.</param>
        /// <returns>Array of Fibonacci Numbers.</returns>
        [TestCase(2, ExpectedResult = new int[] { 1, 1 })]
        [TestCase(3, ExpectedResult = new int[] { 1, 1, 2 })]
        [TestCase(4, ExpectedResult = new int[] { 1, 1, 2, 3 })]
        [TestCase(7, ExpectedResult = new int[] { 1, 1, 2, 3, 5, 8, 13 })]
        public int[] CheckFibonacciNumbers(int limit)
        {
            var list = new List<int>();
            foreach (var item in FibonacciNumbers(limit))
            {
                list.Add(item);
            }

            return list.ToArray();
        }
    }
}
