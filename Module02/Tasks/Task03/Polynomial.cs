// <copyright file="Polynomial.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace Tasks.Task03
{
    using System;
    using System.Text;

    /// <summary>
    /// A polynomial in a single indeterminate.
    /// </summary>
    public class Polynomial
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class.
        /// </summary>
        /// <param name="coefficients">Coefficients.</param>
        public Polynomial(params double[] coefficients)
        {
            if (coefficients == null)
            {
                throw new ArgumentNullException(nameof(coefficients));
            }

            if (coefficients.Length == 0)
            {
                throw new ArgumentException("At least one coefficient is required for a polynomial");
            }

            if (coefficients.Length > 1 && coefficients[0] == 0)
            {
                throw new ArgumentException("The first coefficient must not be 0");
            }

            int length = coefficients.Length;

            this.Coefficients = new double[length];

            for (int i = 0; i < length; i++)
            {
                this.Coefficients[i] = coefficients[length - 1 - i];
            }
        }

        /// <summary>
        /// Gets coefficients.
        /// </summary>
        public double[] Coefficients { get; }

        /// <summary>
        /// Gets the the degree of the polynomial.
        /// </summary>
        public int Degree => this.Coefficients.Length - 1;

        /// <summary>
        /// Overload of + operator.
        /// </summary>
        /// <param name="p">Polynomial.</param>
        /// <returns>Same Polynomial.</returns>
        public static Polynomial operator +(Polynomial p) => p;

        /// <summary>
        /// Overload of + operator.
        /// </summary>
        /// <param name="p1">Polynomial 1.</param>
        /// <param name="p2">Polynomial 2.</param>
        /// <returns>Sum of Polynomials.</returns>
        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            int degree = Math.Max(p1.Degree, p2.Degree);
            var coefficients = new double[degree + 1];
            var coefficients1 = p1.Coefficients;
            var coefficients2 = p2.Coefficients;

            for (int i = 0; i <= degree; i++)
            {
                double c1 = i < coefficients1.Length ? coefficients1[i] : 0;
                double c2 = i < coefficients2.Length ? coefficients2[i] : 0;
                coefficients[i] = c1 + c2;
            }

            Reverse(coefficients);

            int index = NonZeroIndex(coefficients);

            if (index == -1)
            {
                return new Polynomial(0);
            }

            return new Polynomial(coefficients[index..coefficients.Length]);
        }

        /// <summary>
        /// Overload of - operator.
        /// </summary>
        /// <param name="p">Polynomial.</param>
        /// <returns>Same Polynomial.</returns>
        public static Polynomial operator -(Polynomial p)
        {
            var coefficients = p.GetCoefficients();
            var inversed = Inverse(coefficients);
            return new Polynomial(inversed);
        }

        /// <summary>
        /// Gets the coefficients.
        /// </summary>
        /// <returns>Coefficients.</returns>
        public double[] GetCoefficients()
        {
            int length = this.Coefficients.Length;

            var coefficients = new double[length];

            for (int i = 0; i < length; i++)
            {
                coefficients[i] = this.Coefficients[length - 1 - i];
            }

            return coefficients;
        }

        /// <summary>
        /// Polynomial expression like x^3 + 3x^2 + 3x + 1.
        /// </summary>
        /// <returns>String with expression.</returns>
        public string Expression()
        {
            if (this.Degree == 0)
            {
                return this.Coefficients[0].ToString();
            }

            var str = new StringBuilder();

            for (int i = this.Degree; i >= 0; i--)
            {
                double coefficient = this.Coefficients[i];

                if (coefficient != 0)
                {
                    if (coefficient < 0 || i < this.Degree)
                    {
                        str.Append(Sign(coefficient));
                    }

                    if (i == 0 || coefficient != 1)
                    {
                        str.Append(Math.Abs(coefficient));
                    }

                    if (i > 0)
                    {
                        str.Append("x");
                    }

                    if (i > 1)
                    {
                        str.Append($"^{i}");
                    }
                }
            }

            return str.ToString();
        }

        private static void Reverse(double[] array)
        {
            int i = 0;
            int j = array.Length - 1;
            while (i < j)
            {
                double temp = array[i];
                array[i] = array[j];
                array[j] = temp;
                i++;
                j--;
            }
        }

        private static string Sign(double number) => number >= 0 ? " + " : " - ";

        private static double[] Inverse(double[] array)
        {
            int length = array.Length;
            var inversed = new double[length];
            for (int i = 0; i < length; i++)
            {
                inversed[i] = -array[i];
            }

            return inversed;
        }

        private static int NonZeroIndex(double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != 0)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
