﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BackendStarter.Repos;

namespace BackendStarter.Controllers
{
	[Route("api/[controller]")]
	public class AuthorsController : Controller
	{
		private readonly IAuthorRepo authors;
		private readonly JsonSerializerSettings _serializerSettings;

		public AuthorsController(IAuthorRepo authorRepo)
		{
			authors = authorRepo;
			_serializerSettings = new JsonSerializerSettings
			{
				Formatting = Formatting.Indented
			};
		}

		[HttpGet]
		[EnableCors("AllowAll")]
		[Authorize(Policy = "BaselineAPI")]
		public IActionResult Get()
		{
			return new OkObjectResult(authors.GetAll());
		}
	}
}
