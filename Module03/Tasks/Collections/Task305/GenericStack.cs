// <copyright file="GenericStack.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Collections.Task305
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Test 5.
    /// Develop a generic class-collection Stack that implements the basic operations for working with the structure data stack.
    /// Implement the capability to iterate by collection by design pattern Iterator.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the queue.</typeparam>
    public class GenericStack<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 100;
        private T[] items;
        private int end = -1;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericStack{T}"/> class.
        /// </summary>
        public GenericStack()
        {
            this.items = new T[InitialCapacity];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericStack{T}"/> class.
        /// </summary>
        /// <param name="items">The array whose elements are copied to the new Stack.</param>
        public GenericStack(T[] items)
        {
            this.Initialize(items);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericStack{T}"/> class.
        /// </summary>
        /// <param name="items">The collection whose elements are copied to the new GenericStack.</param>
        public GenericStack(IEnumerable<T> items)
        {
            this.Initialize(items.ToArray());
        }

        /// <summary>
        /// Gets the number of elements.
        /// </summary>
        public int Count => this.end + 1;

        /// <summary>
        /// Removes and returns the object at the top of the GenericStack.
        /// </summary>
        /// <returns>The object removed from the top.</returns>
        public T Pop() => this.Count > 0 ? this.items[this.end--] : throw new InvalidOperationException();

        /// <summary>
        /// Returns the object at the top of the GenericStack without removing it.
        /// </summary>
        /// <returns>The object from the top.</returns>
        public T Peek() => this.Count > 0 ? this.items[this.end] : throw new InvalidOperationException();

        /// <summary>
        /// Inserts an object at the top of the GenericStack.
        /// </summary>
        /// <param name="item">An element to add.</param>
        public void Push(T item)
        {
            if (this.end >= this.items.Length - 1)
            {
                this.AddCapacity(InitialCapacity);
            }

            this.items[++this.end] = item;
        }

        /// <summary>
        ///  Removes all objects from the GenericStack.
        /// </summary>
        public void Clear() => this.end = -1;

        /// <summary>
        /// Copies the elements to a new array.
        /// </summary>
        /// <returns>A new array containing elements of the GenericStack.</returns>
        public T[] ToArray()
        {
            T[] array = new T[this.Count];
            Array.Copy(this.items, array, this.Count);
            return array;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the GenericStack.
        /// </summary>
        /// <returns>An enumerator for the GenericStack.</returns>
        public IEnumerator<T> GetEnumerator() => new Enumerator(this);

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private void AddCapacity(int size)
        {
            int count = this.Count;
            T[] array = new T[count + size];
            Array.Copy(this.items, array, count);
            this.items = array;
            this.end = count - 1;
        }

        private void Initialize(T[] array)
        {
            int length = array.Length;
            this.items = new T[length + InitialCapacity];
            Array.Copy(array, this.items, length);
            this.end = length - 1;
        }

        private class Enumerator : IEnumerator<T>
        {
            private readonly T[] items;
            private int currentIndex = -1;

            public Enumerator(GenericStack<T> items)
            {
                this.items = items.ToArray();
            }

            public T Current => this.IndexIsInRange() ? this.items[this.currentIndex] : throw new InvalidOperationException("Index out of range");

            object IEnumerator.Current => this.IndexIsInRange() ? this.items[this.currentIndex] : throw new InvalidOperationException("Index out of range");

            public void Dispose()
            {
            }

            public bool MoveNext() => ++this.currentIndex < this.items.Length;

            public void Reset() => this.currentIndex = -1;

            private bool IndexIsInRange() => this.currentIndex > -1 && this.currentIndex < this.items.Length;
        }
    }
}
