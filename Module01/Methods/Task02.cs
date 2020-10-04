// <copyright file="Task02.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Methods
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Task 2.
    /// Develop a class that allows you to perform calculations of the GCD by the Euclidean algorithm for two, three, etc. whole numbers.
    /// Add methods that implement Stein's algorithm to the developed class.
    /// </summary>
    public class Task02
    {
        /// <summary>
        /// Finding the greatest common divisor of numbers by Euclid's algorithm.
        /// </summary>
        /// <param name="numbers">Set of integers.</param>
        /// <returns>GCD.</returns>
        public static long EuclideanAlgorithm(params long[] numbers)
        {
            if (numbers.Length < 2)
            {
                throw new ArgumentException("At least two numbers needed for gcd.");
            }

            if (numbers.Length > 2)
            {
                return GcdEuclid(numbers[0], EuclideanAlgorithm(numbers[1..]));
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            long result = GcdEuclid(numbers[0], numbers[1]);
            stopwatch.Stop();
            Console.WriteLine($"Euclid's algorithm for {numbers[0]} and {numbers[1]}. Elapsed ticks: {stopwatch.ElapsedTicks}");
            return result;
        }

        /// <summary>
        /// Finding the greatest common divisor of numbers by Stein's algorithm.
        /// </summary>
        /// <param name="numbers">Set of integers.</param>
        /// <returns>GCD.</returns>
        public static long SteinAlgorithm(params long[] numbers)
        {
            if (numbers.Length < 2)
            {
                throw new ArgumentException("At least two numbers needed for gcd.");
            }

            if (numbers.Length > 2)
            {
                return GcdStein(numbers[0], SteinAlgorithm(numbers[1..]));
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            long result = GcdStein(numbers[0], numbers[1]);
            stopwatch.Stop();
            Console.WriteLine($"Stein's algorithm for {numbers[0]} and {numbers[1]}. Elapsed ticks: {stopwatch.ElapsedTicks}");
            return result;
        }

        private static long GcdEuclid(long a, long b)
        {
            if (a == 0 && b == 0)
            {
                throw new ArgumentException("Both arguments cannot equal zero.");
            }

            a = Math.Abs(a);
            b = Math.Abs(b);

            while (b > 0)
            {
                a %= b;
                long temp = a;
                a = b;
                b = temp;
            }

            return a;
        }

        private static long GcdStein(long a, long b)
        {
            if (a == 0 && b == 0)
            {
                throw new ArgumentException("Both arguments cannot equal zero");
            }

            a = Math.Abs(a);
            b = Math.Abs(b);
            int k = 1;

            while (true)
            {
                if (a == b)
                {
                    return a * k;
                }

                if (a == 0)
                {
                    return b * k;
                }

                if (b == 0)
                {
                    return a * k;
                }

                if (a == 1 || b == 1)
                {
                    return k;
                }

                while (a % 2 == 0 && b % 2 == 0)
                {
                    a /= 2;
                    b /= 2;
                    k *= 2;
                }

                while (a % 2 == 0)
                {
                    a /= 2;
                }

                while (b % 2 == 0)
                {
                    b /= 2;
                }

                if (a > b)
                {
                    a = (a - b) / 2;
                }

                if (b > a)
                {
                    b = (b - a) / 2;
                }
            }
        }
    }
}
