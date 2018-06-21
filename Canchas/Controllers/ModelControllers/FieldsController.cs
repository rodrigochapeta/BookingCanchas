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

        // GET: api/Fields
        [HttpGet]
        public IEnumerable<Field> GetFields()
        {
            return _repository.Field.GetAll();
        }

        // GET: api/Fields/5
        [HttpGet("{id}")]
        public IActionResult GetField([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @field = _repository.Field.GetById(id);

            if (@field == null)
            {
                return NotFound();
            }

            return Ok(@field);
        }

        // PUT: api/Fields/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutField([FromRoute] int id, [FromBody] Field @field)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @field.Id)
            {
                return BadRequest();
            }

            _context.Entry(@field).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FieldExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Fields
        [HttpPost]
        public async Task<IActionResult> PostField([FromBody] Field @field)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Fields.Add(@field);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetField", new { id = @field.Id }, @field);
        }

        // DELETE: api/Fields/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteField([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @field = await _context.Fields.FindAsync(id);
            if (@field == null)
            {
                return NotFound();
            }

            _context.Fields.Remove(@field);
            await _context.SaveChangesAsync();

            return Ok(@field);
        }

        private bool FieldExists(int id)
        {
            return _context.Fields.Any(e => e.Id == id);
        }
    }
}