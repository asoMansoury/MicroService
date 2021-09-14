using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.Services.Activities.Controllers
{
    [Route("api/Home")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Get() => Content("Hell ofrom Actio.Services.");
    }
}
