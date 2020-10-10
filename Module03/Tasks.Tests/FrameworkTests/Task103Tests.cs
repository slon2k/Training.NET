// <copyright file="Task103Tests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Tests.FrameworkTests
{
    using NUnit.Framework;
    using static Tasks.Framework.Task103.UrlManipulation;

    /// <summary>
    /// Tests for Task 3.
    /// </summary>
    [TestFixture]
    public class Task103Tests
    {
        /// <summary>
        /// Changing or adding URL paremeter tests.
        /// </summary>
        /// <param name="url">URL.</param>
        /// <param name="keyValueParameter">Parameter.</param>
        /// <returns>Changed URL.</returns>
        [TestCase("www.example.com", "key=value", ExpectedResult = "www.example.com?key=value")]
        [TestCase("www.example.com?key=value", "key2=value2", ExpectedResult = "www.example.com?key=value&key2=value2")]
        [TestCase("www.example.com?key=oldValue", "key=newValue", ExpectedResult = "www.example.com?key=newValue")]
        [TestCase("www.example.com?key1=value1&key2=value2", "key3=value3", ExpectedResult = "www.example.com?key1=value1&key2=value2&key3=value3")]
        [TestCase("www.example.com?key1=value1&key2=value2", "key1=value3", ExpectedResult = "www.example.com?key1=value3&key2=value2")]
        public string CheckAddOrChangeUrlParameter(string url, string keyValueParameter)
        {
            return AddOrChangeUrlParameter(url, keyValueParameter);
        }
    }
}
