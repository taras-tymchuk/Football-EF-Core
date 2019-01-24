using DAL.Models;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public interface ITeamRepository : IRepository<Team>
    {
        IEnumerable<Team> GetTopRichestTeams( int count );
        IEnumerable<Team> GetListOfPlayers( string teamName );
        IEnumerable<Team> GetTeamByName( string teamName );
        void RemoveByTeamName( string teamName );
        IEnumerable<Team> GetTeamsWithPlayers();
    }
}
