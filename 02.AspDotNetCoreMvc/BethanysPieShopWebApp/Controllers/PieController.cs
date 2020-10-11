using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BethanysPieShopWebApp.Models;
using BethanysPieShopWebApp.ViewModels;

namespace BethanysPieShopWebApp.Controllers
{
    public class PieController : Controller
    {
        private readonly ILogger<PieController> _logger;
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(ILogger<PieController> logger, ICategoryRepository categoryRepository, IPieRepository pieRepository)
        {
            _logger = logger;
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Action method to return list of the pies
        /// </summary>
        /// <returns></returns>
        public ViewResult List()
        {
            //** instead of passing data from viewbag, better approach is use ViewModel
            //Viewbag is dynamic type
            //ViewBag.CurrentCategory = "Cheese cakes!";
            //return View(_pieRepository.AllPies);

            var viewModel = new PiesListViewModel()
            {
                Pies = _pieRepository.AllPies,
                CurrentCategory = "Cheese cakes!"
            };

            return View(viewModel);

        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //** by default view to show is index.cshtml
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
