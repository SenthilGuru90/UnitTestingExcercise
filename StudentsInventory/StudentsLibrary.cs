using System;
using System.Collections.Generic;

namespace StudentsInventory
{
    public class StudentsLibrary : IStudentsLibrary
    {
        public List<Student> GetStudents()
        {
            return new List<Student>()
            {
                new Student() { Id =1, FirstName = "Senthilmurugan", LastName="Gurusamy", Grade="A"},
                new Student() { Id =2, FirstName = "Moses", LastName="Brightson", Grade="A"},
                new Student() { Id =3, FirstName = "Shameer", LastName="Hameed", Grade="A"}
            };
        }
    }
}
