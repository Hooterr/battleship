 using Battleship.Domain.Abstract;
using Battleship.Domain.Abstract.Builders;
using Battleship.Domain.Abstract.Rules;
using Battleship.Domain.Builders;
using Battleship.Domain.Rules;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Domain
{
    public static class AppDomainInstaller 
    {
        public static void Install(IServiceCollection services)
        {
            services.AddScoped<IRandomProvider, RandomProvider>();
            services.AddScoped<IShipRandomizer, ShipRandomizer>();
            services.AddTransient<IGameBuilder, GameBuilder>();
            services.AddTransient<IGameHost, GameHost>();
            services.AddScoped<IPlayer, NotSoSmartPlayer>();
            services.AddSingleton<IGameEndRule, AllShipsSunkGameEndRule>();
            services.AddSingleton<IChooseWinnerRule, DefaultChooseWinnerRule>();
            services.AddSingleton<IPlayerShootingRule, CanShootOnlyAtUndiscoveredCellRule>();
        }
    }
}
