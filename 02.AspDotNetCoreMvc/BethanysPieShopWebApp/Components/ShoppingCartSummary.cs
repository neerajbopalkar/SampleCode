using BethanysPieShopWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopWebApp.Components
{
    /// <summary>
    /// ** Partial views depend on parent view for data & C# logic
    /// View component has its own data and logic e.g.it can talk to database, use DI
    /// Shopping cart summary needs DB call to get shopping cart items, hence good candidate
    /// It is like MINI CONTROLLER
    /// </summary>
    public class ShoppingCartSummary: ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        /// <summary>
        /// ** this method is called by ASP.NET Core to render view component
        /// ** notice return type IViewComponentResult
        /// </summary>
        /// <returns></returns>
        public IViewComponentResult Invoke()
        {

            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()

            };
            //*** View name needs to be Default.cshtml
            return View(shoppingCartViewModel);
        }
    }
}
