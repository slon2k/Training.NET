// <copyright file="Task307.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Text;

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
            /// Gets or sets root node.
            /// </summary>
            public Node Root { get; set; }

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
