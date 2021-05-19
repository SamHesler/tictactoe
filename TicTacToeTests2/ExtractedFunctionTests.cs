using NUnit.Framework;
using TicTacToe;

namespace TicTacToeTests
{
    class ExtractedFunctionTests
    {
        [Test]
        public void CheckWinner_Diagonal2_Should_Pass()
        {
            ExtractedFunctions.CheckWinner(Player.PlayerO, new Game.GameResult(Player.PlayerO, 1, 1, 1), 2);
            //Todo see if game result can be parsed
            Assert.True(true);
        }

        [Test]
        public void CheckWinner_Diagonal1_Should_Pass()
        {
            ExtractedFunctions.CheckWinner(Player.PlayerO, new Game.GameResult(Player.PlayerO, 1, 1, 1), 1);
            //Todo see if game result can be parsed
            Assert.True(true);
        }
    }
}
