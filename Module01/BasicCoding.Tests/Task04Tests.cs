// <copyright file="Task04Tests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace BasicCoding.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using NUnit.Framework;

    /// <summary>
    /// Tests for Task 4.
    /// </summary>
    [TestFixture]
    public class Task04Tests
    {
        /// <summary>
        /// Concatenates two strings excluding duplicate characters from the second string.
        /// </summary>
        /// <param name="firstStr">First string.</param>
        /// <param name="secondStr">Second string.</param>
        /// <returns>Concatenated string.</returns>
        [TestCase("AsdfeAd", "Assqaasssqs", ExpectedResult = "AsdfeAdqaaq")]
        public string CheckStringConcatenation(string firstStr, string secondStr)
        {
            return Task04.ConcatenateStrings(firstStr, secondStr);
        }
    }
}
