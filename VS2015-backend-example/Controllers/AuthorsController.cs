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
    public class AuthorsController : Controller
    {
        private readonly IAuthorRepo _authorRepo;
        private readonly JsonSerializerSettings _serializerSettings;

        public AuthorsController(IAuthorRepo authorRepo)
        {
            _authorRepo = authorRepo;
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
            return new OkObjectResult(_authorRepo.GetAll());
        }
    }
}