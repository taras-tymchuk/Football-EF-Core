using BLL.Classes;
using System;

namespace UI
{
    internal class Demo
    {
        private static void Main( string[] args )
        {
            AgeChecker ageChecker = new AgeChecker();
            ConsoleController controller = new ConsoleController( ageChecker );

            controller.ShowMenu();

            bool flag = true;

            while ( flag )
            {
                OperationType operation =
                    (OperationType) int.Parse( Console.ReadLine() );
                switch ( operation )
                {
                    case OperationType.Help:
                        controller.ShowMenu();
                        break;

                    case OperationType.ShowTeams:
                        controller.ShowTeams();
                        break;

                    case OperationType.ShowSquads:
                        controller.ShowAllTeamsWithSquad();
                        break;

                    case OperationType.ShowOldPlayers:
                        Console.Write( "Enter age limit: " );
                        int age = int.Parse( Console.ReadLine() );
                        controller.ShowOlderThan( age );
                        break;

                    case OperationType.CreateTeam:
                        controller.CreateTeam();
                        break;

                    default:
                        Console.WriteLine( "Thanks for session" );
                        flag = false;
                        break;
                }
            }

            Console.ReadLine();
        }
    }
}
