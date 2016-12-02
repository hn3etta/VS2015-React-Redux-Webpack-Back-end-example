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
    public class CourseOpenController : Controller
    {
        private readonly ICourseOpenRepo _courseOpenRepo;
        private readonly JsonSerializerSettings _serializerSettings;

        public CourseOpenController(ICourseOpenRepo SignupsRepo)
        {
            _courseOpenRepo = SignupsRepo;
            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
        }

        // Get latest Signups for list of Courses
        [HttpGet]
        [EnableCors("AllowAll")]
        [Authorize(Policy = "BaselineAPI")]
        public IActionResult Get()
        {
            return new OkObjectResult(_courseOpenRepo.GetAll());
        }

        // Get latest Signups
        [HttpGet("{id}")]
        [EnableCors("AllowAll")]
        [Authorize(Policy = "BaselineAPI")]
        public IActionResult Get(int id)
        {
            return new OkObjectResult(_courseOpenRepo.Get(id));
        }

        // Update a Course Open
        [HttpPost]
        [EnableCors("AllowAll")]
        [Authorize(Policy = "BaselineAPI")]
        public IActionResult Post([FromBody] CourseOpen openCourse)
        {
            if (ModelState.IsValid)
            {
                int id = _courseOpenRepo.SetCourseOpen(openCourse);
                if (id > 0)
                {
                    openCourse.Id = id;
                    return new CreatedResult("/courseopen/post", openCourse);
                }
                else
                {
                    return new NotFoundResult();
                }

            }

            return BadRequest("Invalid Course Open Model");
        }


        // Delete a Course
        [HttpDelete("{id}")]
        [EnableCors("AllowAll")]
        [Authorize(Policy = "BaselineAPI")]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                if (_courseOpenRepo.DeleteCourseOpen(id))
                {
                    return new OkResult();
                }
                else
                {
                    return NoContent();
                }
            }

            return BadRequest("Invalid Course Open Model");
        }
    }
}