using Mc2.CrudTest.Presentation.Server.Interfaces;
using Mc2.CrudTest.Shared.Data;
using Mc2.CrudTest.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerService _customerService;
        CrudTestContext _context;
        public CustomerController(ICustomerService customerService, CrudTestContext context) 
        { 
            _customerService = customerService;
            _context = context;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _customerService.GetCustomers();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            return customer;
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult AddCustomer([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            //_mapper.Map<Customer>(customer);

            _customerService.AddCustomer(customer);
            return Ok();
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }
            _customerService.UpdateCustomer(customer.CustomerId,customer);
            return Ok();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _customerService.RemoveCustomer(id);
        }
    }
}
