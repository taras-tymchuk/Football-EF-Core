using BLL.Interfaces;
using DAL.Context;
using DAL.Unit_Of_Work;
using System;

namespace UI
{
    public enum OperationType
    {
        Help = 1, Teams, Squads
    }

    public class ConsoleController
    {
        private readonly IAgeChecker _ageChecker;

        public ConsoleController( IAgeChecker ageChecker )
        {
            _ageChecker = ageChecker;
        }

        public void RemoveOlderThan( int age )
        {
            using ( var footbalContext = new UnitOfWork( new FootballContext() ) )
            {
                var players = footbalContext.Players.GetAll();

                foreach ( var player in players )
                {
                    if ( !_ageChecker.IsYoungerThan( player, age ) )
                    {
                        footbalContext.Players.Remove( player );
                    }
                }

                footbalContext.Save();
            }
        }

        public void ShowTeams()
        {
            using ( var footballContext = new UnitOfWork( new FootballContext() ) )
            {
                foreach ( var team in footballContext.Teams.GetAll() )
                {
                    Console.WriteLine( $"{team.Name} has {team.Budget}$." );
                }
            }
        }

        public void ShowAllTeamsWithSquad()
        {
            using ( var footballContext = new UnitOfWork( new FootballContext() ) )
            {
                foreach ( var team in footballContext.Teams.GetTeamsWithPlayers() )
                {
                    var players = team.Players;

                    if ( players == null )
                    {
                        Console.WriteLine( $"Team \'{team.Name}\' " +
                                           $"doesn't have players." );
                    }
                    else
                    {
                        Console.WriteLine( $"Team \'{team.Name}\' has " +
                                          $"{team.Players.Count} players:" );
                        foreach ( var player in team.Players )
                        {
                            Console.WriteLine( $"- {player.FirstName} {player.LastName}" );
                        }
                    }
                }
            }
        }

        public void ShowMenu()
        {
            Console.WriteLine( "Enter 1 to show menu." );
            Console.WriteLine( "Enter 2 to show teams." );
            Console.WriteLine( "Enter 3 to show teams with their squads." );
            Console.WriteLine( "Enter something else to exit." );
        }
    }
}
