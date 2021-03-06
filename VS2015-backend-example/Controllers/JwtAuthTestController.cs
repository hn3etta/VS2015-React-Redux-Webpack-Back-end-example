﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BackendStarter.Controllers
{
  [Route("api/test")]
  public class JwtAuthTestController : Controller
  {
    private readonly JsonSerializerSettings _serializerSettings;

    public JwtAuthTestController()
    {
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
      var response = new
      {
        made_it = "Finally Worked!"
      };

      var json = JsonConvert.SerializeObject(response, _serializerSettings);
      return new OkObjectResult(json);
    }
  }
}