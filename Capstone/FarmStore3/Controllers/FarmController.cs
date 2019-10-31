using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmStore3.Controllers
{
    public class FarmController : Controller
    {
        public IActionResult Produce()
        {
            return View();
        }
        public IActionResult AddProduce()
        {
            return View();
        }

    }
}
