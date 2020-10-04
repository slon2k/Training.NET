// <copyright file="Task03Tests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Methods.Tests
{
    using NUnit.Framework;

    /// <summary>
    /// Tests for Task 3.
    /// </summary>
    [TestFixture]
    public class Task03Tests
    {
        /// <summary>
        /// Testing extension that checks nullable types whether a reference is null.
        /// </summary>
        [Test]
        public static void CheckValueNullChecking()
        {
            int? a = 1;
            Assert.That(a.IsNull() == false);
            a = null;
            Assert.That(a.IsNull() == true);
            double? d = null;
            Assert.That(d.IsNull() == true);
            d = 0;
            Assert.That(d.IsNull() == false);
            string str = null;
            Assert.That(str.IsNull() == true);
            str = "Hello";
            Assert.That(str.IsNull() == false);
        }
    }
}
