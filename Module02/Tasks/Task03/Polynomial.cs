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
        private double[] coefficients;

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

            this.coefficients = new double[length];

            for (int i = 0; i < length; i++)
            {
                this.coefficients[i] = coefficients[length - 1 - i];
            }
        }

        /// <summary>
        /// Gets the the degree of the polynomial.
        /// </summary>
        public int Degree => this.coefficients.Length - 1;

        /// <summary>
        /// Polynomial expression like x^3 + 3x^2 + 3x + 1.
        /// </summary>
        /// <returns>String with expression.</returns>
        public string Expression()
        {
            if (this.Degree == 0)
            {
                return this.coefficients[0].ToString();
            }

            var str = new StringBuilder();

            for (int i = this.Degree; i >= 0; i--)
            {
                double coefficient = this.coefficients[i];

                if (coefficient != 0)
                {
                    if (coefficient < 0 || i < this.Degree)
                    {
                        str.Append(this.Sign(coefficient));
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

        private string Sign(double number) => number >= 0 ? " + " : " - ";
    }
}
