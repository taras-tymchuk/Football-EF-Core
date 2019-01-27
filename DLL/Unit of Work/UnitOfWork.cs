using DAL.Context;
using DAL.Repositories;

namespace DAL.Unit_Of_Work
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FootballContext context;

        public IPlayerRepository Players { get; }
        public ITeamRepository Teams { get; }

        public UnitOfWork( FootballContext context )
        {
            this.context = context;
            Players = new PlayerRepository( this.context );
            Teams = new TeamRepository( this.context );
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
