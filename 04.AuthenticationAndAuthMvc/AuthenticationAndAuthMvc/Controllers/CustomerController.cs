using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuthenticationAndAuthMvc.Models;

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
            if (User.IsInRole(RoleName.CanManageCustomers))
                return View("List");

            return View("ReadonlyList");

        }

        //below attribute is introduced, so that user with no access to NEW CUSTOMER, cannot directly navigate to 
        // api/customer/new
        //same attribute are required for all actions - Create, Edit, Delete
        [Authorize(Roles = RoleName.CanManageCustomers)]
        public ActionResult New()
        {
            return View();
        }
    }
}