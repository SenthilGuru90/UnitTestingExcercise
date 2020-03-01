using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using FluentAssertions;
using StudentsInventory;
using StudentWebApp.Controllers;
using System.Collections.Generic;

namespace StudentWebAppTest
{
    [TestClass]
    public class StudentControllerTest
    {
        private IStudentsLibrary studentsLibrary = null;

        [TestMethod]
        public void TestMethod1()
        {
            studentsLibrary = Substitute.For<IStudentsLibrary>();

            var dummyStudents = new List<Student>()
            {
                new Student{ Id = 1, FirstName = "Student1 Fn", LastName = "Student 1 Ln", Grade = "A"},
                new Student{ Id = 2, FirstName = "Student2 Fn", LastName = "Student 2 Ln", Grade = "A"},
                new Student{ Id = 3, FirstName = "Student3 Fn", LastName = "Student 3 Ln", Grade = "A"}
            };

            studentsLibrary.GetStudents().Returns(dummyStudents);

            StudentController studentController = new StudentController(studentsLibrary);
            var httpresult = studentController.Get();
            httpresult.Should().HaveCount(3, "We passed 3 dummy positions in dummy return object");
        }
    }
}
