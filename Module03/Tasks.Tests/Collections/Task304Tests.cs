// <copyright file="Task304Tests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Tests.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using NUnit.Framework;
    using Tasks.Collections.Task304;

    /// <summary>
    /// Tests for Task 4.
    /// </summary>
    public class Task304Tests
    {
        /// <summary>
        /// Checking adding an element to a queue.
        /// </summary>
        /// <param name="array">Array to create a queue.</param>
        /// <param name="element">An element to add.</param>
        /// <returns>Elements after adding.</returns>
        [TestCase(new int[] { 1, 2, 3 }, 4, ExpectedResult = new int[] { 1, 2, 3, 4 })]
        public int[] CheckAddElementToQueue(int[] array, int element)
        {
            var queue = new GenericQueue<int>(array);
            queue.Enqueue(element);
            return queue.ToArray();
        }
    }
}
