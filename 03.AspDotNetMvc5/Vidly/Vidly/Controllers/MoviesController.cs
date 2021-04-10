using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie()
            {
                Name = "Shrek!!"
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = new List<Customer>()
                {
                    new Customer()
                    {
                        Name = "John"
                    },
                    new Customer()
                    {
                        Name = "Bob"
                    }
                }
            };

            return View(viewModel);
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}