using BLL.Classes;
using BLL.Interfaces;
using DAL.Models;
using NUnit.Framework;

namespace BLLTesting
{
    [TestFixture]
    public class BllUnitTests
    {
        [TestCase( 20, 30, true )]
        [TestCase( 30, 30, false )]
        [TestCase( 25, 20, false )]
        public void IsYoungerThanTest(
            int playerAge, int limitAge, bool expected )
        {
            IAgeChecker ageChecker = new AgeChecker();
            Player player = new Player { Age = playerAge };
            bool result = ageChecker.IsYoungerThan( player, limitAge );
            Assert.AreEqual( expected, result );
        }
    }
}
