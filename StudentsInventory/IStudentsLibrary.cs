using System.Collections.Generic;

namespace StudentsInventory
{
    public interface IStudentsLibrary
    {
        List<Student> GetStudents();
    }
}