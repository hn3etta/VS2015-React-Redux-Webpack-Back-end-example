using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BackendStarter.Models;
using BackendStarter.Repos;

namespace BackendStarter.Controllers
{
	[Route("api/[controller]")]
	public class CoursesController : Controller
	{
		private readonly ICourseRepo courses;
		private readonly JsonSerializerSettings _serializerSettings;

		public CoursesController(ICourseRepo courseRepo)
		{
			courses = courseRepo;
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
			return new OkObjectResult(courses.GetAll());
		}

		// Add a new Course
		[HttpPost]
		[EnableCors("AllowAll")]
		[Authorize(Policy = "BaselineAPI")]
		public IActionResult Post([FromBody] Course course)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Invalid Course Model");
			}

			var result = courses.Add(course);

			if (result == null)
			{
				return new NotFoundResult();
			}

			return new CreatedResult("/course/post", result);
		}

		// Update a Course
		[HttpPut]
		[EnableCors("AllowAll")]
		[Authorize(Policy = "BaselineAPI")]
		public IActionResult Put([FromBody] Course course)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Invalid Course Model");
			}

			var result = courses.Save(course);

			if (result == null)
			{
				return new NotFoundResult();
			}

			return new OkObjectResult(result);
		}

		// Delete a Course
		[HttpDelete("{id}")]
		[EnableCors("AllowAll")]
		[Authorize(Policy = "BaselineAPI")]
		public IActionResult Delete(int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Invalid Course Model");
			}

			var result = courses.Delete(id);

			if (!result)
			{
				return NoContent();
			}

			return new OkResult();
		}
	}
}
