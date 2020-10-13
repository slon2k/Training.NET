using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Collections
{
    /// <summary>
    /// Implement a method for the counting of the Fibonacci's numbers of the Fibonacci using the iterator block yield.
    /// </summary>
    public static class Task303
    {
        /// <summary>
        /// List of Fibonacci numbers.
        /// </summary>
        /// <param name="limit">Last index in range.</param>
        /// <returns>Fibonacci Numbers.</returns>
        public static IEnumerable<int> FibonacciNumbers(int limit)
        {
            int prev1 = 1;
            int count = 1;
            yield return 1;

            int prev2 = 1;
            count++;
            yield return 1;

            while (count < limit)
            {
                int next = prev1 + prev2;
                count++;
                prev1 = prev2;
                prev2 = next;
                yield return next;
            }
        }
    }
}
