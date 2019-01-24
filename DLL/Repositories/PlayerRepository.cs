﻿using DAL.Context;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class PlayerRepository
        : Repository<Player, FootballContext>, IPlayerRepository
    {
        public PlayerRepository( FootballContext context )
            : base( context )
        {
        }

        public IEnumerable<Player> GetPlayerByFullName(
            string firstName, string lastName )
        {
            var res = Context.Players
                .Where( p => p.FirstName == firstName && p.LastName == lastName )
                .Include( p => p.Team )
                .ToList();

            return res;
        }

        public IEnumerable<Player> GetPlayersFromBarcelonaTeam()
        {
            return Context.Players
                .Include( p => p.Team )
                .Where( t => t.Team.Name == "Barcelona" )
                .ToList();
        }

        public IEnumerable<Player> GetPlayersWithTeam()
        {
            return Context.Players
                .Include(p => p.Team)
                .ToList();
        }
    }
}
