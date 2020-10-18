// <copyright file="StudentService.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace LinqIntro
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Student Service.
    /// </summary>
    public class StudentService
    {
        private readonly HashSet<Student> students = new HashSet<Student>();

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentService"/> class.
        /// </summary>
        /// <param name="students">Sequence of students.</param>
        public StudentService(IEnumerable<Student> students) => this.AddRange(students);

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentService"/> class.
        /// </summary>
        public StudentService()
        {
        }

        /// <summary>
        /// Gets list of students.
        /// </summary>
        /// <returns>List of all students.</returns>
        public IEnumerable<Student> GetAll() => this.students.ToList();

        /// <summary>
        /// Students who meet the specified criteria.
        /// </summary>
        /// <param name="criteria">Criteria to select students.</param>
        /// <returns>List of students who meet the specified criteria.</returns>
        public IEnumerable<Student> FindStudents(Func<Student, bool> criteria) => this.students.Where(criteria).ToList();

        /// <summary>
        /// Checks if the specified student exists in the list.
        /// </summary>
        /// <param name="student">Specified student.</param>
        /// <returns>True if the student exists in the list.</returns>
        public bool StudentExists(Student student) => this.students.Contains(student) ? true : false;

        /// <summary>
        /// Gets student by name.
        /// </summary>
        /// <param name="name">Student full name.</param>
        /// <returns>Student.</returns>
        public Student GetStudentByName(string name) => this.students.FirstOrDefault(s => s.FullName == name);

        /// <summary>
        /// Adds a student to the list.
        /// </summary>
        /// <param name="student">Student to add.</param>
        /// <returns>True if the student was added. False if this student already exists in the list.</returns>
        public bool AddStudent(Student student) => this.students.Add(student);

        /// <summary>
        /// Adds collection of students to the list.
        /// </summary>
        /// <param name="students">Students to add.</param>
        public void AddRange(IEnumerable<Student> students)
        {
            foreach (var student in students)
            {
                this.students.Add(student);
            }
        }
    }
}
