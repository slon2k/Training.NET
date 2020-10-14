// <copyright file="Task305Tests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Tests.Collections
{
    using NUnit.Framework;
    using Tasks.Collections.Task305;

    /// <summary>
    /// Tests for Task 5.
    /// </summary>
    public class Task305Tests
    {
        /// <summary>
        /// Checking adding an element to a stack.
        /// </summary>
        /// <param name="array">Array to create a stack.</param>
        /// <param name="element">An element to add.</param>
        /// <returns>Elements after adding.</returns>
        [TestCase(new int[] { }, 1, ExpectedResult = new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 }, 4, ExpectedResult = new int[] { 1, 2, 3, 4 })]
        public int[] CheckAddElementToQueue(int[] array, int element)
        {
            var stack = new GenericStack<int>(array);
            stack.Push(element);
            return stack.ToArray();
        }
    }
}
