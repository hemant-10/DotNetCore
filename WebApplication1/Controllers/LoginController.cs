using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {
        //[Route("")] This is Empty action for the controller
        public IActionResult Index()
        {
            return View();
        }

        [Route("Address")]
        public IActionResult Address()
        {
            return View();
        }
    }
}