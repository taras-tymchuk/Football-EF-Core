using DAL.Repositories;
using System;

namespace DAL.Unit_Of_Work
{
    public interface IUnitOfWork : IDisposable
    {
        IPlayerRepository Players { get; }
        ITeamRepository Teams { get; }

        int Save();
    }
}
