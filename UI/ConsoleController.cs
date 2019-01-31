using BLL.Interfaces;
using DAL.Context;
using DAL.Models;
using DAL.Unit_Of_Work;
using System;

namespace UI
{
    public enum OperationType
    {
        Help = 1, ShowTeams, ShowSquads, ShowOldPlayers, CreateTeam
    }

    public class ConsoleController
    {
        private readonly IAgeChecker ageChecker;

        public ConsoleController( IAgeChecker ageChecker )
        {
            this.ageChecker = ageChecker;
        }

        public void ShowOlderThan( int age )
        {
            using ( var footballContext =
                new UnitOfWork( new FootballContext() ) )
            {
                var players = footballContext.Players.GetAll();

                foreach ( var player in players )
                {
                    if ( !ageChecker.IsYoungerThan( player, age ) )
                    {
                        Console.WriteLine( $"{player.FirstName} " +
                                          $"{player.LastName} is " +
                                          $"{player.Age} years old." );
                    }
                }

                footballContext.Save();
            }
        }

        public void ShowTeams()
        {
            using ( var footballContext =
                new UnitOfWork( new FootballContext() ) )
            {
                foreach ( var team in footballContext.Teams.GetAll() )
                {
                    Console.WriteLine(
                        $"{team.Name} has {team.Budget}$." );
                }
            }
        }

        public void ShowAllTeamsWithSquad()
        {
            using ( var footballContext =
                new UnitOfWork( new FootballContext() ) )
            {
                foreach ( var team in footballContext.Teams
                    .GetTeamsWithPlayers() )
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
                            Console.WriteLine( $"- {player.FirstName} " +
                                               $"{player.LastName}" );
                        }
                    }
                }
            }
        }

        public void CreateTeam()
        {
            Console.Write( "Enter name: " );
            string name = Console.ReadLine();
            Console.Write( "Enter budget: " );
            decimal budget = decimal.Parse( Console.ReadLine() );

            Team team = new Team()
            {
                Name = name,
                Budget = budget,
            };

            using ( var footballContext =
                new UnitOfWork( new FootballContext() ) )
            {
                footballContext.Teams.Add( team );
                footballContext.Save();
            }
        }

        public void ShowMenu()
        {
            Console.WriteLine( "Enter 1 to show menu." );
            Console.WriteLine( "Enter 2 to show teams." );
            Console.WriteLine( "Enter 3 to show teams with their squads." );
            Console.WriteLine( "Enter 4 to show old players." );
            Console.WriteLine( "Enter 5 to create team." );
            Console.WriteLine( "Enter something else to exit." );
        }
    }
}
