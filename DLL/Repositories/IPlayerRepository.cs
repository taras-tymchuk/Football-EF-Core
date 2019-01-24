using DAL.Models;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public interface IPlayerRepository : IRepository<Player>
    {
        IEnumerable<Player> GetPlayersWithTeam();
        IEnumerable<Player> GetPlayersFromBarcelonaTeam();
        IEnumerable<Player> GetPlayerByFullName(
            string firstName, string lastName );
    }
}
