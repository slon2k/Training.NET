// <copyright file="Task104Tests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Tests.FrameworkTests
{
    using System.Linq;
    using NUnit.Framework;
    using static Tasks.Framework.Task104.SequenceUtils;

    /// <summary>
    /// Tests for Task 4.
    /// </summary>
    [TestFixture]
    public class Task104Tests
    {
        /// <summary>
        /// Checking reducing the sequence for strings.
        /// </summary>
        /// <param name="sourceString">Source string.</param>
        /// <returns>Result string.</returns>
        [TestCase("AAAABBBCCDAABBB", ExpectedResult ="ABCDAB")]
        [TestCase("ABBCcAD", ExpectedResult = "ABCcAD")]
        [TestCase("12233", ExpectedResult = "123")]
        public string CheckUniqueInOrderStrings(string sourceString)
        {
            return UniqueInOrderString(sourceString);
        }

        /// <summary>
        /// Checking reducing the sequence for list of integers.
        /// </summary>
        /// <param name="array">Source array.</param>
        /// <returns>Result array.</returns>
        [TestCase(new int[] { 1, 2, 2, 1, 3, 3, 2, 2 }, ExpectedResult = new int[] { 1, 2, 1, 3, 2 })]
        public int[] CheckUniqueInOrderListInt(int[] array)
        {
            return UniqueInOrder(array.ToList()).ToArray();
        }
    }
}
