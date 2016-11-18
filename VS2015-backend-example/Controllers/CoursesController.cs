using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using BackendStarter.Models;
using BackendStarter.Repos;

namespace BackendStarter.Controllers
{
    [Route("api/[controller]")]
    public class CoursesController : Controller
    {
        private readonly ICourseRepo _courseRepo;
        private readonly JsonSerializerSettings _serializerSettings;

        public CoursesController(ICourseRepo courseRepo)
        {
            _courseRepo = courseRepo;
            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
        }

        // Get all courses
        [HttpGet]
        [EnableCors("AllowAll")]
        [Authorize(Policy = "BaselineAPI")]
        public IActionResult Get()
        {
            return new OkObjectResult(_courseRepo.GetAll());
        }

        // Add a new Course
        [HttpPost]
        [EnableCors("AllowAll")]
        [Authorize(Policy = "BaselineAPI")]
        public IActionResult Post([FromBody] Course course)
        {
            if (ModelState.IsValid)
            {
                int newId = _courseRepo.Add(course);
                if (newId >= 0)
                {
                    course.Id = newId;
                    return new CreatedResult("/course/post", course);
                }
                else
                {
                    return new NotFoundResult();
                }
                
            }

            return BadRequest("Invalid Course Model");
        }

        // Update a Course
        [HttpPut]
        [EnableCors("AllowAll")]
        [Authorize(Policy = "BaselineAPI")]
        public IActionResult Put([FromBody] Course course)
        {
            if (ModelState.IsValid)
            {
                if (_courseRepo.Save(course))
                {
                    return new OkObjectResult(course);
                }
                else
                {
                    return new NotFoundResult();
                }
            }

            return BadRequest("Invalid Course Model");
        }

        // Delete a Course
        [HttpDelete("{id}")]
        [EnableCors("AllowAll")]
        [Authorize(Policy = "BaselineAPI")]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                if (_courseRepo.Delete(id))
                {
                    return new OkResult();
                }
                else
                {
                    return NoContent();
                }
            }

            return BadRequest("Invalid Course Model");
        }
    }
}