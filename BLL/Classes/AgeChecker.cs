using BLL.Interfaces;
using DAL.Models;

namespace BLL.Classes
{
    public class AgeChecker : IAgeChecker
    {
        public bool IsYoungerThan( Player player, int age )
        {
            return player.Age < age;
        }
    }
}
