// <copyright file="SinglyLinkedList.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Collections.Task306
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Singly Linked List.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the table.</typeparam>
    public class SinglyLinkedList<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SinglyLinkedList{T}"/> class.
        /// </summary>
        public SinglyLinkedList()
        {
            this.Head = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SinglyLinkedList{T}"/> class.
        /// </summary>
        /// <param name="array">Values to add to the list.</param>
        public SinglyLinkedList(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                this.Add(array[i]);
            }
        }

        /// <summary>
        /// Gets the first node of the list.
        /// </summary>
        public Node Head { get; private set; }

        /// <summary>
        ///  Adds an element at the beginning of the list.
        /// </summary>
        /// <param name="item">Element to add.</param>
        public void Add(T item)
        {
            var node = new Node(item, this.Head);
            this.Head = node;
        }

        /// <summary>
        /// Removes item from the list.
        /// </summary>
        /// <param name="item">Element to remove.</param>
        /// <returns>True if the element is successfully found and removed; otherwise, false.</returns>
        public bool Remove(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (this.Head != null && this.Head.Item.Equals(item))
            {
                this.Head = this.Head.Next;
                return true;
            }

            Node prev = null;
            Node current = this.Head;

            while (current != null && !current.Item.Equals(item))
            {
                prev = current;
                current = current.Next;
            }

            if (current == null)
            {
                return false;
            }

            prev.Next = current.Next;
            return true;
        }

        /// <summary>
        /// Determines whether the list contains the specified element.
        /// </summary>
        /// <param name="item">The element to locate.</param>
        /// <returns>True if the list contains the specified element.</returns>
        public bool Contains(T item)
        {
            var current = this.Head;
            while (current != null && !current.Item.Equals(item))
            {
                current = current.Next;
            }

            return current == null ? false : true;
        }

        /// <summary>
        /// Copies the elements to a new array.
        /// </summary>
        /// <returns>A new array containing elements of the list.</returns>
        public T[] ToArray()
        {
            var list = new List<T>();
            var node = this.Head;

            while (node != null)
            {
                list.Add(node.Item);
                node = node.Next;
            }

            return list.ToArray();
        }

        /// <summary>
        /// List node.
        /// </summary>
        public class Node
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Node"/> class.
            /// </summary>
            /// <param name="item">Data.</param>
            /// <param name="next">Next node.</param>
            public Node(T item, Node next = null)
            {
                this.Item = item;
                this.Next = next;
            }

            /// <summary>
            /// Gets data.
            /// </summary>
            public T Item { get; }

            /// <summary>
            /// Gets or sets next node.
            /// </summary>
            public Node Next { get; set; }
        }
    }
}
