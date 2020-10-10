using System;
using System.Collections.Generic;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using ODataWithDotNet5Demo.Models;

namespace ODataWithDotNet5Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        [EnableQuery]
        public ActionResult<List<Student>> GetAllStudents()
        {
            return Ok(new List<Student>
            {
                new Student
                {
                    Id = Guid.NewGuid(),
                    Name = "Viral Bahen",
                    Grade = 100
                },
                new Student
                {
                    Id = Guid.NewGuid(),
                    Name = "Josh McCall",
                    Grade = 150
                },
                new Student
                {
                    Id = Guid.NewGuid(),
                    Name = "Kailu Hu",
                    Grade = 90
                }
            });
        }
    }
}
