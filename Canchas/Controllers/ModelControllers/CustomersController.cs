using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Model;
using Data.Interfaces;

namespace BookingCanchas.Controllers.ModelControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public CustomersController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        // GET: api/Customers
        [HttpGet(Name = "CustomerGetAll")]
        public IEnumerable<Customer> GetCustomers()
        {
            return _repository.Customers.GetAll();
        }
        // GET: api/Customers
        [HttpGet(Name = "CustomerGetAllWithBookings")]
        public IEnumerable<Customer> GetCustomersWithBookings()
        {
            return _repository.Customers.GetAllWithBookings();
        }
        // GET: api/<controller>/5
        [HttpGet("{id}", Name = "CustomerById")]
        public IActionResult GetById(int id)
        {
            try
            {
                var customer = _repository.Customers.GetById(id);

                if (customer.IsNullOrEmpty())
                {
                    _logger.LogError($"Customer with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned customer with id: {id}");
                    return Ok(customer);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CustomerById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        // GET: api/<controller>/5
        [HttpGet("{id}", Name = "CustomerByIdWithBookings")]
        public IActionResult GetByIdWithBookings(int id)
        {
            try
            {
                var customer = _repository.Customers.GetWithBookings(id);

                if (customer.IsNullOrEmpty())
                {
                    _logger.LogError($"Customer with bookings with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned customer with Bookings with id: {id}");
                    return Ok(customer);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CustomerGetByIdWithBookings action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        // PUT: api/Businesses/5
        [HttpPut("{id}")]
        public IActionResult CreateCustomer([FromBody] Customer customer)
        {
            try
            {
                if (customer.IsObjectNull())
                {
                    _logger.LogError("String object sent from client is null.");
                    return BadRequest("Business object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid customer object sent from client.");
                    return BadRequest("Invalid model object");
                }

                _repository.Customers.Create(customer);

                return CreatedAtRoute("CustomerById", new { id = customer.Id }, customer);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateCustomer action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        // POST: api/Customers
        [HttpPost]
        public IActionResult UpdateCustomers(int id, [FromBody] Customer customer)
        {
            try
            {
                if (id != customer.Id)
                {
                    _logger.LogError($"Customer object {customer.Id} sent from client is different from {id}.");
                    return BadRequest("Id error");
                }
                if (customer.IsObjectNull())
                {
                    _logger.LogError("Customer object sent from client is null.");
                    return BadRequest("Customer object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid customer object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var dbCustomer = _repository.Customers.GetById(id);
                if (dbCustomer.IsEmptyObject())
                {
                    _logger.LogError($"Customer with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Customers.Update(customer);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateCustomers action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public IActionResult Customers(int id)
        {
            try
            {
                var customers = _repository.Customers.GetById(id);
                if (customers.IsEmptyObject())
                {
                    _logger.LogError($"Customers with id: {id}, hasn't been found in db.");
                    return NotFound();
                } 

                _repository.Customers.Delete(customers);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteCustomers action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}