// <copyright file="Task102Tests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Tests.FrameworkTests
{
    using NUnit.Framework;
    using static Tasks.Framework.Task102.StringUtils;

    /// <summary>
    /// Tests for Task 2.
    /// </summary>
    [TestFixture]
    public class Task102Tests
    {
        /// <summary>
        /// Testing converting to title case.
        /// </summary>
        /// <param name="originalString">The original string to be converted.</param>
        /// <param name="minorWords">Space-delimited list of minor words that must always be lowercase.</param>
        /// <returns>String in title case.</returns>
        [TestCase("a clash of KINGS", "a an the of", ExpectedResult = "A Clash of Kings")]
        [TestCase("THE WIND IN THE WILLOWS", "The In", ExpectedResult = "The Wind in the Willows")]
        [TestCase("the quick brown fox", ExpectedResult = "The Quick Brown Fox")]
        public string CheckConvertingToTitleCase(string originalString, string minorWords = null)
        {
            return ConvertToTitleCase(originalString, minorWords);
        }
    }
}
