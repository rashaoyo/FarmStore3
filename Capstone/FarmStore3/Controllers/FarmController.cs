using FarmStore3.FarmServices;
using FarmStore3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmStore3.Controllers
{
    public class FarmController : Controller
    {
        private readonly IFarmService _FarmService;

        public IActionResult Produce()
        {
            return View();
        }
        public IActionResult AddProduce()
        {
            return View();
        }

        public IActionResult UpdateProduce(int id, Products produce)
        {
            var updatedProduce = _FarmService.UpdateProduce(id, produce);
            var view = _FarmService.GetProducts();
            return View("Produce", view);
        }

    }
}
