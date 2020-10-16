// <copyright file="Task307Tests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Tests.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using NUnit.Framework;
    using static Tasks.Collections.Task307;

    /// <summary>
    /// Tests for Task 7.
    /// </summary>
    public class Task307Tests
    {
        /// <summary>
        /// Testing creating and adding elements to BinarySearchTree.
        /// </summary>
        [Test]
        public void CheckAddingBinarySearchTree()
        {
            var tree = new BinarySearchTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(7);
            tree.Add(2);
            tree.Add(4);

            var left = tree.Root.Left;
            var right = tree.Root.Right;

            Assert.That(tree.Root.Item, Is.EqualTo(5));
            Assert.That(left.Item, Is.EqualTo(3));
            Assert.That(right.Item, Is.EqualTo(7));
            Assert.That(left.Left.Item, Is.EqualTo(2));
            Assert.That(left.Right.Item, Is.EqualTo(4));
            Assert.That(tree.Count, Is.EqualTo(5));
        }
    }
}
