// <copyright file="Task302.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Implement an algorithm that allows to determine the frequency of occurrences of words in the text.
    /// </summary>
    public static class Task302
    {
        /// <summary>
        /// Counts the frequency of occurrences of words in the text.
        /// </summary>
        /// <param name="text">Text.</param>
        /// <returns>Key-value pairs. Key - word, value - number of occurrences.</returns>
        public static IDictionary<string, int> WordCount(string text)
        {
            // Convert the string into an array of words.
            string[] source = text.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);

            var wordList = source.Select(w => w.Trim().ToLowerInvariant());

            var frequency = new Dictionary<string, int>();

            foreach (var word in wordList)
            {
                if (frequency.ContainsKey(word))
                {
                    frequency[word] += 1;
                }
                else
                {
                    frequency[word] = 1;
                }
            }

            return frequency;
        }
    }
}
