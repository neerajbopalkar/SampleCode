using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthenticationAndAuthMvc.Controllers
{
    //[Authorize]
    //use above attribute to secure all actions in class
    //but to secure entire application including home page, add line in FilterConfig class
    public class CustomerController : Controller
    {
       
       
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
    }
}