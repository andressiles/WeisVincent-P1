﻿using IceShopAPI.DTO;
using IceShopBL;
using IceShopDB.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace IceShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        public IActionResult AddCustomer(Customer newCustomer)
        {
            try
            {
                _customerService.AddCustomerToRepo(newCustomer);
                return CreatedAtAction("AddCustomer", newCustomer);
            }
            catch (Exception)
            {
                // TODO: Check if this is the right error code for this.
                return StatusCode(500);
            }
        }


        [HttpGet("get")]
        [Produces("application/json")]
        public IActionResult GetAllCustomers()
        {
            try
            {
                return Ok(_customerService.GetAllCustomers());
            } catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("get/{email}")]
        [Produces("application/json")]
        public IActionResult GetCustomerByEmail(string email)
        {
            try
            {
                return Ok(_customerService.GetCustomerByEmail(email));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }


        [HttpGet("get/orders/{email}")]
        [Produces("application/json")]
        public IActionResult GetOrders(string email)
        {
            try
            {
                APIMapperProfile mapper = new APIMapperProfile();
                var customer = _customerService.GetCustomerByEmail(email);
                var orders = _customerService.GetAllOrdersForCustomer(customer);


                List<OrderDTO> result = mapper.ParseOrders(orders);

                
                

                //return Content(orders[0].Customer.ToString());
                return Ok(result);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPut("update/{customer}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateCustomer(Customer customer)
        {
            try
            {
                // TODO: Figure out if updating works statelessly.
                _customerService.UpdateCustomerEntry(customer);
                return AcceptedAtAction("UpdateProductEntry", customer);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


    }
}
