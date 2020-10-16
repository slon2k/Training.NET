// <copyright file="Task307.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Collections
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Task 7.
    /// Develop a generic class-collection BinarySearchTree that implements the basic operations for working with the structure data binary search tree.
    /// Provide an opportunity of using a plug-in interface to implement the order relation.
    /// Implement three ways of traversing the tree: direct (preorder), transverse (inorder), reverse (postorder).
    /// </summary>
    public class Task307
    {
        /// <summary>
        /// Binary Search Tree.
        /// </summary>
        /// <typeparam name="T">Specifies the type of elements.</typeparam>
        public class BinarySearchTree<T>
        {
            /// <summary>
            /// Comparer for T.
            /// </summary>
            private readonly Comparer<T> comparer;

            /// <summary>
            /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
            /// </summary>
            /// <param name="comparer">Comparer for T.</param>
            public BinarySearchTree(Comparer<T> comparer = null)
            {
                if (comparer == null)
                {
                    try
                    {
                        this.comparer = Comparer<T>.Default;
                    }
                    catch (Exception)
                    {
                        throw new ArgumentException(nameof(comparer), $"Default comparer for Type {typeof(T)} was not found");
                    }
                }

                this.Count = 0;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
            /// </summary>
            /// <param name="array">The array whose elements are added to the new tree.</param>
            /// <param name="comparer">Comparer for T.</param>
            public BinarySearchTree(T[] array, Comparer<T> comparer = null)
            {
                if (comparer == null)
                {
                    try
                    {
                        this.comparer = Comparer<T>.Default;
                    }
                    catch (Exception)
                    {
                        throw new ArgumentException(nameof(comparer), $"Default comparer for Type {typeof(T)} was not found");
                    }
                }

                this.Count = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    this.Add(array[i]);
                }
            }

            /// <summary>
            /// Ways for traversing the tree.
            /// </summary>
            public enum Traversal
            {
                /// <summary>
                /// Preorder (Root, Left, Right).
                /// </summary>
                Direct = 0,

                /// <summary>
                ///  Inorder (Left, Root, Right).
                /// </summary>
                Inorder = 1,

                /// <summary>
                /// Postorder (Left, Right, Root).
                /// </summary>
                Postorder = 3,
            }

            /// <summary>
            /// Gets root node.
            /// </summary>
            public Node Root { get; private set; }

            /// <summary>
            /// Gets the number of elements that are contained in the tree.
            /// </summary>
            public int Count { get; private set; }

            /// <summary>
            /// Adds an element to the tree.
            /// </summary>
            /// <param name="item">The element to add.</param>
            /// <returns>True if the element was added. False if the element already exists.</returns>
            public bool Add(T item)
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item));
                }

                if (this.Root == null)
                {
                    this.Root = new Node(item);
                    this.Count++;
                    return true;
                }

                return this.Insert(this.Root, item);
            }

            /// <summary>
            /// Determines whether the tree contains the specified element.
            /// </summary>
            /// <param name="item">The element to find.</param>
            /// <returns>True if the tree contains the specified element.</returns>
            public bool Contains(T item)
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item));
                }

                return this.FindNodeOrDefault(item) == null ? false : true;
            }

            /// <summary>
            /// Removes the specified element.
            /// </summary>
            /// <param name="item">The element to remove.</param>
            /// <returns>True if the element is successfully found and removed; otherwise, false.</returns>
            public bool Remove(T item)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Removes all elements.
            /// </summary>
            public void Clear()
            {
                this.Root = null;
                this.Count = 0;
            }

            /// <summary>
            /// Gets elements in the tree in specified order.
            /// </summary>
            /// <param name="order">Traversal order.</param>
            /// <returns>Elements in specified order.</returns>
            public IEnumerable<T> Items(Traversal order)
            {
                throw new NotImplementedException();
            }

            private bool Insert(Node node, T item)
            {
                if (node == null)
                {
                    throw new ArgumentNullException(nameof(node));
                }

                if (item.Equals(node.Item))
                {
                    return false;
                }

                while (true)
                {
                    if (this.comparer.Compare(item, node.Item) < 0)
                    {
                        if (node.Left == null)
                        {
                            node.Left = new Node(item);
                            this.Count++;
                            return true;
                        }

                        node = node.Left;
                    }
                    else
                    {
                        if (node.Right == null)
                        {
                            node.Right = new Node(item);
                            this.Count++;
                            return true;
                        }

                        node = node.Right;
                    }
                }
            }

            private Node FindNodeOrDefault(T item)
            {
                Node node = this.Root;

                while (node != null)
                {
                    if (item.Equals(node.Item))
                    {
                        return node;
                    }

                    if (this.comparer.Compare(item, node.Item) < 0)
                    {
                        node = node.Left;
                    }
                    else
                    {
                        node = node.Right;
                    }
                }

                return null;
            }

            /// <summary>
            /// Tree node.
            /// </summary>
            public class Node
            {
                /// <summary>
                /// Initializes a new instance of the <see cref="Node"/> class.
                /// </summary>
                /// <param name="item">Element.</param>
                public Node(T item)
                {
                    this.Item = item;
                }

                /// <summary>
                /// Gets or sets left node.
                /// </summary>
                public Node Left { get; set; }

                /// <summary>
                /// Gets or sets right node.
                /// </summary>
                public Node Right { get; set; }

                /// <summary>
                /// Gets element.
                /// </summary>
                public T Item { get; }
            }
        }
    }
}
