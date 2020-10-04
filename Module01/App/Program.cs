// <copyright file="Program.cs" company="Boris Korobeinikov">
//  Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace App
{
    using System;

    /// <summary>
    /// Starting point for application.
    /// </summary>
    internal class Program
    {
        private static void Main()
        {
            BasicCoding.Task05.FindNextBiggerNumber(1231881231);
            Methods.Task02.EuclideanAlgorithm((1L << 25) - (1L << 7) - 500, 1L << 50);
            Methods.Task02.SteinAlgorithm((1L << 25) - (1L << 7) - 500, 1L << 50);
        }
    }
}
