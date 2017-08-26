using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CaptainCharisma.Models;

namespace CaptainCharisma.Controllers
{
    public class ProjectController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetProject()
        {
            var allProjects = Project.GetProject();
            return View(allProjects);
        }
    }
}
