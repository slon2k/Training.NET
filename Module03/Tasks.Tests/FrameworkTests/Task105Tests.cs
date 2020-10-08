// <copyright file="Task105Tests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Tests.FrameworkTests
{
    using NUnit.Framework;
    using static Tasks.Framework.Task105;

    /// <summary>
    /// Tests for Task 5.
    /// </summary>
    [TestFixture]
    public class Task105Tests
    {
        /// <summary>
        /// Reverse words tests.
        /// </summary>
        /// <param name="sourceString">Source string.</param>
        /// <returns>Result string.</returns>
        [TestCase("The greatest victory is that which requires no battle", ExpectedResult = "battle no requires which that is victory greatest The")]
        public string CheckReverseWords(string sourceString) => ReverseWords(sourceString);
    }
}
