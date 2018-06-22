using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Interfaces;
using Data.Model;
using LoggerService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Canchas.Controllers
{
    [Route("api/[controller]")]
    public class GamesController : Controller
    {
        private ILoggerManager _logger;
        private readonly IGameRepository _gameRepository;

        public GamesController(ILoggerManager logger, IGameRepository gameRepository)
        {
            _logger = logger;
            _gameRepository = gameRepository;
        }

        // GET: api/<controller>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var game = _gameRepository.GetById(id);

                if (game.IsNullOrEmpty())
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned owner with id: {id}");
                    return Ok(game);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public IActionResult GetAllOwners()
        {
            try
            {
                var games = _gameRepository.GetAll();

                _logger.LogInfo($"Returned all owners from database.");

                return Ok(games);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public IActionResult GetAllWithFields()
        {
            try
            {
                var games = _gameRepository.GetAllWithFields();

                _logger.LogInfo($"Returned all owners from database.");

                return Ok(games);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
