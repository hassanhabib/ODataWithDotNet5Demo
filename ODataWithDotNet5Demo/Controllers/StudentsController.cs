using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OData.Edm;
using Microsoft.OData.UriParser;
using ODataWithDotNet5Demo.Models;

namespace ODataWithDotNet5Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [Route("/{**catchAll}")]
        public ActionResult GetAllStudents(ODataQueryOptions<dynamic> options)
        {
            var edmModel = new EdmModel();
            var odataPath = new Microsoft.AspNet.OData.Routing.ODataPath(new List<ODataPathSegment>());
            var odataQueryContext = new ODataQueryContext(edmModel, typeof(int), odataPath);
            var ashtonsOptiosn = new ODataQueryOptions<Student>(odataQueryContext, this.Request);

            List<Student> students = new List<Student>
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
            };

            return Ok(options.ApplyTo(students.AsQueryable()));
        }

        private IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Student>("Students");
            builder.EntitySet<Teacher>("Teachers");
            return builder.GetEdmModel();
        }
    }
}
