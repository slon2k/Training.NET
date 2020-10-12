// <copyright file="Task302Tests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Tests.Collections
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using static Tasks.Collections.Task302;

    /// <summary>
    /// Tests for Task 2.
    /// </summary>
    public class Task302Tests
    {
        /// <summary>
        /// Testing WordCount.
        /// </summary>
        [Test]
        public void CheckWordCount()
        {
            string text = @"C# is an object-oriented, component-oriented programming language. " +
                @"Since its origin, C# has added features to support new workloads and emerging software design practices.";
            var frequency = WordCount(text);
            Assert.That(frequency["c#"], Is.EqualTo(2));
        }
    }
}
