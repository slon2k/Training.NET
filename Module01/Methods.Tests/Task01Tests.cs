// <copyright file="Task01Tests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Methods.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using NUnit.Framework;

    /// <summary>
    /// Tests for Task 1.
    /// </summary>
    [TestFixture]
    public class Task01Tests
    {
        /// <summary>
        /// Checking converting to IEEE 754 format.
        /// </summary>
        /// <param name="number">Number to convert.</param>
        /// <returns>String in the IEEE 754 format.</returns>
        [TestCase(85.125, ExpectedResult = "0100000001010101010010000000000000000000000000000000000000000000")]
        [TestCase(0.005, ExpectedResult = "0011111101110100011110101110000101000111101011100001010001111011")]
        [TestCase(-255.255, ExpectedResult = "1100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(255.255, ExpectedResult = "0100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(4294967295.0, ExpectedResult = "0100000111101111111111111111111111111111111000000000000000000000")]
        [TestCase(double.MinValue, ExpectedResult = "1111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.MaxValue, ExpectedResult = "0111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.Epsilon, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000001")]
        [TestCase(double.NaN, ExpectedResult = "1111111111111000000000000000000000000000000000000000000000000000")]
        [TestCase(double.NegativeInfinity, ExpectedResult = "1111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(double.PositiveInfinity, ExpectedResult = "0111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(0.0, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000000")]
        [TestCase(-0.0, ExpectedResult = "1000000000000000000000000000000000000000000000000000000000000000")]
        //[TestCase(double.Epsilon + double.Epsilon, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000010")]
        public string CheckConvertingToIEEE(double number)
        {
            return number.ToIEEE754();
        }
    }
}
