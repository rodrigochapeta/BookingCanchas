using Data.Interfaces;
using Data.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Canchas.Controllers
{
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private ILoggerManager _logger;
        private readonly IRepositoryWrapper _repository;

        public GamesController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        // GET: api/<controller>
        [HttpGet("{id}", Name = "GameById")]
        public IActionResult GetById(int id)
        {
            try
            {
                var game = _repository.Games.GetById(id);

                if (game.IsNullOrEmpty())
                {
                    _logger.LogError($"Game with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned game with id: {id}");
                    return Ok(game);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetGameById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}", Name = "GameByIdWithFields")]
        public IActionResult GetByIdWithFields(int id)
        {
            try
            {
                var game = _repository.Games.GetWithFields(id);

                if (game.IsNullOrEmpty())
                {
                    _logger.LogError($"Game with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned game with id: {id}");
                    return Ok(game);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetGameById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet(Name = "GameGetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var games = _repository.Games.GetAll();

                _logger.LogInfo($"Returned all games from database.");

                return Ok(games);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOGames action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet(Name = "GameGetAllWithFields")]
        public IActionResult GetAllWithFields()
        {
            try
            {
                var games = _repository.Games.GetAllWithFields();

                _logger.LogInfo($"Returned all games from database.");

                return Ok(games);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllGames action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult CreateGame([FromBody]Game game)
        {
            try
            {
                if (game.IsObjectNull())
                {
                    _logger.LogError("String object sent from client is null.");
                    return BadRequest("Game object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid game object sent from client.");
                    return BadRequest("Invalid model object");
                }

                _repository.Games.Create(game);

                return CreatedAtRoute("GameById", new { id = game.Id }, game);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateGame action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult UpdateGame(int id, [FromBody]Game game)
        {
            try
            {
                if (id != game.Id)
                {
                    _logger.LogError($"Game object {game.Id} sent from client is different from {id}.");
                    return BadRequest("Id error");
                }
                if (game.IsObjectNull())
                {
                    _logger.LogError("Game object sent from client is null.");
                    return BadRequest("Game object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid game object sent from client.");
                    return BadRequest("Invalid model object");
                }
               
                var dbGame = _repository.Games.GetById(id);
                if (dbGame.IsEmptyObject())
                {
                    _logger.LogError($"Game with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Games.Update(game);

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
        public IActionResult DeleteGame(int id)
        {
            try
            {
                var game = _repository.Games.GetWithFields(id);
                if (game.IsEmptyObject())
                {
                    _logger.LogError($"Game with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                if (game.Fields.Any())
                {
                    _logger.LogError($"Cannot delete game with id: {id}. It has related fields. Delete those fields first");
                    return BadRequest("Cannot delete game. It has related fields. Delete those fields first");
                }

                _repository.Games.Delete(game);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteGame action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
