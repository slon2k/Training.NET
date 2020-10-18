// <copyright file="TestAssessmentService.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace LinqIntro
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Assesstment service.
    /// </summary>
    public class TestAssessmentService
    {
        private readonly IList<TestAssessment> assessments = new List<TestAssessment>();
        private readonly StudentService studentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestAssessmentService"/> class.
        /// </summary>
        public TestAssessmentService()
        {
            this.studentService = new StudentService();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestAssessmentService"/> class.
        /// </summary>
        /// <param name="studentService">Student Service.</param>
        public TestAssessmentService(StudentService studentService)
        {
            this.studentService = studentService;
        }

        /// <summary>
        /// Gets list of students.
        /// </summary>
        /// <returns>List of all students.</returns>
        public IEnumerable<TestAssessment> GetAll() => this.assessments;

        /// <summary>
        /// Gets assesstments according to given parameters.
        /// </summary>
        /// <param name="requestParams">Parameters of the request.</param>
        /// <returns>Ordered adn filtered list of assesstments.</returns>
        public IEnumerable<TestAssessment> GetAssessments(RequestParams requestParams)
        {
            var query = this.assessments as IEnumerable<TestAssessment>;

            if (!string.IsNullOrWhiteSpace(requestParams.Name))
            {
                query = query.Where(x => x.Student.FullName.ToLowerInvariant().Contains(requestParams.Name.ToLowerInvariant()));
            }

            if (!string.IsNullOrWhiteSpace(requestParams.Subject))
            {
                query = query.Where(x => x.Subject.ToLowerInvariant().Contains(requestParams.Subject.ToLowerInvariant()));
            }

            if (requestParams.From != null && requestParams.Till != null)
            {
                query = query.Where(x => x.TestDate >= requestParams.From && x.TestDate <= requestParams.Till);
            }

            if (requestParams.From != null)
            {
                query = query.Where(x => x.TestDate >= requestParams.From);
            }

            if (requestParams.Till != null)
            {
                query = query.Where(x => x.TestDate <= requestParams.Till);
            }

            if (!string.IsNullOrWhiteSpace(requestParams.OrderBy))
            {
                switch (requestParams.OrderBy.ToLowerInvariant())
                {
                    case "name": query = query.OrderBy(x => x.Student.FullName);
                        break;
                    case "date": query = query.OrderBy(x => x.TestDate);
                        break;
                    case "subject": query = query.OrderBy(x => x.Subject);
                        break;
                    case "assesstment": query = query.OrderBy(x => x.Assessment);
                        break;
                }
            }

            query = query.Skip((requestParams.Page - 1) * requestParams.PageSize);
            query = query.Take(requestParams.PageSize);

            return query.ToList();
        }

        /// <summary>
        /// Adds new test assessment to the list.
        /// </summary>
        /// <param name="name">Full name.</param>
        /// <param name="subject">Subject.</param>
        /// <param name="date">Date.</param>
        /// <param name="assessment">Assessment.</param>
        public void AddAssessment(string name, string subject, DateTimeOffset date, int assessment)
        {
            var student = this.studentService.GetStudentByName(name) ?? new Student(name);

            var testAssessment = new TestAssessment(student, subject, date, assessment);

            this.assessments.Add(testAssessment);
        }
    }
}
