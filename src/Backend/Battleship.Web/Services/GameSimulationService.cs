using Battleship.Domain;
using Battleship.Domain.Abstract;
using Battleship.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battleship.Web.Services
{
    public class GameSimulationService : IGameSimulationService
    {
        public GameSimulationModel Simulate(IGameHost host, Game game)
        {
            var report = new GameSimulationModel
            {
                Ships = game.PlayerA.Ships.Select(x => new GameSimulationShip()
                {
                    Length = x.Length,
                }).ToList(),

                BoardA = new List<List<GameGridCellModel>>(game.Size),
                BoardB = new List<List<GameGridCellModel>>(game.Size),
            };

            for (int x = 0; x < game.Size; x++)
            {
                report.BoardA.Add(new List<GameGridCellModel>(game.Size));
                report.BoardB.Add(new List<GameGridCellModel>(game.Size));
                for (int y = 0; y < game.Size; y++)
                {
                    report.BoardA[x].Add(new()
                    {
                        IsOccupied = game.PlayerA[x, y].IsOccupied,
                        State = game.PlayerA[x, y].State
                    }) ;
                    report.BoardB[x].Add(new()
                    {
                        IsOccupied = game.PlayerB[x, y].IsOccupied,
                        State = game.PlayerB[x, y].State
                    });
                }
            }

            host.Host(game);
            host.Simulate();

            report.PlayerMoves = host.PlayerMoves.Select(x => new GameSimulationPlayerMove()
            {
                X = x.X,
                Y = x.Y,
                Messgae = x.Message,
                Source = x.Source,
            }).ToList();

            report.GameResult = host.GameResult;

            return report;
        }
    }
}
