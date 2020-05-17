using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CovidNet.Controllers
{
    [Authorize(Roles = Pages.MainMenu.State.RoleName)]
    public class StateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}