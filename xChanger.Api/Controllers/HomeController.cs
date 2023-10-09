﻿using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace xChanger.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : RESTFulController
    {
        [HttpGet]
        public ActionResult<string> Get() =>
            Ok("Hammasi okkey");
    }
}
