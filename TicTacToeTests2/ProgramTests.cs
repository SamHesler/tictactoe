using NUnit.Framework;
using TicTacToe;

namespace TicTacToeTests2
{
    public class ProgramTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Program_FirstLetterToUpper_1stif()
        {
            string lower = null;
            Assert.AreEqual(Program.FirstLetterToUpper(lower), null);
        }

        [Test]
        public void Program_FirstLetterToUpper_2ndif()
        {
            string lower = "lower";
            string upper = "Lower";
            Assert.AreEqual(Program.FirstLetterToUpper(lower), upper);
        }

        [Test]
        public void Program_FirstLetterToUpper_else()
        {
            string lower = "l";
            string upper = "L";
            Assert.AreEqual(Program.FirstLetterToUpper(lower), upper);
        }
    }
}