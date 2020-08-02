using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerWebApp.Entities;
using log4net.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomerWebApp
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        [HttpGet("SingleCustomer")]
        public CustomerEntity Get()
        {
            //http://localhost:5001/api/Customer/SingleCustomer
            return new CustomerEntity()
            {
                Id = 1,
                Name = "Foo"
            };
        }
    }
}
