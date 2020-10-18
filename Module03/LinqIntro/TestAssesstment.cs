// <copyright file="TestAssesstment.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace LinqIntro
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Tests results.
    /// </summary>
    public class TestAssesstment
    {
        private int assesstment;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestAssesstment"/> class.
        /// </summary>
        /// <param name="student">Student.</param>
        /// <param name="subject">Subject.</param>
        /// <param name="testDate">Test date.</param>
        /// <param name="assesstment">Assesstment.</param>
        public TestAssesstment(Student student, string subject, DateTimeOffset testDate, int assesstment)
        {
            this.Student = student ?? throw new ArgumentNullException(nameof(student));
            this.Subject = subject ?? throw new ArgumentNullException(nameof(subject));
            this.TestDate = testDate;
            this.Assesstment = assesstment;
        }

        /// <summary>
        /// Gets or sets student.
        /// </summary>
        public Student Student { get; set; }

        /// <summary>
        /// Gets or sets subject.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets date of a test.
        /// </summary>
        public DateTimeOffset TestDate { get; set; }

        /// <summary>
        /// Gets or sets assesstment.
        /// </summary>
        public int Assesstment
        {
            get
            {
                return this.assesstment;
            }

            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.Assesstment));
                }

                this.assesstment = value;
            }
        }
    }
}
