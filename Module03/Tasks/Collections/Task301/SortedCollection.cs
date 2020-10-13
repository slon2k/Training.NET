// <copyright file="SortedCollection.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Collections.Task301
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Sorted collection with binary search.
    /// </summary>
    /// <typeparam name="T">The type of elements.</typeparam>
    public class SortedCollection<T> : ISortedCollection<T>
    {
        private T[] items = { };

        /// <summary>
        /// Initializes a new instance of the <see cref="SortedCollection{T}"/> class.
        /// </summary>
        public SortedCollection()
        {
            this.Comparer = Comparer<T>.Default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SortedCollection{T}"/> class.
        /// </summary>
        /// <param name="comparer">Comparer for T.</param>
        public SortedCollection(IComparer<T> comparer)
        {
            this.Comparer = comparer;
        }

        private IComparer<T> Comparer { get; set; }

        /// <inheritdoc/>
        public T this[int index]
        {
            get => this.items[index];
        }

        /// <summary>
        /// Enumerator of the collection.
        /// </summary>
        /// <returns>Enumerator.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < this.items.Length; i++)
            {
                yield return this.items[i];
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>Enumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Add(T item)
        {
            var list = this.items.ToList();
            list.Add(item);
            this.items = list.ToArray();
            this.SortItems();
        }

        /// <inheritdoc/>
        public int BinarySearch(T element)
        {
            return this.Search(element, 0, this.items.Length - 1);
        }

        /// <inheritdoc/>
        public bool Remove(T item)
        {
            var list = this.items.ToList();
            var result = list.Remove(item);
            this.items = list.ToArray();
            this.SortItems();
            return result;
        }

        /// <summary>
        /// Sorts the collection using default Comparer.
        /// </summary>
        public void Sort()
        {
            this.Comparer = Comparer<T>.Default;
            this.SortItems();
        }

        /// <summary>
        /// Sorts the collection using new Comparer.
        /// </summary>
        /// <param name="comparer">Comparer for T.</param>
        public void Sort(IComparer<T> comparer)
        {
            this.Comparer = comparer;
            this.SortItems();
        }

        /// <summary>
        /// Gets items.
        /// </summary>
        /// <returns>Array of elements.</returns>
        public T[] GetItems() => this.items;

        private void SortItems() => Array.Sort<T>(this.items, this.Comparer);

        private int Compare(T element, int index) => this.Comparer.Compare(element, this.items[index]);

        private int Search(T element, int left, int right)
        {
            while (left < right)
            {
                int middle = left + ((right - left) / 2);
                if (this.Compare(element, middle) > 0)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle;
                }
            }

            return this.Compare(element, right) == 0 ? right : -1;
        }
    }
}
