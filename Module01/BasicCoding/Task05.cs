﻿// <copyright file="Task05.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace BasicCoding
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Task 5.
    /// Implement a method that accepts a positive integer and returns the nearest larger integer of the original number's digits.
    /// </summary>
    public static class Task05
    {
        /// <summary>
        /// Finds the nearest larger number of the original number's digits.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>Larger number of the original number's digits or -1.</returns>
        public static int FindNextBiggerNumber(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentOutOfRangeException("number must be positive");
            }

            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                var nextPermutation = NextPermutation(GetDigits(number));
                stopwatch.Stop();
                Console.WriteLine($"Next number found for {number}. Elapsed ticks: {stopwatch.ElapsedTicks}. Elapsed time: {stopwatch.Elapsed}");
                return DigitsToNumber(nextPermutation);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        // Converts number to List of digits.
        private static List<int> GetDigits(int number)
        {
            var digits = new List<int>();

            while (number > 0)
            {
                digits.Add(number % 10);
                number /= 10;
            }

            digits.Reverse();

            return digits;
        }

        // Converts List of digits to number.
        private static int DigitsToNumber(List<int> digits)
        {
            int length = digits.Count;
            int number = 0;
            for (int i = 0; i < length; i++)
            {
                number = (number * 10) + digits[i];
            }

            return number;
        }

        // Returns next lexicographical permutation or throws an exception in case of the last permutation.
        private static List<int> NextPermutation(List<int> digits)
        {
            int length = digits.Count;
            if (length == 0)
            {
                return digits;
            }

            // Looking for the last increasing element from the right.
            int i = length - 1;
            while (i > 0 && digits[i - 1] >= digits[i])
            {
                i--;
            }

            int lastIncreasing = i;

            if (lastIncreasing <= 0)
            {
                throw new Exception("This is already the last permutation.");
            }

            // Looking for greater successor of the first decreasing element.
            int j = length - 1;
            while (digits[j] <= digits[lastIncreasing - 1])
            {
                j--;
            }

            int greaterSuccessor = j;

            // Swapping the first decreasing element and it's greater successor.
            digits.Swap(lastIncreasing - 1, greaterSuccessor);

            // Reversing the suffix starting at the position of the last increasing element of the original permutation.
            // Since the suffix was in increasing order we can reverse it to get the lowest possible value.
            j = length - 1;
            i = lastIncreasing;

            while (i < j)
            {
                digits.Swap(i++, j--);
            }

            return digits;
        }

        private static void Swap(this List<int> list, int i, int j)
        {
            int length = list.Count;
            if (!i.IsInRange(0, length - 1) || !j.IsInRange(0, length - 1))
            {
                throw new ArgumentOutOfRangeException("Index is out of range.");
            }

            int temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        private static bool IsInRange(this int number, int minValue, int maxValue) => number >= minValue && number <= maxValue;
    }
}
