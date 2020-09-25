// <copyright file="Task01Tests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace BasicCoding.Tests
{
    using System;
    using NUnit.Framework;

    /// <summary>Tests for Task 1.</summary>
    [TestFixture]
    public class Task01Tests
    {
        /// <summary>Inserts bits from the second number to the first number.</summary>
        /// <param name="a">The first integer.</param>
        /// <param name="b">The second integer.</param>
        /// <param name="i">The first bit.</param>
        /// <param name="j">The last bit.</param>
        /// <returns>Modified first number.</returns>
        [TestCase(64, 63, 0, 1, ExpectedResult = 67)]
        [TestCase(255, 0, 3, 5, ExpectedResult = 199)]
        public int CheckInsertNumber(int a, int b, int i, int j)
        {
            return Task01.InsertNumber(a, b, i, j);
        }

        /// <summary>Checking InsertNumber argument exceptions.</summary>
        /// <param name="a">a should be integer.</param>
        /// <param name="b">b should be integer.</param>
        /// <param name="i">i mist be in range 0..32 and not greater than j.</param>
        /// <param name="j">j mist be in range 0..32 and not less than i.</param>
        [TestCase(64, 63, 3, 1)]
        [TestCase(64, 63, 10, 0)]
        [TestCase(64, 63, 5, 1)]
        public void CheckInsertNumberArgumentException(int a, int b, int i, int j)
        {
            Assert.That(() => Task01.InsertNumber(a, b, i, j), Throws.TypeOf<ArgumentException>());
        }

        /// <summary>Checking InsertNumber argument out of range exceptions.</summary>
        /// <param name="a">a should be integer.</param>
        /// <param name="b">b should be integer.</param>
        /// <param name="i">i mist be in range 0..32 and not greater than j.</param>
        /// <param name="j">j mist be in range 0..32 and not less than i.</param>
        [TestCase(64, 63, -1, 1)]
        [TestCase(64, 63, 33, 1)]
        [TestCase(64, 63, 10, -1)]
        [TestCase(64, 63, 10, 33)]
        public void CheckInsertNumberArgumentOutOfRangeException(int a, int b, int i, int j)
        {
            Assert.That(() => Task01.InsertNumber(a, b, i, j), Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
