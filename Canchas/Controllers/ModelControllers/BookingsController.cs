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
    public class BookingsController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public BookingsController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        // GET: api/Businesses 
        [HttpGet(Name = "BookingGetAll")]
        public IEnumerable<Booking> GetBookings()
        {
            return _repository.Bookings.GetAll();
        }
        // GET: api/Businesses 
        [HttpGet(Name = "BookingGetAllWithCustomerAndField")]
        public IEnumerable<Booking> GetAllBookingsWithCustomerAndField()
        {
            return _repository.Bookings.GetAllWithCustomerAndField();
        }

        // GET: api/<controller>/5
        [HttpGet("{id}", Name = "BookingById")]
        public IActionResult GetById(int id)
        {
            try
            {
                var booking = _repository.Bookings.GetById(id);

                if (booking.IsNullOrEmpty())
                {
                    _logger.LogError($"Booking with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned booking with id: {id}");
                    return Ok(booking);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside BookingById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        // GET: api/<controller>/5
        [HttpGet("{id}", Name = "BookingByIdGetWithCustomerAndField")]
        public IActionResult GetWithCustomerAndField(int id)
        {
            try
            {
                var booking = _repository.Bookings.GetWithCustomerAndField(id);

                if (booking.IsNullOrEmpty())
                {
                    _logger.LogError($"Booking with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned BookingByIdGetWithCustomerAndField with id: {id}");
                    return Ok(booking);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside BookingByIdGetWithCustomerAndField action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        // PUT: api/Businesses/5
        [HttpPut("{id}")]
        public IActionResult CreateBooking([FromBody] Booking booking)
        {
            try
            {
                if (booking.IsObjectNull())
                {
                    _logger.LogError("String object sent from client is null.");
                    return BadRequest("Booking object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid booking object sent from client.");
                    return BadRequest("Invalid model object");
                }
                Field dbField = _repository.Fields.GetById(booking.FieldId);
                if (dbField.IsNullOrEmpty())
                {
                    _logger.LogError("Invalid FieldId sent from client.");
                    return BadRequest("Invalid FieldId in booking object");
                }
                Customer dbCustomer = _repository.Customers.GetById(booking.CustomerId);
                if (dbField.IsNullOrEmpty())
                {
                    _logger.LogError("Invalid CustomerId sent from client.");
                    return BadRequest("Invalid CustomerId in booking object");
                } 
                _repository.Bookings.Create(booking);

                return CreatedAtRoute("BookingById", new { id = booking.Id }, booking);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateBooking action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/Businesses
        [HttpPost]
        public IActionResult UpdateBooking(int id, [FromBody] Booking booking)
        {
            try
            {
                if (id != booking.Id)
                {
                    _logger.LogError($"Booking object {booking.Id} sent from client is different from {id}.");
                    return BadRequest("Id error");
                }
                if (booking.IsObjectNull())
                {
                    _logger.LogError("Booking object sent from client is null.");
                    return BadRequest("Booking object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid booking object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var dbBooking = _repository.Bookings.GetById(id);
                if (dbBooking.IsEmptyObject())
                {
                    _logger.LogError($"Booking with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Bookings.Update(booking);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateBooking action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/Businesses/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBusiness(int id)
        {
            try
            {
                var business = _repository.Businesses.GetWithFields(id);
                if (business.IsEmptyObject())
                {
                    _logger.LogError($"Field with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                if (business.Fields.Any())
                {
                    _logger.LogError($"Cannot delete business with id: {id}. It has related fields. Delete those fields first");
                    return BadRequest("Cannot delete business. It has related fields. Delete those fields first");
                }

                _repository.Businesses.Delete(business);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteBusiness action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}