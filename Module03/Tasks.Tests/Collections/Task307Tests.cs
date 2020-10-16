// <copyright file="Task307Tests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Tests.Collections
{
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

            // Should return true if the item is successfully added.
            Assert.That(tree.Add(5), Is.EqualTo(true));
            Assert.That(tree.Add(3), Is.EqualTo(true));
            Assert.That(tree.Add(7), Is.EqualTo(true));
            Assert.That(tree.Add(2), Is.EqualTo(true));
            Assert.That(tree.Add(4), Is.EqualTo(true));

            // Should return false if the item already exists.
            Assert.That(tree.Add(5), Is.EqualTo(false));

            Assert.That(tree.Count, Is.EqualTo(5));

            var left = tree.Root.Left;
            var right = tree.Root.Right;

            Assert.That(tree.Root.Item, Is.EqualTo(5));
            Assert.That(left.Item, Is.EqualTo(3));
            Assert.That(right.Item, Is.EqualTo(7));
            Assert.That(left.Left.Item, Is.EqualTo(2));
            Assert.That(left.Right.Item, Is.EqualTo(4));

            Assert.That(tree.Contains(3), Is.EqualTo(true));
            Assert.That(tree.Contains(-3), Is.EqualTo(false));
        }

        /// <summary>
        /// Testing removing elements from BinarySearchTree.
        /// </summary>
        [Test]
        public void CheckRemoveBinarySearchTree()
        {
            var tree = new BinarySearchTree<int>();

            tree.Add(5);
            tree.Add(3);
            tree.Add(7);

            tree.Remove(3);

            Assert.That(tree.Root.Left, Is.Null);
            Assert.That(tree.Count, Is.EqualTo(2));

            tree.Clear();
            tree.Add(5);
            tree.Add(3);
            tree.Add(7);
            tree.Remove(7);

            Assert.That(tree.Root.Right, Is.Null);
            Assert.That(tree.Count, Is.EqualTo(2));

            tree.Remove(5);
            Assert.That(tree.Root.Item, Is.EqualTo(3));

            tree.Clear();
            tree.Add(5);
            tree.Add(3);
            tree.Add(7);

            tree.Remove(5);
            Assert.That(tree.Root.Item, Is.EqualTo(7));
            Assert.That(tree.Root.Right, Is.Null);
            Assert.That(tree.Root.Left.Item, Is.EqualTo(3));



        }
    }
}
