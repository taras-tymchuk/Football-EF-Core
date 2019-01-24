using DAL.Repositories;
using DAL.Context;

namespace DAL.Unit_Of_Work
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FootballContext _context;

        public IPlayerRepository Players
        {
            get; private set;
        }
        public ITeamRepository Teams
        {
            get; private set;
        }

        public UnitOfWork( FootballContext context )
        {
            _context = context;
            Players = new PlayerRepository( _context );
            Teams = new TeamRepository( _context );
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
