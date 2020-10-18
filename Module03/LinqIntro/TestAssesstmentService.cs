// <copyright file="TestAssesstmentService.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace LinqIntro
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Assesstment service.
    /// </summary>
    public class TestAssesstmentService
    {
        private readonly IList<TestAssesstment> assesstments = new List<TestAssesstment>();
        private readonly StudentService studentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestAssesstmentService"/> class.
        /// </summary>
        public TestAssesstmentService()
        {
            this.studentService = new StudentService();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestAssesstmentService"/> class.
        /// </summary>
        /// <param name="studentService">Student Service.</param>
        public TestAssesstmentService(StudentService studentService)
        {
            this.studentService = studentService;
        }

        /// <summary>
        /// Gets list of students.
        /// </summary>
        /// <returns>List of all students.</returns>
        public IEnumerable<TestAssesstment> GetAll() => this.assesstments;

        /// <summary>
        /// Adds new test assesstment to the list.
        /// </summary>
        /// <param name="name">Full name.</param>
        /// <param name="subject">Subject.</param>
        /// <param name="date">Date.</param>
        /// <param name="assesstment">Assestment.</param>
        public void AddAssesstment(string name, string subject, DateTimeOffset date, int assesstment)
        {
            var student = this.studentService.GetStudentByName(name) ?? new Student(name);

            var testAssesstment = new TestAssesstment(student, subject, date, assesstment);

            this.assesstments.Add(testAssesstment);
        }
    }
}
