// <copyright file="Task305Tests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Tests.Collections
{
    using System.Collections.Generic;
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

        /// <summary>
        /// Checking clearing the stack.
        /// </summary>
        /// <param name="array">Array to create a queue.</param>
        [TestCase(new int[] { 1, 2, 3 })]
        public void CheckClearStack(int[] array)
        {
            var stack = new GenericStack<int>(array);
            stack.Clear();
            Assert.That(stack.ToArray, Is.EqualTo(new int[] { }));
        }

        /// <summary>
        /// Checking Pop.
        /// </summary>
        /// <param name="array">Array to create a queue.</param>
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void CheckPop(int[] array)
        {
            var stack = new GenericStack<int>(array);
            var element = stack.Pop();
            Assert.That(element, Is.EqualTo(array[^1]));
            Assert.That(stack.ToArray(), Is.EqualTo(array[0..^1]));
        }

        /// <summary>
        /// Checking Peek.
        /// </summary>
        /// <param name="array">Array to create a queue.</param>
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void CheckPeek(int[] array)
        {
            var stack = new GenericStack<int>(array);
            var element = stack.Peek();
            Assert.That(element, Is.EqualTo(array[^1]));
            Assert.That(stack.ToArray(), Is.EqualTo(array));
        }

        /// <summary>
        /// Checking Push.
        /// </summary>
        /// <param name="array">Array to create a queue.</param>
        /// <param name="element">Element to add.</param>
        /// <returns>Elements after adding.</returns>
        [TestCase(new int[] { 1, 2, 3, 4 }, 5, ExpectedResult = new int[] { 1, 2, 3, 4, 5 })]
        public int[] CheckPush(int[] array, int element)
        {
            var stack = new GenericStack<int>(array);
            stack.Push(element);
            return stack.ToArray();
        }

        /// <summary>
        /// Checking enumerator.
        /// </summary>
        /// <param name="array">Array to create a stack.</param>
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void CheckQueueEnumerator(int[] array)
        {
            var stack = new GenericStack<int>(array);
            var list = new List<int>();
            foreach (var item in stack)
            {
                list.Add(item);
            }

            Assert.That(stack.ToArray(), Is.EqualTo(list.ToArray()));
        }

        /// <summary>
        /// Checking increasing capacity.
        /// </summary>
        [Test]
        public void CheckAddingCapacity()
        {
            var stack = new GenericStack<int>();
            int length = 150;

            for (int i = 0; i < length; i++)
            {
                stack.Push(i);
            }

            var items = stack.ToArray();
            Assert.That(items.Length, Is.EqualTo(length));

            for (int i = 0; i < length; i++)
            {
                Assert.That(items[i] == i);
            }
        }
    }
}
