using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Apis
{
    public class CustomersController : ApiController
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

        //GET /api/customers
        //** convention based routing, Get in method name identifies that it is HTTP GET request
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _customers.Select(Mapper.Map<Customer, CustomerDto>);
        }

        //GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);

            if (customer == null)
            {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            }

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        //POST /api/customers
        [HttpPost]
        //public CustomerDto CreateCustomer(CustomerDto customerDto)
        //use IHttpActionResult to return proper result type i.e. 201 Created. Earlier it returned 200 OK.
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {

            if (!ModelState.IsValid)
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            //code here to add the customer in database


            customerDto.Id = customer.Id;
            //return customerDto;

            //returns resource location → /api/customers/1
            return Created(Request.RequestUri + $"/{customerDto.Id}", customerDto);
        }

        //PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {

            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _customers.FirstOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            //use automapper here for automatic mapping of properties
            Mapper.Map(customerDto, customerInDb);

            //below code will be executed automatically by Mapper.Map above
            //customerInDb.Name = customer.Name;
            //customerInDb.Birthdate = customer.Birthdate;
            //customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            //customerInDb.MembershipTypeId = customer.MembershipTypeId;

            //__context.savechanges

        }

        //DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _customers.FirstOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _customers.Remove(customerInDb);

            //__context.savechanges

        }
    }
}
