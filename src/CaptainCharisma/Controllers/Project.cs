using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CaptainCharisma.Controllers
{
    public class Project : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
