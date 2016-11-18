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

        // Get latest Signups
        [HttpGet("{id}")]
        [EnableCors("AllowAll")]
        [Authorize(Policy = "BaselineAPI")]
        public IActionResult Get(int id)
        {
            return new OkObjectResult(_courseOpenRepo.Get(id));
        }

        // Get latest Signups for list of Courses
        [HttpGet]
        [EnableCors("AllowAll")]
        [Authorize(Policy = "BaselineAPI")]
        public IActionResult Get()
        {
            return new OkObjectResult(_courseOpenRepo.GetAll());
        }

    }
}