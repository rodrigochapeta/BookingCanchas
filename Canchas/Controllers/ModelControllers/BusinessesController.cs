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
    public class BusinessesController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public BusinessesController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        // GET: api/Businesses 
        [HttpGet(Name = "BusinessGetAll")]
        public IEnumerable<Business> GetBusinesses()
        {
            return _repository.Businesses.GetAll();
        }
        // GET: api/Businesses 
        [HttpGet(Name = "BusinessGetAllWithFields")]
        public IEnumerable<Business> GetBusinessWith()
        {
            return _repository.Businesses.GetAllWithFields();
        }

        // GET: api/<controller>/5
        [HttpGet("{id}", Name = "BusinessById")]
        public IActionResult GetById(int id)
        {
            try
            {
                var business = _repository.Businesses.GetById(id);

                if (business.IsNullOrEmpty())
                {
                    _logger.LogError($"Business with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned business with id: {id}");
                    return Ok(business);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside BusinessById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        // GET: api/<controller>/5
        [HttpGet("{id}", Name = "BusinessByIdWithFields")]
        public IActionResult GetByIdWithFields(int id)
        {
            try
            {
                var business = _repository.Businesses.GetWithFields(id);

                if (business.IsNullOrEmpty())
                {
                    _logger.LogError($"Business with fields with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned business with fields with id: {id}");
                    return Ok(business);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside BusinessByIdWithFields action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        // PUT: api/Businesses/5
        [HttpPut("{id}")]
        public IActionResult CreateBusiness([FromBody] Business business)
        {
            try
            {
                if (business.IsObjectNull())
                {
                    _logger.LogError("String object sent from client is null.");
                    return BadRequest("Business object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid business object sent from client.");
                    return BadRequest("Invalid model object");
                }

                _repository.Businesses.Create(business);

                return CreatedAtRoute("BusinessById", new { id = business.Id }, business);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateBusiness action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/Businesses
        [HttpPost]
        public  IActionResult UpdateBusiness(int id,[FromBody] Business business)
        {
            try
            {
                if (id != business.Id)
                {
                    _logger.LogError($"Business object {business.Id} sent from client is different from {id}.");
                    return BadRequest("Id error");
                }
                if (business.IsObjectNull())
                {
                    _logger.LogError("Business object sent from client is null.");
                    return BadRequest("Business object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid business object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var dbBusiness = _repository.Businesses.GetById(id);
                if (dbBusiness.IsEmptyObject())
                {
                    _logger.LogError($"Business with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Businesses.Update(business);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateOwner action: {ex.Message}");
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