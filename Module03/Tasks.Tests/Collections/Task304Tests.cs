// <copyright file="Task304Tests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Tests.Collections
{
    using System.Collections.Generic;
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
        [TestCase(new int[] { }, 1, ExpectedResult = new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 }, 4, ExpectedResult = new int[] { 1, 2, 3, 4 })]
        public int[] CheckAddElementToQueue(int[] array, int element)
        {
            var queue = new GenericQueue<int>(array);
            queue.Enqueue(element);
            return queue.ToArray();
        }

        /// <summary>
        /// Checking clearing the queue.
        /// </summary>
        /// <param name="array">Array to create a queue.</param>
        [TestCase(new int[] { 1, 2, 3 })]
        public void CheckClearQueue(int[] array)
        {
            var queue = new GenericQueue<int>(array);
            queue.Clear();
            Assert.That(queue.ToArray, Is.EqualTo(new int[] { }));
        }

        /// <summary>
        /// Checking Dequeue.
        /// </summary>
        /// <param name="array">Array to create a queue.</param>
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void CheckDequeue(int[] array)
        {
            var queue = new GenericQueue<int>(array);
            var element = queue.Dequeue();
            Assert.That(element, Is.EqualTo(array[0]));
            Assert.That(queue.ToArray(), Is.EqualTo(array[1..]));
        }

        /// <summary>
        /// Checking Peek.
        /// </summary>
        /// <param name="array">Array to create a queue.</param>
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void CheckPeek(int[] array)
        {
            var queue = new GenericQueue<int>(array);
            var element = queue.Peek();
            Assert.That(element, Is.EqualTo(array[0]));
            Assert.That(queue.ToArray(), Is.EqualTo(array));
        }

        /// <summary>
        /// Checking enumerator.
        /// </summary>
        /// <param name="array">Array to create a queue.</param>
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void CheckQueueEnumerator(int[] array)
        {
            var queue = new GenericQueue<int>(array);
            var list = new List<int>();
            foreach (var item in queue)
            {
                list.Add(item);
            }

            Assert.That(queue.ToArray(), Is.EqualTo(list.ToArray()));
        }

        /// <summary>
        /// Checking increasing capacity.
        /// </summary>
        [Test]
        public void CheckAddingCapacity()
        {
            var queue = new GenericQueue<int>();
            int length = 150;

            for (int i = 0; i < length; i++)
            {
                queue.Enqueue(i);
            }

            var items = queue.ToArray();
            Assert.That(items.Length, Is.EqualTo(length));

            for (int i = 0; i < length; i++)
            {
                Assert.That(items[i] == i);
            }
        }
    }
}
