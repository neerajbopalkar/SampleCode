using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        List<Customer> _customers = new List<Customer>()
        {
            new Customer()
            {
                Id =1,
                Name = "John Connor",
                MembershipType = new MembershipType()
                {
                    Id = 1,
                    Name = "Monthly"
                },
                MembershipTypeId = 1,
                Birthdate = new DateTime(2002,2,2),
                IsSubscribedToNewsletter = false
            },
            new Customer()
            {
                Id =2,
                Name = "Stan Smith",
                MembershipType = new MembershipType()
                {
                    Id = 4,
                    Name = "Yearly"
                },
                MembershipTypeId = 4,
                Birthdate = new DateTime(2001,1,1),
                IsSubscribedToNewsletter = true
            }
        };

        private List<MembershipType> _membershipTypes = new List<MembershipType>()
        {
            new MembershipType()
            {
                Id = 1,
                Name = "Pay as you go"

            },
            new MembershipType()
            {
                Id = 2,
                Name = "Monthly"

            },
            new MembershipType()
            {
                Id = 3,
                Name = "Annually"

            },
            new MembershipType()
            {
                Id = 4,
                Name = "Yearly"

            }
        };
        // GET: Customers
        public ActionResult Index()
        {
            //var customers = _context.Customers.Include(c => c.MembershipType).ToList();



            return View(_customers);

        }

        public ActionResult New()
        {
            var viewModel = new CustomerFormViewModel()
            {
                //added to avoid error on validation summary:The Id field is required. 
                //the id will be initialized to 0 and won't throw error while saving
                Customer = new Customer(),
                MembershipTypes = _membershipTypes

            };
            return View("CustomerForm", viewModel);
        }

        //example of model binding.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {

            //validations. The form data passed by form is binded to customer object in a parameter
            //validations are done on basis of data annotations in Customer class
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _membershipTypes
                };

                return View("CustomerForm", viewModel);
            }

            //code to save customer here using DB context


            /*
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();*/
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            //var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            var customer = _customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = _membershipTypes,
                Customer = customer

            };
            return View("CustomerForm", viewModel);

        }
    }


}