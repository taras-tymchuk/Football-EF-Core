using DAL.Context;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class TeamRepository :
        Repository<Team, FootballContext>, ITeamRepository
    {
        public TeamRepository( FootballContext context )
            : base( context )
        {
        }

        public IEnumerable<Team> GetTeamByName( string teamName )
        {
            return Context.Teams
                .Where( t => t.Name == teamName );
        }

        public IEnumerable<Team> GetListOfPlayers( string teamName )
        {
            return Context.Teams
                .Where( t => t.Name == teamName )
                .Include( t => t.Players )
                .ToList();
        }

        public IEnumerable<Team> GetTopRichestTeams( int count )
        {
            return Context.Teams
                .OrderByDescending( t => t.Budget )
                .Take( count );
        }

        public void RemoveByTeamName( string teamName )
        {
            Context.Teams
                .RemoveRange( Context.Teams.Where( t => t.Name == teamName ).ToList() );
        }

        public IEnumerable<Team> GetTeamsWithPlayers()
        {
            return Context.Teams.
                Include( t => t.Players ).
                ToList();
        }
    }
}
