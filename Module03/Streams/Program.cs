﻿using System;
using System.IO;
using static Streams.StreamsExtension;

namespace Streams
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceFile = "source.dat";
            string destinationFile = "destination.dat";
            string source = Path.Combine(Directory.GetCurrentDirectory(), sourceFile);
            string destination = Path.Combine(Directory.GetCurrentDirectory(), destinationFile);
            
            try
            {
                Console.WriteLine($"ByteCopy() done. Total bytes: {ByByteCopy(source, destination)}");
                Console.WriteLine($"Content is equal: {IsContentEqual(source, destination)}");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error", e.Message);
            }

            try
            {
                Console.WriteLine($"InMemoryByteCopy() done. Total bytes: {InMemoryByByteCopy(source, destination)}");
                Console.WriteLine($"Content is equal: {IsContentEqual(source, destination)}");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error", e.Message);
            }

            try
            {
                Console.WriteLine($"ByBlockCopy() done. Total bytes: {ByBlockCopy(source, destination)}");
                Console.WriteLine($"Content is equal: {IsContentEqual(source, destination)}");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error", e.Message);
            }

            try
            {
                Console.WriteLine($"InMemoryByBlockCopy() done. Total bytes: {InMemoryByBlockCopy(source, destination)}");
                Console.WriteLine($"Content is equal: {IsContentEqual(source, destination)}");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error", e.Message);
            }

            try
            {
                Console.WriteLine($"BufferedCopy() done. Total bytes: {BufferedCopy(source, destination)}");
                Console.WriteLine($"Content is equal: {IsContentEqual(source, destination)}");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error", e.Message);
            }

            try
            {
                Console.WriteLine($"ByLineCopy() done. Total lines: {ByLineCopy(source, destination)}");
                Console.WriteLine($"Content is equal: {IsContentEqual(source, destination)}");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error", e.Message);
            }

            Console.ReadLine();
        }
    }
}
