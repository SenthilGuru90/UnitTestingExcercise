using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsInventory;

namespace StudentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentsLibrary _studentsLibrary;
        public StudentController(IStudentsLibrary studentsLibrary)
        {
            _studentsLibrary = studentsLibrary;
        }

        [HttpGet]
        public List<Student> Get()
        {
            return _studentsLibrary.GetStudents();
        }
    }
}