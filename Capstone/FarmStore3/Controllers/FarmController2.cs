using FarmStore3.FarmServices;
using FarmStore3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmStore3.Controllers
{
    public class FarmController2 : Controller
    {
        private readonly IFarmService _farmService;

        public FarmController2(IFarmService productService)
        {
            _farmService = productService;
        }
        public IActionResult GetAllProduce()
        {
            var result = _farmService.GetAllProducts();
            return View(result);
        }
        public IActionResult AddProduct()
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

        public IActionResult GetProduct()
        {
            return View();
        }

        public IActionResult FarmStoreView()
        {
            return View();
        }

        public IActionResult CartView()
        {
            return View();
        }

        public IActionResult Home()
        {
            return View();
        }

    }
}
