// <copyright file="SinglyLinkedListTests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Tests.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NUnit.Framework;
    using Tasks.Collections.Task306;

    /// <summary>
    /// Tests for SinglyLinkedList.
    /// </summary>
    public class SinglyLinkedListTests
    {
        /// <summary>
        /// Check adding an element to the list.
        /// </summary>
        /// <param name="array">Data to create a list.</param>
        /// <param name="element">Element to add.</param>
        /// <returns>Elements in the list.</returns>
        [TestCase(new int[] { 1, 2, 3, 4 }, 5, ExpectedResult = new int[] { 5, 4, 3, 2, 1 })]
        public int[] CheckAddLinkedList(int[] array, int element)
        {
            var linkedList = new SinglyLinkedList<int>(array);
            linkedList.Add(element);
            return linkedList.ToArray();
        }

        /// <summary>
        /// Check removing an element from the list.
        /// </summary>
        /// <param name="array">Data to create a list.</param>
        /// <param name="element">Element to remove.</param>
        /// <returns>Elements in the list.</returns>
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, ExpectedResult = new int[] { 5, 4, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5, ExpectedResult = new int[] { 4, 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1, ExpectedResult = new int[] { 5, 4, 3, 2, })]
        [TestCase(new int[] { 1 }, 1, ExpectedResult = new int[] { })]
        public int[] CheckRemoveLinkedList(int[] array, int element)
        {
            var linkedList = new SinglyLinkedList<int>(array);
            Assert.That(linkedList.Remove(element), Is.True);
            return linkedList.ToArray();
        }

        /// <summary>
        /// Check removing non-existing element from the list.
        /// </summary>
        /// <param name="array">Data to create a list.</param>
        /// <param name="element">Element to remove.</param>
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 6)]
        [TestCase(new int[] { }, 1)]
        [TestCase(new int[] { 1 }, 2)]
        public void CheckRemoveNonExistingLinkedList(int[] array, int element)
        {
            var linkedList = new SinglyLinkedList<int>(array);
            Assert.That(linkedList.Remove(element), Is.False);
            var result = linkedList.ToArray();
            result.Reverse();
            Assert.That(linkedList.ToArray, Is.EqualTo(result));
        }

        /// <summary>
        /// Check finding an element from the list.
        /// </summary>
        /// <param name="array">Data to create a list.</param>
        /// <param name="element">Element to find.</param>
        /// <returns>True if the alament is found.</returns>
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, ExpectedResult = true)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 6, ExpectedResult = false)]
        [TestCase(new int[] { }, 1, ExpectedResult = false)]
        [TestCase(new int[] { 1 }, 1, ExpectedResult = true)]
        [TestCase(new int[] { 1 }, 0, ExpectedResult = false)]
        public bool CheckContainsLinkedList(int[] array, int element)
        {
            var linkedList = new SinglyLinkedList<int>(array);
            return linkedList.Contains(element);
        }

        /// <summary>
        /// Checking enumerator.
        /// </summary>
        /// <param name="array">Array to create a set.</param>
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void CheckLinkedListEnumerator(int[] array)
        {
            var linkedList = new SinglyLinkedList<int>(array);
            var list = new List<int>();
            foreach (var item in linkedList)
            {
                list.Add(item);
            }

            Assert.That(linkedList.ToArray(), Is.EqualTo(list.ToArray()));
        }
    }
}
