using Battleship.Domain;
using Battleship.Domain.Abstract;
using Battleship.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battleship.Web.Services
{
    public interface IGameSimulationService
    {
        GameSimulationModel Simulate(IGameHost host, Game game);
    }
}
