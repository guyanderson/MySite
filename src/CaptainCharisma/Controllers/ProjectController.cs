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
            var projectList = Project.GetProject();
            return View("Index", projectList);
        }

        public IActionResult GetProject()
        {
            var projectList = Project.GetProject();
            return View("Index", projectList);
        }
    }
}
