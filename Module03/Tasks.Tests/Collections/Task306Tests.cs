// <copyright file="Task306Tests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Tests.Collections
{
    using System.Collections.Generic;
    using NUnit.Framework;
    using Tasks.Collections.Task306;

    /// <summary>
    /// Tests for Task 6.
    /// </summary>
    public class Task306Tests
    {
        /// <summary>
        /// Checking adding a new element to a set.
        /// </summary>
        /// <param name="array">Array to create a set.</param>
        /// <param name="element">An element to add.</param>
        /// <returns>Elements after adding.</returns>
        [TestCase(new int[] { }, 1, ExpectedResult = new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 }, 4, ExpectedResult = new int[] { 1, 2, 3, 4 })]
        public int[] CheckAddNewElementToSet(int[] array, int element)
        {
            var set = new GenericSet<int>(array);
            Assert.That(set.Add(element), Is.True);
            return set.ToArray();
        }

        /// <summary>
        /// Checking adding an existing element to the set.
        /// </summary>
        /// <param name="array">Array to create a set.</param>
        /// <param name="element">An element to add.</param>
        /// <returns>Elements after adding.</returns>
        [TestCase(new int[] { 1, 2, 3 }, 3, ExpectedResult = new int[] { 1, 2, 3 })]
        public int[] CheckAddExistingElementToSet(int[] array, int element)
        {
            var set = new GenericSet<int>(array);
            Assert.That(set.Add(element), Is.False);
            return set.ToArray();
        }

        /// <summary>
        /// Checking removing the existing element from the set.
        /// </summary>
        /// <param name="array">Array to create a set.</param>
        /// <param name="element">An element to remove.</param>
        /// <returns>Elements after removing.</returns>
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, ExpectedResult = new int[] { 1, 2, 4, 5 })]
        public int[] CheckRemoveExistingElementFromSet(int[] array, int element)
        {
            var set = new GenericSet<int>(array);
            Assert.That(set.Remove(element), Is.True);
            return set.ToArray();
        }

        /// <summary>
        /// Checking removing the non-existing element from the set.
        /// </summary>
        /// <param name="array">Array to create a set.</param>
        /// <param name="element">An element to remove.</param>
        /// <returns>Elements after removing.</returns>
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 6, ExpectedResult = new int[] { 1, 2, 3, 4, 5 })]
        public int[] CheckRemoveNonExistingElementFromSet(int[] array, int element)
        {
            var set = new GenericSet<int>(array);
            Assert.That(set.Remove(element), Is.False);
            return set.ToArray();
        }

        /// <summary>
        /// Checking counting the elements in the set.
        /// </summary>
        /// <param name="array">Array to create a set.</param>
        /// <returns>Number of elements in the set.</returns>
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, ExpectedResult = 5)]
        public int CheckElementsCount(int[] array)
        {
            var set = new GenericSet<int>(array);
            return set.Count;
        }

        /// <summary>
        /// Checking clearing the set.
        /// </summary>
        /// <param name="array">Array to create a set.</param>
        [TestCase(new int[] { 1, 2, 3 })]
        public void CheckClearSet(int[] array)
        {
            var set = new GenericSet<int>(array);
            set.Clear();
            Assert.That(set.ToArray, Is.EqualTo(new int[] { }));
        }

        /// <summary>
        /// Checking whether the Set contains the specified element.
        /// </summary>
        /// <param name="array">Array to create a set.</param>
        /// <param name="element">The element to locate.</param>
        /// <returns>True if the set contains the specified element.</returns>
        [TestCase(new int[] { 1, 2, 3 }, 3, ExpectedResult = true)]
        public bool CheckContains(int[] array, int element)
        {
            var set = new GenericSet<int>(array);
            return set.Contains(element);
        }

        /// <summary>
        /// Checking enumerator.
        /// </summary>
        /// <param name="array">Array to create a set.</param>
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void CheckSetEnumerator(int[] array)
        {
            var set = new GenericSet<int>(array);
            var list = new List<int>();
            foreach (var item in set)
            {
                list.Add(item);
            }

            Assert.That(set.ToArray(), Is.EqualTo(list.ToArray()));
        }
    }
}
