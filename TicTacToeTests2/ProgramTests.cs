using NUnit.Framework;
using TicTacToe;

namespace TicTacToeTests
{
    public class ProgramTests
    {
         [Test]
        public void FirstLetterToUpper_Valid_ParamNull_ReturnNull()
        {
            string lower = null;
            Assert.AreEqual(Program.FirstLetterToUpper(lower), null);
        }

        [Test]
        public void FirstLetterToUpper_Valid_StrLenGreaterThan1_ReturnCorrect()
        {
            string lower = "lower";
            string upper = "Lower";
            Assert.AreEqual(Program.FirstLetterToUpper(lower), upper);
        }

        [Test]
        public void FirstLetterToUpper_Valid_StrLenIsOne_ReturnCorrect()
        {
            string lower = "l";
            string upper = "L";
            Assert.AreEqual(Program.FirstLetterToUpper(lower), upper);
        }
    }
}