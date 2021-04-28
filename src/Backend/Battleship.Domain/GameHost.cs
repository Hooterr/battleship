using Battleship.Domain.Abstract;
using Battleship.Domain.Abstract.Rules;
using Battleship.Domain.Enums;
using Battleship.Domain.Log;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship.Domain
{
    public class GameHost : IGameHost
    {
        public IReadOnlyList<PlayerShotLogItem> PlayerMoves => _playerMoves;

        public Game Game { get; private set; }

        public GameResult GameResult { get; private set; }

        private List<PlayerShotLogItem> _playerMoves;
        private readonly IPlayer _player;
        private readonly IGameEndRule _gameEndingRule;
        private readonly IPlayerShootingRule _shootingRule;
        private readonly IChooseWinnerRule _chooseWinnerRule;

        public GameHost(IPlayer player, IPlayer p2, IGameEndRule gameEndingRule, IPlayerShootingRule shootingRule, IChooseWinnerRule chooseWinnerRule)
        {
            _player = player;
            var a = player == p2;
            _gameEndingRule = gameEndingRule;
            _shootingRule = shootingRule;
            _chooseWinnerRule = chooseWinnerRule;
        }

        /// <summary>
        /// Sets the host to host a given game.
        /// </summary>
        /// <param name="game">The game to host.</param>
        public void Host(Game game)
        {
            Game = game;
            _playerMoves = new List<PlayerShotLogItem>();
        }

        /// <summary>
        /// Simulates the game between a two opponents.
        /// </summary>
        public void Simulate()
        {
            if (Game == null)
            {
                throw new InvalidOperationException("Cannot start a game without a game object.");
            }

            var gameFinished = false;

            // Main loop
            while (!gameFinished)
            {
                ConductRound(conductingPlayer: _player, playerSrouce: PlayerSrouceEnum.PlayerA, enemyPlayerGrid: Game.PlayerB);
                ConductRound(conductingPlayer: _player, playerSrouce: PlayerSrouceEnum.PlayerB, enemyPlayerGrid: Game.PlayerA);

                if (_gameEndingRule.HasEnded(Game))
                    break;
            }

            GameResult = _chooseWinnerRule.ChooseWinner(Game);
        }


        private void ConductRound(IPlayer conductingPlayer, PlayerSrouceEnum playerSrouce, GameGrid enemyPlayerGrid)
        {
            var canContinue = true;

            while (canContinue)
            {
                // Ask player to choose target until they provide a valid one
                var validChoice = false;
                int x = 0, y = 0;
                while (!validChoice)
                {
                    (x, y) = conductingPlayer.ChooseTarget(enemyPlayerGrid);
                    validChoice = _shootingRule.IsAllowed(enemyPlayerGrid, x, y);
                }

                var hit = enemyPlayerGrid.Shoot(x, y);
                var anyShipsLeft = enemyPlayerGrid.Ships.Any(x => !x.Sunk);

                canContinue = hit && anyShipsLeft;

                Log(playerSrouce, x, y);
            }
        }

        private void Log(PlayerSrouceEnum player, int x, int y)
        {
            _playerMoves.Add(new PlayerShotLogItem(player, x, y));
        }
    }
}
