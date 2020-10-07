// <copyright file="Task101Tests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Tests.FrameworkTests
{
    using System;
    using NUnit.Framework;
    using static Tasks.Framework.Task101;

    /// <summary>
    /// Tests for Task 1.
    /// </summary>
    [TestFixture]
    public class Task101Tests
    {
        /// <summary>
        /// Testing customer record.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="phone">Phone.</param>
        /// <param name="revenue">Revenue.</param>
        /// <param name="options">Options.</param>
        /// <returns>Record.</returns>
        [TestCase("Bill Gates", "+1 (555) 123 55 55", 1000000, new string[] { "name", "phone", "revenue" }, ExpectedResult = "Bill Gates, $1,000,000.00, + 1(555) 123 55 55")]
        [TestCase("Bill Gates", "+1 (555) 123 55 55", 1000000, new string[] { "name" }, ExpectedResult = "Bill Gates")]
        [TestCase("Bill Gates", "+1 (555) 123 55 55", 1000000, new string[] { "phone" }, ExpectedResult = "+1 (555) 123 55 55")]
        [TestCase("Bill Gates", "+1 (555) 123 55 55", 1000000, new string[] { "revenue" }, ExpectedResult = "$1,000,000.00")]
        [TestCase("Bill Gates", "+1 (555) 123 55 55", 1000000, new string[] { "name", "phone" }, ExpectedResult = "Bill Gates, + 1(555) 123 55 55")]
        [TestCase("Bill Gates", "+1 (555) 123 55 55", 1000000, new string[] { "name", "revenue" }, ExpectedResult = "Bill Gates, $1,000,000.00")]
        [TestCase("Bill Gates", "+1 (555) 123 55 55", 1000000, new string[] { "phone", "revenue" }, ExpectedResult = "+ 1(555) 123 55 55, $1,000,000.00")]
        public string CheckCustomerRecord(string name, string phone, decimal revenue, string[] options)
        {
            var customer = new Customer() { Name = name, Phone = phone, Revenue = revenue };
            return customer.CustomerRecord(options);
        }
    }
}
