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
        private readonly IFarmService _farmService;
        public FarmController(IFarmService productService)
        {
            _farmService = productService;
        }
        public IActionResult GetAllProduce()
        {
            var result = _farmService.GetAllProducts();
            return View(result);
        }

        public IActionResult Produce()
        {
            return View();
        }

        public IActionResult AddProduce(AddProductViewModel model)
        {
            var productsViewModel = _farmService.AddNewProduct(model);
            if (!ModelState.IsValid)
            {
                return View("Error", new ErrorViewModel
                { ErrorMessage = "Error product was not added correctly" });
            }
            else
            {
                return View("Produce", productsViewModel);
            }
        }


        public IActionResult FarmStore()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult DeletProduce()
        {
            return View();
        }

        public IActionResult UpdateProduce(int id, Products produce)
        {
            var updatedProduce = _farmService.UpdateProduce(id, produce);
            var view = _farmService.GetProducts();
            return View("Produce", view);
        }

        public IActionResult Home()
        {
            return View();
        }
    }
}
