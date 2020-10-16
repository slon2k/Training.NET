// <copyright file="Task308Tests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Tests.Collections
{
    using NUnit.Framework;
    using static Tasks.Collections.Task308;

    /// <summary>
    /// Tests for Task 8.
    /// </summary>
    public class Task308Tests
    {
        /// <summary>
        /// Checks evaluating expressions in Reverse Polish notation.
        /// </summary>
        /// <param name="expression">Expression to evaluate.</param>
        /// <returns>Calculated value.</returns>
        [TestCase("2 3 -", ExpectedResult = -1)]
        [TestCase("6 3 /", ExpectedResult = 2)]
        [TestCase("2 3 *", ExpectedResult = 6)]
        [TestCase("2 3 +", ExpectedResult = 5)]
        [TestCase("5 1 2 + 4 * + 3 -", ExpectedResult = 14)]
        public double CheckCalculateExpression(string expression)
        {
            return CalculateExpression(expression);
        }
    }
}
