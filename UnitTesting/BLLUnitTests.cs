using BLL.Classes;
using BLL.Interfaces;
using DAL.Models;
using NUnit.Framework;

namespace BLLTesting
{
    [TestFixture]
    public class BllUnitTests
    {
        [TestCase( true, 20, 30 )]
        [TestCase( false, 30, 30 )]
        [TestCase( false, 25, 20 )]
        public void IsYoungerThan_BigAge_ReturnsFalse(
            bool expected, int playerAge, int limitAge )
        {
            IAgeChecker ageChecker = new AgeChecker();
            Player player = new Player { Age = playerAge };
            bool result = ageChecker.IsYoungerThan( player, limitAge );
            Assert.AreEqual( expected, result );
        }
    }
}
