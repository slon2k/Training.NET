// <copyright file="Task307Tests.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Tests.Collections
{
    using System.Linq;
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
            // Removing left leaf.
            var tree = new BinarySearchTree<int>(new int[] { 5, 3, 7 });

            Assert.That(tree.Remove(3), Is.EqualTo(true));
            Assert.That(tree.Remove(3), Is.EqualTo(false));

            Assert.That(tree.Root.Left, Is.Null);
            Assert.That(tree.Count, Is.EqualTo(2));

            // Removing right leaf.
            tree = new BinarySearchTree<int>(new int[] { 5, 3, 7 });
            tree.Remove(7);

            Assert.That(tree.Root.Right, Is.Null);
            Assert.That(tree.Count, Is.EqualTo(2));

            // Removing root with one child
            tree.Remove(5);
            Assert.That(tree.Root.Item, Is.EqualTo(3));

            // Removing root with two children.
            tree = new BinarySearchTree<int>(new int[] { 5, 3, 7 });
            tree.Remove(5);

            Assert.That(tree.Root.Item, Is.EqualTo(7));
            Assert.That(tree.Root.Right, Is.Null);
            Assert.That(tree.Root.Left.Item, Is.EqualTo(3));

            // Removing element with two children.
            tree = new BinarySearchTree<int>(new int[] { 10, 5, 15, 13, 17, 11, 14, 16, 20 });
            Assert.That(tree.Contains(15), Is.True);
            tree.Remove(15);
            Assert.That(tree.Root.Right.Item, Is.EqualTo(16));
            Assert.That(tree.Count, Is.EqualTo(8));
            Assert.That(tree.Contains(15), Is.False);
        }

        /// <summary>
        /// Checking Inorder Traversing.
        /// </summary>
        /// <param name="array">Elements to add.</param>
        /// <returns>Result sequence.</returns>
        [TestCase(new int[] { 25, 15, 50, 10, 22, 35, 70, 4, 12, 18, 24, 31, 44, 66, 90 }, ExpectedResult = new int[] { 4, 10, 12, 15, 18, 22, 24, 25, 31, 35, 44, 50, 66, 70, 90 })]
        public int[] CheckTraversingBinarySearchTreeInorder(int[] array)
        {
            var tree = new BinarySearchTree<int>(array);
            var result = tree.Items(BinarySearchTree<int>.Traversal.Inorder).ToList();
            return result.ToArray();
        }

        /// <summary>
        /// Checking Preorder Traversing.
        /// </summary>
        /// <param name="array">Elements to add.</param>
        /// <returns>Result sequence.</returns>
        [TestCase(new int[] { 25, 15, 50, 10, 22, 35, 70, 4, 12, 18, 24, 31, 44, 66, 90 }, ExpectedResult = new int[] { 25, 15, 10, 4, 12, 22, 18, 24, 50, 35, 31, 44, 70, 66, 90 })]
        public int[] CheckTraversingBinarySearchTreePreorder(int[] array)
        {
            var tree = new BinarySearchTree<int>(array);
            var result = tree.Items(BinarySearchTree<int>.Traversal.Preorder).ToList();
            return result.ToArray();
        }

        /// <summary>
        /// Checking Postorder Traversing.
        /// </summary>
        /// <param name="array">Elements to add.</param>
        /// <returns>Result sequence.</returns>
        [TestCase(new int[] { 25, 15, 50, 10, 22, 35, 70, 4, 12, 18, 24, 31, 44, 66, 90 }, ExpectedResult = new int[] { 4, 12, 10, 18, 24, 22, 15, 31, 44, 35, 66, 90, 70, 50, 25 })]
        public int[] CheckTraversingBinarySearchTreePostorder(int[] array)
        {
            var tree = new BinarySearchTree<int>(array);
            var result = tree.Items(BinarySearchTree<int>.Traversal.Postorder).ToList();
            return result.ToArray();
        }
    }
}
