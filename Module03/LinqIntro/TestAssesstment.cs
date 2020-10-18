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
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        public int Id { get; set; }

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
        public int Assesstment { get; set; }
    }
}
