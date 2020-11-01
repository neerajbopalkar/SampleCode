using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShopWebApp.Models;
using BethanysPieShopWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public HomeController(IPieRepository pieRepository)
        {
         
            _pieRepository = pieRepository;
            
        }
        public IActionResult Index()
        {
            //return View();

            var homeViewModel = new HomeViewModel
            {
                PiesOfTheWeek = _pieRepository.PiesOfTheWeek
            };

            return View(homeViewModel);
        }
    }
}
