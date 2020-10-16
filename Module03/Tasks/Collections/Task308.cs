// <copyright file="Task308.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Collections
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Task 8.
    /// Create a calculator which evaluates expressions in Reverse Polish notation.
    /// Assume that there are always spaces between numbers and operations.
    /// Empty expression should evaluate to 0.
    /// Valid operations are +, -, *, /.
    /// </summary>
    public static class Task308
    {
        private static readonly Stack<double> NumbersStack = new Stack<double>();

        private static readonly List<string> Operations = new List<string> { "+", "-", "*", "/" };

        /// <summary>
        /// Evaluates expressions in Reverse Polish notation.
        /// </summary>
        /// <param name="expression">Expression to evaluate.</param>
        /// <returns>Calculated value.</returns>
        public static double CalculateExpression(string expression)
        {
            NumbersStack.Clear();
            var data = expression.Split();

            foreach (var item in data)
            {
                HandleItem(item);
            }

            return GetNumber();
        }

        private static void HandleItem(string item)
        {
            if (Operations.Contains(item))
            {
                HandleOperation(item);
                return;
            }

            if (!double.TryParse(item, out double number))
            {
                throw new ArgumentException("Invalid string.");
            }

            NumbersStack.Push(number);
        }

        private static void HandleOperation(string item)
        {
            switch (item)
            {
                case "+": Add();
                    break;
                case "-":
                    Subtract();
                    break;
                case "*":
                    Multiply();
                    break;
                case "/":
                    Divide();
                    break;
                default: throw new ArgumentException("Unknown operation");
            }
        }

        private static void Divide()
        {
            double a = GetNumber();
            if (a == 0)
            {
                throw new ArithmeticException("Division by zero error");
            }

            double b = GetNumber();
            NumbersStack.Push(b / a);
        }

        private static void Multiply()
        {
            double a = GetNumber();
            double b = GetNumber();
            NumbersStack.Push(b * a);
        }

        private static void Subtract()
        {
            double a = GetNumber();
            double b = GetNumber();
            NumbersStack.Push(b - a);
        }

        private static void Add()
        {
            double a = GetNumber();
            double b = GetNumber();
            NumbersStack.Push(b + a);
        }

        private static double GetNumber()
        {
            try
            {
                return NumbersStack.Pop();
            }
            catch (InvalidOperationException)
            {
                return 0;
            }
        }
    }
}
