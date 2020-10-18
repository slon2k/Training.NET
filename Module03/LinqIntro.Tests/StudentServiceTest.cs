// <copyright file="StudentServiceTest.cs" company="Boris Korobeinikov">
// Copyright (c) Boris Korobeinikov. All rights reserved.
// </copyright>

namespace LinqIntro.Tests
{
    using System.Linq;
    using NUnit.Framework;

    /// <summary>
    /// Tests for StudentService.
    /// </summary>
    public class StudentServiceTest
    {
        private StudentService studentService;

        /// <summary>
        /// Setup service with fake data.
        /// </summary>
        [SetUp]
        public void SetupService()
        {
            this.studentService = new StudentService();
            this.studentService.AddStudent(new Student("Albus Dumbledore"));
            this.studentService.AddStudent(new Student("Aberforth Dumbledore"));
            this.studentService.AddStudent(new Student("Ariana Dumbledore"));
            this.studentService.AddStudent(new Student("Minerva McGonagall"));
            this.studentService.AddStudent(new Student("Severus Snape"));
            this.studentService.AddStudent(new Student("Godric Gryffindor"));
            this.studentService.AddStudent(new Student("Helga Hufflepuff"));
        }

        /// <summary>
        /// Testing GetStudentByName.
        /// </summary>
        [Test]
        public void CheckStudentServiceGetStudentByName()
        {
            var student = this.studentService.GetStudentByName("Albus Dumbledore");
            Assert.That(student, Is.TypeOf(typeof(Student)));
            Assert.That(student.FirstName, Is.EqualTo("Albus"));
            Assert.That(student.LastName, Is.EqualTo("Dumbledore"));

            student = this.studentService.GetStudentByName("Harry Potter");
            Assert.That(student, Is.Null);
        }

        /// <summary>
        /// Testing FindStudents.
        /// </summary>
        [Test]
        public void CheckFindStudents()
        {
            var students = this.studentService.GetAll().ToList();
            Assert.That(students.Count == 7);

            students = this.studentService.FindStudents(x => x.LastName == "Dumbledore").ToList();
            Assert.That(students.Count == 3);

            students = this.studentService.FindStudents(x => x.LastName == "Potter").ToList();
            Assert.That(students.Count == 0);
        }
    }
}
