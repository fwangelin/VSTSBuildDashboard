using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VSTSBuildDashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : Controller
    {
        private readonly AppSettings settings;

        public APIController(AppSettings settings)
        {
            this.settings = settings;
        }
    
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }


        public IActionResult Index()
        {
            return View();
        }


    }
}