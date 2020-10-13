// <copyright file="Task301Tests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Tests.Collections
{
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using Tasks.Collections.Task301;

    /// <summary>
    /// Tests for Task 1.
    /// </summary>
    [TestFixture]
    public class Task301Tests
    {
        /// <summary>
        /// Check item adding to the collection.
        /// </summary>
        /// <param name="array">Numbers to add.</param>
        /// <returns>Items in the collection.</returns>
        [TestCase(new int[] { 1, 3, 5, 4, 2 }, ExpectedResult = new int[] { 1, 2, 3, 4, 5 })]
        public int[] CheckSortedCollectionAdd(int[] array)
        {
            var collection = new SortedCollection<int>();
            foreach (var item in array)
            {
                collection.Add(item);
            }

            return collection.GetItems();
        }

        /// <summary>
        /// Check item removing from the collection.
        /// </summary>
        /// <param name="array">Items in the collection.</param>
        /// <param name="element">Element to remove.</param>
        /// <returns>Items in the collection after removing selected element.</returns>
        [TestCase(new int[] { 1, 3, 5, 4, 2 }, 3, ExpectedResult = new int[] { 1, 2, 4, 5 })]
        public int[] CheckSortedCollectionRemove(int[] array, int element)
        {
            var collection = new SortedCollection<int>();
            foreach (var item in array)
            {
                collection.Add(item);
            }

            collection.Remove(element);

            return collection.GetItems();
        }

        /// <summary>
        /// Search for a specific element.
        /// </summary>
        /// <param name="array">Items in the collection.</param>
        /// <param name="element">Element to find.</param>
        /// <returns>Index of the element or -1.</returns>
        [TestCase(new int[] { 1, 1, 2, 3, 3, 3, 4, 4, 5 }, 4, ExpectedResult = 6)]
        [TestCase(new int[] { 1, 2, 2, 3, 3, 3, 4, 4, 5 }, 1, ExpectedResult = 0)]
        [TestCase(new int[] { 1, 2, 2, 3, 3, 3, 4, 4, 5 }, 5, ExpectedResult = 8)]
        [TestCase(new int[] { 1, 1, 3, 3, 3, 3, 3, 3, 5 }, 3, ExpectedResult = 2)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, ExpectedResult = 3)]
        [TestCase(new int[] { 1, 1, 2, 3, 3, 3, 5, 5, 6 }, 4, ExpectedResult = -1)]
        public int CheckBinarySearch(int[] array, int element)
        {
            var collection = new SortedCollection<int>();

            foreach (var item in array)
            {
                collection.Add(item);
            }

            return collection.BinarySearch(element);
        }

        /// <summary>
        /// Checking iterator of the collection.
        /// </summary>
        /// <param name="array">Items to add.</param>
        /// <returns>Items in the collection.</returns>
        [TestCase(new int[] { 5, 4, 3, 2, 1 }, ExpectedResult = new int[] { 1, 2, 3, 4, 5 })]
        public int[] CheckIterator(int[] array)
        {
            var collection = new SortedCollection<int>();

            foreach (var item in array)
            {
                collection.Add(item);
            }

            var result = new List<int>();

            foreach (var item in collection)
            {
                result.Add(item);
            }

            return result.ToArray();
        }

        /// <summary>
        /// Checks using custom Comparer in SortedCollection.
        /// </summary>
        /// <param name="array">Items to add.</param>
        /// <returns>Expected sorted array.</returns>
        [TestCase(new int[] { 1, 3, 5, 4, 2 }, ExpectedResult = new int[] { 1, 2, 3, 4, 5 })]
        public int[] CheckSortedCollectionCustomSorter(int[] array)
        {
            var collection = new SortedCollection<Circle>(new CircleComparer());
            foreach (var item in array)
            {
                collection.Add(new Circle(item));
            }

            var list = collection.GetItems().Select(c => c.Radius);
            return list.ToArray();
        }

        private class CircleComparer : Comparer<Circle>
        {
            public override int Compare(Circle x, Circle y)
            {
                return x.Radius.CompareTo(y.Radius);
            }
        }

        private class Circle
        {
            public Circle(int radius)
            {
                this.Radius = radius;
            }

            public int Radius { get; set; }
        }
    }
}
