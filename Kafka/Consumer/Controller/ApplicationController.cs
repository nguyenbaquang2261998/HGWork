using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apireadiness.Controllers
{
    [Route("/")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        public async Task<IActionResult> Get() => Ok("Ok");
    }
}
