// <copyright file="Task05Tests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace BasicCoding.Tests
{
    using NUnit.Framework;

    /// <summary>
    /// Tests for Task 5.
    /// </summary>
    public class Task05Tests
    {
        /// <summary>
        /// Finds the nearest larger number of the original number's digits.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>Larger number of the original number's digits or -1.</returns>
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        [TestCase(125330, ExpectedResult = 130235)]
        public static int CheckFindingBiggerNumber(int number)
        {
            return Task05.FindNextBiggerNumber(number);
        }
    }
}
