using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BackendStarter.Models;
using BackendStarter.Repos;

namespace BackendStarter.Controllers
{
	[Route("api/[controller]")]
	public class CourseOpenController : Controller
	{
		private readonly ICourseOpenRepo openCourses;
		private readonly JsonSerializerSettings _serializerSettings;

		public CourseOpenController(ICourseOpenRepo openCoursesRepo)
		{
			openCourses = openCoursesRepo;
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
			return new OkObjectResult(openCourses.GetAll());
		}

		// Get latest Signups
		[HttpGet("{id}")]
		[EnableCors("AllowAll")]
		[Authorize(Policy = "BaselineAPI")]
		public IActionResult Get(int id)
		{
			return new OkObjectResult(openCourses.Get(id));
		}

		// Update a Course Open
		[HttpPost]
		[EnableCors("AllowAll")]
		[Authorize(Policy = "BaselineAPI")]
		public IActionResult Post([FromBody] OpenCourse openCourse)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Invalid Course Open Model");
			}

			var result = openCourses.Add(openCourse);

			if (result == null)
			{
				return new NotFoundResult();
			}

			return new CreatedResult("/courseopen/post", openCourse);
		}

		// Delete a Course
		[HttpDelete("{id}")]
		[EnableCors("AllowAll")]
		[Authorize(Policy = "BaselineAPI")]
		public IActionResult Delete(int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Invalid Course Open Model");
			}

			var result = openCourses.Delete(id);

			if (!result)
			{
				return NoContent();
			}

			return new OkResult();
		}
	}
}
