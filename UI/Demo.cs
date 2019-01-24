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
                    (OperationType)Int32.Parse(Console.ReadLine());
                switch (operation)
                {
                    case OperationType.Help:
                        controller.ShowMenu();
                        break;

                    case OperationType.Teams:
                        controller.ShowTeams();
                        break;

                    case OperationType.Squads:
                        controller.ShowAllTeamsWithSquad();
                        break;

                    default:
                        Console.WriteLine("Thanks for session");
                        flag = false;
                        break;
                }
            }

            Console.ReadLine();
        }
    }
}
