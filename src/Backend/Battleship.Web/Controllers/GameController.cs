using Battleship.Domain.Abstract;
using Battleship.Domain.Abstract.Builders;
using Battleship.Web.Models;
using Battleship.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Battleship.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<GameController> _logger;
        private readonly IGameBuilder _builder;
        private readonly IGameHost _gameHost;
        private readonly IGameSimulationService _simulator;

        public GameController(ILogger<GameController> logger, IGameBuilder builder, IGameHost gameHost, IGameSimulationService simulator)
        {
            _logger = logger;
            _builder = builder;
            _gameHost = gameHost;
            _simulator = simulator;
        }

        [HttpPost("new")]
        public IActionResult Create([FromBody] CreateGameModel model)
        {
            if (model.Size < 0)
                return BadRequest("Board size can't be less than 0.");

            _builder.WithBoardSize(model.Size);
            var game = _builder.Build();

            var report = _simulator.Simulate(_gameHost, game);
            
            return Ok(report);
        }
    }
}
