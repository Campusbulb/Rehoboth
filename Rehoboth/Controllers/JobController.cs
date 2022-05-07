using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rehoboth.Controllers
{
    public class JobController : Controller
    {
        public IActionResult Nursingjobs()
        {
            return View();
        }

        public IActionResult MidwiferyJobs()
        {
            return View();
        }

        public IActionResult PaediatricsJobs()
        {
            return View();
        }

        public IActionResult MentalHealthJobs()
        {
            return View();
        }

        public IActionResult SocialHealthCare()
        {
            return View();
        }

        
    }
}
