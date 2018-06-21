using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Interfaces;
using Data.Model;
using LoggerService;
using Microsoft.AspNetCore.Mvc;

namespace Canchas.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        public string i = "";
        private ILoggerManager _logger;
        private readonly IGameRepository _gameRepository;
        public SampleDataController(ILoggerManager logger, IGameRepository gameRepository)
        {
            _logger = logger;
            _gameRepository = gameRepository;
        }

        [HttpGet("[action]")]
        public IEnumerable<Game> Games()
        {
            var listaGames = _gameRepository.GetAll();
            _logger.LogInfo($"Returned all games from database.");
            return listaGames;
        }

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
