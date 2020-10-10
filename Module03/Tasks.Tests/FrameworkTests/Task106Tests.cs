// <copyright file="Task106Tests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Tests.FrameworkTests
{
    using NUnit.Framework;
    using static Tasks.Framework.Task106;

    /// <summary>
    /// Tests for Task 6.
    /// </summary>
    [TestFixture]
    public class Task106Tests
    {
        /// <summary>
        /// Checking addition of big numbers in string format.
        /// </summary>
        /// <param name="number1">First number.</param>
        /// <param name="number2">Second number.</param>
        /// <returns>Sum.</returns>
        [TestCase("100", "1234", ExpectedResult = "1334")]
        public string CheckAddBigNumbers(string number1, string number2)
        {
            return AddBigNumbers(number1, number2);
        }
    }
}
