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
using LoggerService;

namespace BookingCanchas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldsController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public FieldsController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        // GET: api/<controller>
        [HttpGet("{id}", Name = "FieldById")]
        public IActionResult GetById(int id)
        {
            try
            {
                var field = _repository.Fields.GetById(id);

                if (field.IsNullOrEmpty())
                {
                    _logger.LogError($"Field with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned field with id: {id}");
                    return Ok(field);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetFieldById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "FieldByIdWithGameAndBusiness")]
        public IActionResult GetByIdWithGameAndBusiness(int id)
        {
            try
            {
                var field = _repository.Fields.GetWithGameAndBusiness(id);

                if (field.IsNullOrEmpty())
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned owner with id: {id}");
                    return Ok(field);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetByIdWithGameAndBusiness action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet(Name = "FieldGetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var fields = _repository.Fields.GetAll();

                _logger.LogInfo($"Returned all fields from database.");

                return Ok(fields);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllfields action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet(Name = "FieldGetAllWithGameAndBusiness")]
        public IActionResult GetAllWithGameAndBusiness()
        {
            try
            {
                var fields = _repository.Fields.GetAllWithGameAndBusiness();

                _logger.LogInfo($"Returned all fields from database.");

                return Ok(fields);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllWithGameAndBusiness action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "FieldByIdWithGameAndBusinessAndBooking")]
        public IActionResult GetByIdWithGameAndBusinessAndBooking(int id)
        {
            try
            {
                var field = _repository.Fields.GetWithGameAndBusinessAndBookings(id);

                if (field.IsNullOrEmpty())
                {
                    _logger.LogError($"Field with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned GetByIdWithGameAndBusinessAndBooking with id: {id}");
                    return Ok(field);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetByIdWithGameAndBusinessAndBooking action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet(Name = "FieldGetAllwithGameAndBusinessAndBooking")]
        public IActionResult GetAllWithGameAndBusinessAndBooking()
        {
            try
            {
                var fields = _repository.Fields.GetAllWithGameAndBusinessAndBookings();

                _logger.LogInfo($"Returned all fields from database.");

                return Ok(fields);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllWithGameAndBusinessAndBooking action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        // POST api/<controller>
        [HttpPost]
        public IActionResult CreateField([FromBody]Field field)
        {
            try
            {
                if (field.IsObjectNull())
                {
                    _logger.LogError("String object sent from client is null.");
                    return BadRequest("Field object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid field object sent from client.");
                    return BadRequest("Invalid model object");
                }

                _repository.Fields.Create(field);

                return CreatedAtRoute("FieldbyId", new { id = field.Id }, field);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateField action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult UpdateField(int id, [FromBody]Field field)
        {
            try
            {
                if (id != field.Id)
                {
                    _logger.LogError($"Field object {field.Id} sent from client is different from {id}.");
                    return BadRequest("Id error");
                }
                if (field.IsObjectNull())
                {
                    _logger.LogError("Field object sent from client is null.");
                    return BadRequest("Field object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid field object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var dbField = _repository.Fields.GetById(id);
                if (dbField.IsEmptyObject())
                {
                    _logger.LogError($"Field with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Fields.Update(field);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteField(int id)
        {
            try
            {
                var field = _repository.Fields.GetWithGameAndBusinessAndBookings(id);
                if (field.IsEmptyObject())
                {
                    _logger.LogError($"Field with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                if (field.Bookings.Any())
                {
                    _logger.LogError($"Cannot delete field with id: {id}. It has related bookings. Delete those bookings first");
                    return BadRequest("Cannot delete field. It has related bookings. Delete those bookings first");
                }

                _repository.Fields.Delete(field);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteField action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
